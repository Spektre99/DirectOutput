﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DirectOutput.Cab.Toys.Layer;
using System.Xml.Serialization;

namespace DirectOutput.FX.AnalogToyFX
{
    /// <summary>
    /// Base class for effects controlling a single AnalogToy object.
    /// </summary>
    public abstract class AnanlogToyEffectBase : EffectBase
    {
        /// <summary>
        /// The table which contains the effect.
        /// </summary>
        protected Table.Table Table;

        private string _ToyName;


        /// <summary>
        /// Name of the AnalogToy.
        /// </summary>
        /// <value>
        /// The name of the AnalogToy.
        /// </value>
        public string ToyName
        {
            get { return _ToyName; }
            set
            {
                if (_ToyName != value)
                {
                    _ToyName = value;
                    Toy = null;
                }
            }
        }


        private int _Layer = 0;

        /// <summary>
        /// Gets or sets the number of the layer for the AnalogToy effect (Default=0).
        /// </summary>
        /// <value>
        /// The layer number.
        /// </value>
        public int Layer
        {
            get { return _Layer; }
            set { _Layer = value; }
        }




        /// <summary>
        /// Refrence to the AnalogToyy specified in the ToyName property.<br/>
        /// If the ToyName property is empty or contains a unknown name or the name of a toy which is not a AnalogToy this property will return null.
        /// </summary>
        [XmlIgnoreAttribute]
        public IAnalogAlphaToy Toy{get;protected set;}

        private void ResolveName(Table.Table Table)
        {

            if (!ToyName.IsNullOrWhiteSpace() && Table.Pinball.Cabinet.Toys.Contains(ToyName))
            {
                if (Table.Pinball.Cabinet.Toys[ToyName] is IAnalogAlphaToy)
                {
                    Toy = (IAnalogAlphaToy)Table.Pinball.Cabinet.Toys[ToyName];
                }

            }
        }

        /// <summary>
        /// Initializes the effect.
        /// </summary>
        /// <param name="Table">Table object containing the effect.</param>
        public override void Init(Table.Table Table)
        {
            this.Table = Table;
            ResolveName(Table);
        }

        /// <summary>
        /// Finish does all necessary cleanupwork before the effect is discarded.
        /// </summary>
        public override void Finish()
        {
            base.Finish();
            Toy = null;
            this.Table = null;
        }
    
    }
}
