Built in Effects  {#fx_builtin}
==========
\section use_DirectOutput_FX_AnalogToyFX_AnalogToyFadeOnOffEffect AnalogToyFadeOnOffEffect

\subsection use_DirectOutput_FX_AnalogToyFX_AnalogToyFadeOnOffEffect_summary Summary

A effect fading the output value of a AnalogToy object to a active or inactive value. The fading is controlled by the value property (0, not 0) of the TableElementData parameter of the Trigger method.
\image html FX_FadeOnOff.png "FadeOnOff effect"



\subsection use_DirectOutput_FX_AnalogToyFX_AnalogToyFadeOnOffEffect_samplexml Sample XML

A configuration section for AnalogToyFadeOnOffEffect might resemble the following structure:

~~~~~~~~~~~~~{.xml}
<AnalogToyFadeOnOffEffect>
  <Name>Name of AnalogToyFadeOnOffEffect</Name>
  <ToyName>Name of Toy</ToyName>
  <Layer>0</Layer>
  <RetriggerBehaviour>RestartEffect</RetriggerBehaviour>
  <FadeMode>DefinedToDefined</FadeMode>
  <FadeInactiveDurationMs>500</FadeInactiveDurationMs>
  <FadeActiveDurationMs>500</FadeActiveDurationMs>
  <ActiveValue>
    <Value>0</Value>
    <Alpha>0</Alpha>
  </ActiveValue>
  <InactiveValue>
    <Value>0</Value>
    <Alpha>0</Alpha>
  </InactiveValue>
</AnalogToyFadeOnOffEffect>
~~~~~~~~~~~~~
\subsection use_DirectOutput_FX_AnalogToyFX_AnalogToyFadeOnOffEffect_properties Properties

AnalogToyFadeOnOffEffect has the following 9 configurable properties:

\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyFadeOnOffEffect_ActiveValue ActiveValue

The active value between 0 and 255.



\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyFadeOnOffEffect_FadeActiveDurationMs FadeActiveDurationMs

The fading duration in milliseconds.



\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyFadeOnOffEffect_FadeInactiveDurationMs FadeInactiveDurationMs

The fading duration in milliseconds.



\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyFadeOnOffEffect_FadeMode FadeMode

CurrentToDefinedColor or DefinedColor



The property FadeMode accepts the following values:

CurrentToDefined
* DefinedToDefined

__Valid values__

The property FadeMode accepts the following values:

CurrentToDefined
* DefinedToDefined
\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyFadeOnOffEffect_InactiveValue InactiveValue

The inactive value between 0 and 255.



\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyFadeOnOffEffect_Layer Layer

The layer number.



\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyFadeOnOffEffect_Name Name

The name of the item.



\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyFadeOnOffEffect_RetriggerBehaviour RetriggerBehaviour

Valid values are RestartEffect or IgnoreRetrigger.



The property RetriggerBehaviour accepts the following values:

RestartEffect
* IgnoreRetrigger

__Valid values__

The property RetriggerBehaviour accepts the following values:

RestartEffect
* IgnoreRetrigger
\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyFadeOnOffEffect_ToyName ToyName

The name of the AnalogToy.



\section use_DirectOutput_FX_AnalogToyFX_AnalogToyOnOffEffect AnalogToyOnOffEffect

\subsection use_DirectOutput_FX_AnalogToyFX_AnalogToyOnOffEffect_summary Summary

A basic effect setting the output of a AnalogToy object to a active or inactive value, based on value property (0, not 0) of the TableElementData parameter of the Trigger method.



\subsection use_DirectOutput_FX_AnalogToyFX_AnalogToyOnOffEffect_samplexml Sample XML

A configuration section for AnalogToyOnOffEffect might resemble the following structure:

~~~~~~~~~~~~~{.xml}
<AnalogToyOnOffEffect>
  <Name>Name of AnalogToyOnOffEffect</Name>
  <ToyName>Name of Toy</ToyName>
  <Layer>0</Layer>
  <ActiveValue>
    <Value>0</Value>
    <Alpha>0</Alpha>
  </ActiveValue>
  <InactiveValue>
    <Value>0</Value>
    <Alpha>0</Alpha>
  </InactiveValue>
</AnalogToyOnOffEffect>
~~~~~~~~~~~~~
\subsection use_DirectOutput_FX_AnalogToyFX_AnalogToyOnOffEffect_properties Properties

AnalogToyOnOffEffect has the following 5 configurable properties:

\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyOnOffEffect_ActiveValue ActiveValue

The active value between 0 and 255.



\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyOnOffEffect_InactiveValue InactiveValue

The inactive value between 0 and 255.



\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyOnOffEffect_Layer Layer

The layer number.



\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyOnOffEffect_Name Name

The name of the item.



\subsubsection DirectOutput_FX_AnalogToyFX_AnalogToyOnOffEffect_ToyName ToyName

The name of the AnalogToy.



\section use_DirectOutput_FX_ListFX_ListEffect ListEffect

\subsection use_DirectOutput_FX_ListFX_ListEffect_summary Summary

This effect triggers a list of other effect when it is triggered.<br />

\warning Be careful not to add ListEffect objects which finnaly contain a reference to the instance you're working with. This will create a recursive loop which never exit!.



\subsection use_DirectOutput_FX_ListFX_ListEffect_samplexml Sample XML

A configuration section for ListEffect might resemble the following structure:

~~~~~~~~~~~~~{.xml}
<ListEffect>
  <Name>Name of ListEffect</Name>
  <AssignedEffects>
    <AssignedEffect>
      <EffectName>Name of Effect</EffectName>
    </AssignedEffect>
    <AssignedEffect>
      <EffectName>Name of Effect</EffectName>
    </AssignedEffect>
    <AssignedEffect>
      <EffectName>Name of Effect</EffectName>
    </AssignedEffect>
  </AssignedEffects>
</ListEffect>
~~~~~~~~~~~~~
\subsection use_DirectOutput_FX_ListFX_ListEffect_properties Properties

ListEffect has the following 2 configurable properties:

\subsubsection DirectOutput_FX_ListFX_ListEffect_AssignedEffects AssignedEffects

The list of effects assigned to the ListEffect.



__Nested Properties__

The following nested propteries exist for AssignedEffects:
* __EffectName__<br/>  The name of the assigned effect.




\subsubsection DirectOutput_FX_ListFX_ListEffect_Name Name

The name of the item.



\section use_DirectOutput_FX_NullFX_NullEffect NullEffect

\subsection use_DirectOutput_FX_NullFX_NullEffect_summary Summary

The NullEffect is a empty effect no doing anything.



\subsection use_DirectOutput_FX_NullFX_NullEffect_samplexml Sample XML

A configuration section for NullEffect might resemble the following structure:

~~~~~~~~~~~~~{.xml}
<NullEffect>
  <Name>Name of NullEffect</Name>
</NullEffect>
~~~~~~~~~~~~~
\subsection use_DirectOutput_FX_NullFX_NullEffect_properties Properties

NullEffect has the following 1 configurable properties:

\subsubsection DirectOutput_FX_NullFX_NullEffect_Name Name

The name of the item.



\section use_DirectOutput_FX_RGBAFX_RGBAFadeOnOffEffect RGBAFadeOnOffEffect

\subsection use_DirectOutput_FX_RGBAFX_RGBAFadeOnOffEffect_summary Summary

This RGBA effect fades the color of a RGBA toys towards a defined target color based on the state (not 0, 0) of the triggering table element.
\image html FX_FadeOnOff.png "FadeOnOff effect"



\subsection use_DirectOutput_FX_RGBAFX_RGBAFadeOnOffEffect_samplexml Sample XML

A configuration section for RGBAFadeOnOffEffect might resemble the following structure:

~~~~~~~~~~~~~{.xml}
<RGBAFadeOnOffEffect>
  <Name>Name of RGBAFadeOnOffEffect</Name>
  <ToyName>Name of Toy</ToyName>
  <Layer>0</Layer>
  <RetriggerBehaviour>RestartEffect</RetriggerBehaviour>
  <FadeMode>DefinedToDefined</FadeMode>
  <FadeInactiveDurationMs>500</FadeInactiveDurationMs>
  <FadeActiveDurationMs>500</FadeActiveDurationMs>
  <ActiveColor>
    <HexColor>#00000000</HexColor>
  </ActiveColor>
  <InactiveColor>
    <HexColor>#00000000</HexColor>
  </InactiveColor>
</RGBAFadeOnOffEffect>
~~~~~~~~~~~~~
\subsection use_DirectOutput_FX_RGBAFX_RGBAFadeOnOffEffect_properties Properties

RGBAFadeOnOffEffect has the following 9 configurable properties:

\subsubsection DirectOutput_FX_RGBAFX_RGBAFadeOnOffEffect_ActiveColor ActiveColor

The RGBA color to be used when the effect is active.



__Nested Properties__

The following nested propteries exist for ActiveColor:
* __HexColor__<br/>  6 digit hexadecimal color code with leading  #(e.g. #ff0000 for red).


\subsubsection DirectOutput_FX_RGBAFX_RGBAFadeOnOffEffect_FadeActiveDurationMs FadeActiveDurationMs

The fading duration in milliseconds.



\subsubsection DirectOutput_FX_RGBAFX_RGBAFadeOnOffEffect_FadeInactiveDurationMs FadeInactiveDurationMs

The fading duration in milliseconds.



\subsubsection DirectOutput_FX_RGBAFX_RGBAFadeOnOffEffect_FadeMode FadeMode

CurrentToDefinedColor or DefinedColor



The property FadeMode accepts the following values:

CurrentToDefined
* DefinedToDefined

__Valid values__

The property FadeMode accepts the following values:

CurrentToDefined
* DefinedToDefined
\subsubsection DirectOutput_FX_RGBAFX_RGBAFadeOnOffEffect_InactiveColor InactiveColor

The RGBA color to be used when the effect is inactive.



__Nested Properties__

The following nested propteries exist for InactiveColor:
* __HexColor__<br/>  6 digit hexadecimal color code with leading  #(e.g. #ff0000 for red).


\subsubsection DirectOutput_FX_RGBAFX_RGBAFadeOnOffEffect_Layer Layer

The layer number.



\subsubsection DirectOutput_FX_RGBAFX_RGBAFadeOnOffEffect_Name Name

The name of the item.



\subsubsection DirectOutput_FX_RGBAFX_RGBAFadeOnOffEffect_RetriggerBehaviour RetriggerBehaviour

Valid values are RestartEffect or IgnoreRetrigger.



The property RetriggerBehaviour accepts the following values:

RestartEffect
* IgnoreRetrigger

__Valid values__

The property RetriggerBehaviour accepts the following values:

RestartEffect
* IgnoreRetrigger
\subsubsection DirectOutput_FX_RGBAFX_RGBAFadeOnOffEffect_ToyName ToyName

The name of the RGBAToy.



\section use_DirectOutput_FX_RGBAFX_RGBAOnOffEffect RGBAOnOffEffect

\subsection use_DirectOutput_FX_RGBAFX_RGBAOnOffEffect_summary Summary

A basic RBA effect which sets the color of a layer of a RGBA toy to a specified color based on the state (not 0, 0) of the triggering table element.
\image html FX_OnOff.png "OnOff effect"



\subsection use_DirectOutput_FX_RGBAFX_RGBAOnOffEffect_samplexml Sample XML

A configuration section for RGBAOnOffEffect might resemble the following structure:

~~~~~~~~~~~~~{.xml}
<RGBAOnOffEffect>
  <Name>Name of RGBAOnOffEffect</Name>
  <ToyName>Name of Toy</ToyName>
  <Layer>0</Layer>
  <ActiveColor>
    <HexColor>#00000000</HexColor>
  </ActiveColor>
  <InactiveColor>
    <HexColor>#00000000</HexColor>
  </InactiveColor>
</RGBAOnOffEffect>
~~~~~~~~~~~~~
\subsection use_DirectOutput_FX_RGBAFX_RGBAOnOffEffect_properties Properties

RGBAOnOffEffect has the following 5 configurable properties:

\subsubsection DirectOutput_FX_RGBAFX_RGBAOnOffEffect_ActiveColor ActiveColor

The RGBA color to be used when the effect is active.



__Nested Properties__

The following nested propteries exist for ActiveColor:
* __HexColor__<br/>  6 digit hexadecimal color code with leading  #(e.g. #ff0000 for red).


\subsubsection DirectOutput_FX_RGBAFX_RGBAOnOffEffect_InactiveColor InactiveColor

The RGBA color to be used when the effect is inactive.



__Nested Properties__

The following nested propteries exist for InactiveColor:
* __HexColor__<br/>  6 digit hexadecimal color code with leading  #(e.g. #ff0000 for red).


\subsubsection DirectOutput_FX_RGBAFX_RGBAOnOffEffect_Layer Layer

The layer number.



\subsubsection DirectOutput_FX_RGBAFX_RGBAOnOffEffect_Name Name

The name of the item.



\subsubsection DirectOutput_FX_RGBAFX_RGBAOnOffEffect_ToyName ToyName

The name of the RGBAToy.



\section use_DirectOutput_FX_TimmedFX_BlinkEffect BlinkEffect

\subsection use_DirectOutput_FX_TimmedFX_BlinkEffect_summary Summary

Blink effect which triggers a TargetEffect at specified intervalls with active (org value of TableElementData used in Trigger method is used to trigger the TargetEffect) and inactive (uses 0 as the Value of the TableElementData to trigger the TargetEffect) values.<br />
\image html FX_Blink.png "Blink effect"



\subsection use_DirectOutput_FX_TimmedFX_BlinkEffect_samplexml Sample XML

A configuration section for BlinkEffect might resemble the following structure:

~~~~~~~~~~~~~{.xml}
<BlinkEffect>
  <Name>Name of BlinkEffect</Name>
  <TargetEffectName>Name of TargetEffect</TargetEffectName>
  <DurationActiveMs>500</DurationActiveMs>
  <DurationInactiveMs>500</DurationInactiveMs>
</BlinkEffect>
~~~~~~~~~~~~~
\subsection use_DirectOutput_FX_TimmedFX_BlinkEffect_properties Properties

BlinkEffect has the following 4 configurable properties:

\subsubsection DirectOutput_FX_TimmedFX_BlinkEffect_DurationActiveMs DurationActiveMs

The active duration of the blinking in milliseconds.



\subsubsection DirectOutput_FX_TimmedFX_BlinkEffect_DurationInactiveMs DurationInactiveMs

The inactive duration of the blinking in milliseconds.



\subsubsection DirectOutput_FX_TimmedFX_BlinkEffect_Name Name

The name of the item.



\subsubsection DirectOutput_FX_TimmedFX_BlinkEffect_TargetEffectName TargetEffectName

Name of the target effect.<br />
Triggers EffectNameChanged if value is changed.



\section use_DirectOutput_FX_TimmedFX_DelayEffect DelayEffect

\subsection use_DirectOutput_FX_TimmedFX_DelayEffect_summary Summary

The effect fires a assigned target effect after a specified delay.<br />
The original values supplied when the effect is triggered are forwarded to the target effect.<br />
\image html FX_Delay.png "Delay effect"



\subsection use_DirectOutput_FX_TimmedFX_DelayEffect_samplexml Sample XML

A configuration section for DelayEffect might resemble the following structure:

~~~~~~~~~~~~~{.xml}
<DelayEffect>
  <Name>Name of DelayEffect</Name>
  <TargetEffectName>Name of TargetEffect</TargetEffectName>
  <DelayMs>0</DelayMs>
</DelayEffect>
~~~~~~~~~~~~~
\subsection use_DirectOutput_FX_TimmedFX_DelayEffect_properties Properties

DelayEffect has the following 3 configurable properties:

\subsubsection DirectOutput_FX_TimmedFX_DelayEffect_DelayMs DelayMs

The delay in milliseconds.



\subsubsection DirectOutput_FX_TimmedFX_DelayEffect_Name Name

The name of the item.



\subsubsection DirectOutput_FX_TimmedFX_DelayEffect_TargetEffectName TargetEffectName

Name of the target effect.<br />
Triggers EffectNameChanged if value is changed.



\section use_DirectOutput_FX_TimmedFX_DurationEffect DurationEffect

\subsection use_DirectOutput_FX_TimmedFX_DurationEffect_summary Summary

Duration effect which triggers a specified target effect for a specified duration.<br />
When this effect is triggered it triggers the target effect immediately with the same data it has received. After the specified duration it calls trigger on the target effect again with data for the same table elmenet, but with the value changed to 0.<br />
\image html FX_Duration.png "Duration effect"



\subsection use_DirectOutput_FX_TimmedFX_DurationEffect_samplexml Sample XML

A configuration section for DurationEffect might resemble the following structure:

~~~~~~~~~~~~~{.xml}
<DurationEffect>
  <Name>Name of DurationEffect</Name>
  <TargetEffectName>Name of TargetEffect</TargetEffectName>
  <RetriggerBehaviour>RestartEffect</RetriggerBehaviour>
  <DurationMs>500</DurationMs>
</DurationEffect>
~~~~~~~~~~~~~
\subsection use_DirectOutput_FX_TimmedFX_DurationEffect_properties Properties

DurationEffect has the following 4 configurable properties:

\subsubsection DirectOutput_FX_TimmedFX_DurationEffect_DurationMs DurationMs

The effect duration in milliseconds.



\subsubsection DirectOutput_FX_TimmedFX_DurationEffect_Name Name

The name of the item.



\subsubsection DirectOutput_FX_TimmedFX_DurationEffect_RetriggerBehaviour RetriggerBehaviour

Valid values are RestartEffect (Restarts the duration) or IgnoreRetrigger (keeps the org duration).



The property RetriggerBehaviour accepts the following values:

RestartEffect
* IgnoreRetrigger

__Valid values__

The property RetriggerBehaviour accepts the following values:

RestartEffect
* IgnoreRetrigger
\subsubsection DirectOutput_FX_TimmedFX_DurationEffect_TargetEffectName TargetEffectName

Name of the target effect.<br />
Triggers EffectNameChanged if value is changed.



\section use_DirectOutput_FX_TimmedFX_ExtendDurationEffect ExtendDurationEffect

\subsection use_DirectOutput_FX_TimmedFX_ExtendDurationEffect_summary Summary

The extend duration effect triggers another effect for a duration which is extebnded by the number of milliseconds specified in DurationMs.<br />
This is done by forwarding triggers calls which are seting the effect to active directly to the target effect and delaying the forwarding of calls which set the effect to inactive by the number of milliseconds specified in DurationMs.<br />
\image html FX_ExtendDuration.png "ExtendDuration effect"



\subsection use_DirectOutput_FX_TimmedFX_ExtendDurationEffect_samplexml Sample XML

A configuration section for ExtendDurationEffect might resemble the following structure:

~~~~~~~~~~~~~{.xml}
<ExtendDurationEffect>
  <Name>Name of ExtendDurationEffect</Name>
  <TargetEffectName>Name of TargetEffect</TargetEffectName>
  <DurationMs>500</DurationMs>
</ExtendDurationEffect>
~~~~~~~~~~~~~
\subsection use_DirectOutput_FX_TimmedFX_ExtendDurationEffect_properties Properties

ExtendDurationEffect has the following 3 configurable properties:

\subsubsection DirectOutput_FX_TimmedFX_ExtendDurationEffect_DurationMs DurationMs

The extended duration in milliseconds.



\subsubsection DirectOutput_FX_TimmedFX_ExtendDurationEffect_Name Name

The name of the item.



\subsubsection DirectOutput_FX_TimmedFX_ExtendDurationEffect_TargetEffectName TargetEffectName

Name of the target effect.<br />
Triggers EffectNameChanged if value is changed.



\section use_DirectOutput_FX_TimmedFX_MinDurationEffect MinDurationEffect

\subsection use_DirectOutput_FX_TimmedFX_MinDurationEffect_summary Summary

This effect enforces a minimum duration on the effect calls.<br />
Calls which are setting a effect to active (having a trigger value which is not equal 0 or null) are forwarded directly to the TargetEffect.<br />
Calls setting the effect to inactive (having a trigger value of 0) are only forwarded to the TargetEffect after the specified minimum duration has expired.<br />
\image html FX_MinDuration.png "MinDuration effect"



\subsection use_DirectOutput_FX_TimmedFX_MinDurationEffect_samplexml Sample XML

A configuration section for MinDurationEffect might resemble the following structure:

~~~~~~~~~~~~~{.xml}
<MinDurationEffect>
  <Name>Name of MinDurationEffect</Name>
  <TargetEffectName>Name of TargetEffect</TargetEffectName>
  <RetriggerBehaviour>RestartEffect</RetriggerBehaviour>
  <MinDurationMs>500</MinDurationMs>
</MinDurationEffect>
~~~~~~~~~~~~~
\subsection use_DirectOutput_FX_TimmedFX_MinDurationEffect_properties Properties

MinDurationEffect has the following 4 configurable properties:

\subsubsection DirectOutput_FX_TimmedFX_MinDurationEffect_MinDurationMs MinDurationMs

The minimal effect duration in milliseconds.



\subsubsection DirectOutput_FX_TimmedFX_MinDurationEffect_Name Name

The name of the item.



\subsubsection DirectOutput_FX_TimmedFX_MinDurationEffect_RetriggerBehaviour RetriggerBehaviour

Valid values are RestartEffect (Restarts the minimal duration) or IgnoreRetrigger (keeps the org duration).



The property RetriggerBehaviour accepts the following values:

RestartEffect
* IgnoreRetrigger

__Valid values__

The property RetriggerBehaviour accepts the following values:

RestartEffect
* IgnoreRetrigger
\subsubsection DirectOutput_FX_TimmedFX_MinDurationEffect_TargetEffectName TargetEffectName

Name of the target effect.<br />
Triggers EffectNameChanged if value is changed.



