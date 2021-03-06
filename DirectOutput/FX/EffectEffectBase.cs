﻿using System.Xml.Serialization;

namespace DirectOutput.FX
{
    /// <summary>
    /// Base class for effects targeting another effect.
    /// </summary>
    public abstract class EffectEffectBase: EffectBase
    {
        #region EffectName
        private string _TargetEffectName;
        /// <summary>
        /// Name of the target effect.<br/>
        /// Triggers EffectNameChanged if value is changed.
        /// </summary>    
        public string TargetEffectName
        {
            get { return _TargetEffectName; }
            set
            {
                if (_TargetEffectName != value)
                {
                    _TargetEffectName = value;
                    TargetEffect = null;
                    
                }
            }
        }




        #endregion



        #region Effect
        private IEffect _TargetEffect;
        /// <summary>
        /// TargetEffect for the effect (ReadOnly).<br/>
        /// The property is resolved from the TargetEffectName. If TargetEffectName is empty or unknown this property will return null.
        /// </summary>
        [XmlIgnoreAttribute]
        public IEffect TargetEffect
        {
            get
            {
                return _TargetEffect;
            }
            protected set
            {
                _TargetEffect = value;
            }
        }

        private void ResolveEffectName(Table.Table Table)
        {
            if (!TargetEffectName.IsNullOrWhiteSpace() && Table.Effects.Contains(TargetEffectName))
            {
                TargetEffect = Table.Effects[TargetEffectName];
            };

        }

        #endregion

        protected Table.Table Table;

        /// <summary>
        /// Initializes the EffectEffect. <br/>
        /// Resolves the name of the TargetEffect.
        /// </summary>
        /// <param name="Table">Table object containing the effect.</param>
        public override void Init(Table.Table Table)
        {
            this.Table = Table;
            ResolveEffectName(Table);
        }

        /// <summary>
        /// Finishes the EffectEffect.<br/>
        /// Releases the references to the target effect and to the table object.
        /// </summary>
        public override void Finish()
        {
            TargetEffect = null;
            Table = null;
            base.Finish();
        }
    
    }
}
