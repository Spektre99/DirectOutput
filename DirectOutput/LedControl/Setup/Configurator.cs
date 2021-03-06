﻿using System.Collections.Generic;
using System.Linq;
using DirectOutput.Cab;
using DirectOutput.Cab.Out;
using DirectOutput.Cab.Toys;
using DirectOutput.Cab.Toys.Layer;
using DirectOutput.Cab.Toys.LWEquivalent;
using DirectOutput.FX;
using DirectOutput.FX.AnalogToyFX;
using DirectOutput.FX.RGBAFX;
using DirectOutput.FX.TimmedFX;
using DirectOutput.LedControl.Loader;
using DirectOutput.Cab.Color;

namespace DirectOutput.LedControl.Setup
{
    /// <summary>
    /// Configures the system based on data from ini files (either directoutputconfig.ini or ledcontrol.ini files)
    /// </summary>
    public class Configurator
    {
        /// <summary>
        /// The min duration for effects targeting a single output.
        /// </summary>
        public int EffectMinDurationMs = 60;
        /// <summary>
        /// The min duration for effects targeting rgbleds.
        /// </summary>
        public int EffectRGBMinDurationMs = 120;

        /// <summary>
        /// Configures the system based on the data loaded from ini files.
        /// </summary>
        /// <param name="LedControlConfigList">The list of loaded led control config data.</param>
        /// <param name="Table">The table object to be configured.</param>
        /// <param name="Cabinet">The cabinet object to be configured.</param>
        /// <param name="RomName">Name of the rom to be used for the setup.</param>
        public void Setup(LedControlConfigList LedControlConfigList, DirectOutput.Table.Table Table, Cabinet Cabinet, string RomName)
        {
            Dictionary<int, TableConfig> TableConfigDict = LedControlConfigList.GetTableConfigDictonary(RomName);

            Dictionary<int, Dictionary<int, IToy>> ToyAssignments = SetupCabinet(TableConfigDict, Cabinet);

            SetupTable(Table, TableConfigDict, ToyAssignments);


        }

        private void SetupTable(Table.Table Table, Dictionary<int, TableConfig> TableConfigDict, Dictionary<int, Dictionary<int, IToy>> ToyAssignments)
        {
            foreach (KeyValuePair<int, TableConfig> KV in TableConfigDict)
            {
                int LedWizNr = KV.Key;
                if (ToyAssignments.ContainsKey(LedWizNr))
                {
                    TableConfig TC = KV.Value;


                    foreach (TableConfigColumn TCC in TC.Columns)
                    {

                        if (ToyAssignments[LedWizNr].ContainsKey(TCC.Number))
                        {
                            IToy Toy = ToyAssignments[LedWizNr][TCC.Number];

                            int SettingNumber = 0;
                            foreach (TableConfigSetting TCS in TCC)
                            {
                                SettingNumber++;
                                IEffect Effect = null;

                                int Layer = (TCS.Layer.HasValue ? TCS.Layer.Value : SettingNumber);

                                if (Toy is IRGBAToy || Toy is IAnalogAlphaToy)
                                {
                                    if (Toy is IRGBAToy)
                                    {
                                        RGBAColor ActiveColor = null;
                                        if (TCS.ColorConfig != null)
                                        {
                                            ActiveColor = TCS.ColorConfig.GetCabinetColor().GetRGBAColor();
                                        }
                                        else
                                        {
                                            if (!TCS.ColorName.IsNullOrWhiteSpace())
                                            {
                                                if (TCS.ColorName.StartsWith("#"))
                                                {
                                                    ActiveColor = new RGBAColor();
                                                    if (!ActiveColor.SetColor(TCS.ColorName))
                                                    {
                                                        ActiveColor = null;
                                                        Log.Warning("Skipped setting {0} in column {1} for LedWizEqivalent number {2} since {3} is not a valid color specification.".Build(new object[] { SettingNumber, TCC.Number, LedWizNr, TCS.ColorName }));
                                                    }
                                                }
                                                else
                                                {
                                                    Log.Warning("Skipped setting {0} in column {1} for LedWizEqivalent number {2} since {3} is not a valid color specification.".Build(new object[] { SettingNumber, TCC.Number, LedWizNr, TCS.ColorName }));
                                                }
                                            }
                                            else
                                            {
                                                Log.Warning("Skipped setting {0} in column {1} for LedWizEqivalent number {2} since it does not contain a color specification.".Build(SettingNumber, TCC.Number, LedWizNr));
                                            }
                                        }
                                        if (ActiveColor != null)
                                        {
                                            if (TCS.FadingDownDurationMs > 0 || TCS.FadingUpDurationMs > 0)
                                            {
                                                //Must fade, use fadeeffect
                                                Effect = new RGBAFadeOnOffEffect() { ToyName = Toy.Name, Layer = Layer, FadeActiveDurationMs = TCS.FadingUpDurationMs, FadeInactiveDurationMs = TCS.FadingDownDurationMs, RetriggerBehaviour = RetriggerBehaviourEnum.IgnoreRetrigger, FadeMode = FadeModeEnum.CurrentToDefined, ActiveColor = ActiveColor, InactiveColor = new RGBAColor(0, 0, 0, 0) };

                                            }
                                            else
                                            {
                                                //No fadinging, set color directly
                                                Effect = new RGBAOnOffEffect() { ToyName = Toy.Name, Layer = Layer, ActiveColor = ActiveColor, InactiveColor = new RGBAColor(0, 0, 0, 0) };
                                            }


                                        }
                                    }
                                    else if (Toy is IAnalogAlphaToy)
                                    {
                                        AnalogAlphaValue AAV = new AnalogAlphaValue(((int)((double)TCS.Intensity * 5.3125)).Limit(0, 255));
                                        if (TCS.FadingDownDurationMs > 0 || TCS.FadingUpDurationMs > 0)
                                        {
                                            Effect = new AnalogToyFadeOnOffEffect() { ToyName = Toy.Name, Layer = Layer, FadeActiveDurationMs = TCS.FadingUpDurationMs, FadeInactiveDurationMs = TCS.FadingDownDurationMs, RetriggerBehaviour = RetriggerBehaviourEnum.IgnoreRetrigger, FadeMode = FadeModeEnum.CurrentToDefined, ActiveValue = AAV, InactiveValue = new AnalogAlphaValue(0, 0) };
                                        }
                                        else
                                        {
                                            Effect = new AnalogToyOnOffEffect() { ToyName = Toy.Name, Layer = Layer, ActiveValue = AAV, InactiveValue = new AnalogAlphaValue(0, 0) };
                                        }

                                    }
                                    if (Effect != null)
                                    {
                                        Effect.Name = "Ledwiz {0:00} Column {1:00} Setting {2:00} {3}".Build(new object[] { LedWizNr, TCC.Number, SettingNumber, Effect.GetType().Name });
                                        MakeEffectNameUnique(Effect, Table);

                                        Table.Effects.Add(Effect);

                                        if (TCS.Blink != 0)
                                        {
                                            Effect = new BlinkEffect() { Name = "Ledwiz {0:00} Column {1:00} Setting {2:00} BlinkEffect".Build(LedWizNr, TCC.Number, SettingNumber), TargetEffectName = Effect.Name, DurationActiveMs = TCS.BlinkIntervalMs, DurationInactiveMs = TCS.BlinkIntervalMs };
                                            MakeEffectNameUnique(Effect, Table);
                                            Table.Effects.Add(Effect);
                                        }

                                        if (TCS.DurationMs > 0 || TCS.Blink > 0)
                                        {
                                            int Duration = (TCS.DurationMs > 0 ? TCS.DurationMs : (TCS.Blink * 2 - 1) * TCS.BlinkIntervalMs + 1);
                                            Effect = new DurationEffect() { Name = "Ledwiz {0:00} Column {1:00} Setting {2:00} DurationEffect".Build(LedWizNr, TCC.Number, SettingNumber), TargetEffectName = Effect.Name, DurationMs = Duration, RetriggerBehaviour = RetriggerBehaviourEnum.RestartEffect };
                                            MakeEffectNameUnique(Effect, Table);
                                            Table.Effects.Add(Effect);
                                        }
                                        if (TCS.MinDurationMs > 0 || (Toy is IRGBAToy && EffectRGBMinDurationMs > 0) || (!(Toy is IRGBAToy) && EffectMinDurationMs > 0))
                                        {
                                            string N = (TCS.MinDurationMs > 0 ? "MinDuratonEffect" : "DefaultMinDurationEffect");
                                            int Min = (TCS.MinDurationMs > 0 ? TCS.MinDurationMs : (Toy is IRGBAToy ? EffectRGBMinDurationMs : EffectMinDurationMs));
                                            Effect = new MinDurationEffect() { Name = "Ledwiz {0:00} Column {1:00} Setting {2:00} {3}".Build(new object[] { LedWizNr, TCC.Number, SettingNumber, N }), TargetEffectName = Effect.Name, MinDurationMs = Min };
                                            MakeEffectNameUnique(Effect, Table);
                                            Table.Effects.Add(Effect);
                                        }


                                        if (TCS.WaitDurationMs > 0)
                                        {
                                            Effect = new DelayEffect() { Name = "Ledwiz {0:00} Column {1:00} Setting {2:00} DelayEffect".Build(LedWizNr, TCC.Number, SettingNumber), TargetEffectName = Effect.Name, DelayMs = TCS.WaitDurationMs };
                                            MakeEffectNameUnique(Effect, Table);
                                            Table.Effects.Add(Effect);
                                        }

                                        switch (TCS.OutputControl)
                                        {
                                            case OutputControlEnum.FixedOn:
                                                Table.AssignedStaticEffects.Add(new AssignedEffect(Effect.Name));
                                                break;
                                            case OutputControlEnum.Controlled:
                                                if (!Table.TableElements.Contains(TCS.TableElementType, TCS.TableElementNumber))
                                                {
                                                    Table.TableElements.UpdateState(TCS.TableElementType, TCS.TableElementNumber, 0);
                                                }
                                                Table.TableElements[TCS.TableElementType, TCS.TableElementNumber].AssignedEffects.Add(new AssignedEffect(Effect.Name));
                                                break;
                                            case OutputControlEnum.FixedOff:
                                            default:
                                                break;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }



        private void MakeEffectNameUnique(IEffect Effect, Table.Table Table)
        {
            if (Table.Effects.Contains(Effect.Name))
            {
                int Cnt = 1;
                while (Table.Effects.Contains("{0} {1}".Build(Effect.Name, Cnt)))
                {
                    Cnt++;
                }
                Effect.Name = "{0} {1}".Build(Effect.Name, Cnt);
            }
        }





        private Dictionary<int, Dictionary<int, IToy>> SetupCabinet(Dictionary<int, TableConfig> TableConfigDict, Cabinet Cabinet)
        {
            Dictionary<int, Dictionary<int, IToy>> ToyAssignments = new Dictionary<int, Dictionary<int, IToy>>();

            Dictionary<int, LedWizEquivalent> LedWizEquivalentDict = new Dictionary<int, LedWizEquivalent>();
            foreach (IToy T in Cabinet.Toys.Where(Toy => Toy is LedWizEquivalent).ToList())
            {
                LedWizEquivalentDict.Add(((LedWizEquivalent)T).LedWizNumber, (LedWizEquivalent)T);
            }

            foreach (KeyValuePair<int, TableConfig> KV in TableConfigDict)
            {
                int LedWizNr = KV.Key;
                ToyAssignments.Add(LedWizNr, new Dictionary<int, IToy>());

                TableConfig TC = KV.Value;
                if (LedWizEquivalentDict.ContainsKey(LedWizNr))
                {
                    LedWizEquivalent LWE = LedWizEquivalentDict[LedWizNr];

                    foreach (TableConfigColumn TCC in TC.Columns)
                    {
                        IToy TargetToy = null;
                        switch (TCC.RequiredOutputCount)
                        {
                            case 3:
                                //RGB Led

                                if (LWE.Outputs.Any(Output => Output.LedWizEquivalentOutputNumber == TCC.FirstOutputNumber) && LWE.Outputs.Any(Output => Output.LedWizEquivalentOutputNumber == TCC.FirstOutputNumber + 1) && LWE.Outputs.Any(Output => Output.LedWizEquivalentOutputNumber == TCC.FirstOutputNumber + 2))
                                {
                                    //Try to get the toy 
                                    try
                                    {
                                        //Toy does already exist
                                        TargetToy = (IToy)Cabinet.Toys.First(Toy => Toy is IRGBAToy && ((IRGBAToy)Toy).OutputNameRed == LWE.Outputs.First(Output => Output.LedWizEquivalentOutputNumber == TCC.FirstOutputNumber).OutputName && ((IRGBAToy)Toy).OutputNameGreen == LWE.Outputs.First(Output => Output.LedWizEquivalentOutputNumber == TCC.FirstOutputNumber + 1).OutputName && ((IRGBAToy)Toy).OutputNameBlue == LWE.Outputs.First(Output => Output.LedWizEquivalentOutputNumber == TCC.FirstOutputNumber + 2).OutputName);

                                    }
                                    catch
                                    {
                                        //Toy does not exist. Create toyname and toy
                                        string ToyName = "LedWiz {0:00} Column {1:00}".Build(LedWizNr, TCC.Number);
                                        if (Cabinet.Toys.Contains(ToyName))
                                        {
                                            int Cnt = 1;
                                            while (Cabinet.Toys.Contains("{0} {1}".Build(ToyName, Cnt)))
                                            {
                                                Cnt++;
                                            }
                                            ToyName = "{0} {1}".Build(ToyName, Cnt);
                                        }
                                        TargetToy = (IToy)new RGBAToy() { Name = ToyName, OutputNameRed = LWE.Outputs.First(Output => Output.LedWizEquivalentOutputNumber == TCC.FirstOutputNumber).OutputName, OutputNameGreen = LWE.Outputs.First(Output => Output.LedWizEquivalentOutputNumber == TCC.FirstOutputNumber + 1).OutputName, OutputNameBlue = LWE.Outputs.First(Output => Output.LedWizEquivalentOutputNumber == TCC.FirstOutputNumber + 2).OutputName };
                                        Cabinet.Toys.Add(TargetToy);
                                    }

                                    ToyAssignments[LedWizNr].Add(TCC.Number, TargetToy);
                                }

                                break;
                            case 1:
                                //Single output

                                //Analog output
                                if (LWE.Outputs.Any(Output => Output.LedWizEquivalentOutputNumber == TCC.FirstOutputNumber))
                                {
                                    try
                                    {
                                        TargetToy = Cabinet.Toys.First(Toy => Toy is IAnalogAlphaToy && ((IAnalogAlphaToy)Toy).OutputName == LWE.Outputs.First(Output => Output.LedWizEquivalentOutputNumber == TCC.FirstOutputNumber).OutputName);
                                    }
                                    catch
                                    {
                                        //Toy does not exist. Create toyname and toy
                                        string ToyName = "LedWiz {0:00} Column {1:00}".Build(LedWizNr, TCC.Number);

                                        if (Cabinet.Toys.Contains(ToyName))
                                        {
                                            int Cnt = 1;
                                            while (Cabinet.Toys.Contains("{0} {1}".Build(ToyName, Cnt)))
                                            {
                                                Cnt++;
                                            }
                                            ToyName = "{0} {1}".Build(ToyName, Cnt);
                                        }
                                        TargetToy = (IToy)new AnalogAlphaToy() { Name = ToyName, OutputName = LWE.Outputs.First(Output => Output.LedWizEquivalentOutputNumber == TCC.FirstOutputNumber).OutputName };
                                        Cabinet.Toys.Add(TargetToy);
                                    }
                                    ToyAssignments[LedWizNr].Add(TCC.Number, TargetToy);
                                }



                                break;

                            default:
                                //Unknow value
                                Log.Warning("A illegal number ({0}) of required outputs has been found in a table config colum {0} for ledcontrol nr. {2}. Cant configure toy.".Build(TCC.RequiredOutputCount, TCC.Number, LedWizNr));
                                break;
                        }
                    }

                }
            }
            return ToyAssignments;
        }


    }
}
