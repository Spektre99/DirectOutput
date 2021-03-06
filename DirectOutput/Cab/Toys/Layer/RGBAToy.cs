﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DirectOutput.Cab.Out;
using DirectOutput.Cab.Color;

namespace DirectOutput.Cab.Toys.Layer
{
    /// <summary>
    /// Thie RGBAToy controls RGB leds and other gadgets displaying RGB colors.<br/><br/>
    /// The RGBAToy has multilayer support with alpha channels. This allows the effects targeting RGBAToys to send their data to different layers. 
    /// Values in a layer do also have a alpha/transparency channel which will allow us to blend the colors/values in the various layers (e.g. if  a bottom layer is blue and top is a semi transparent red, you will get some mix of both or if one of the two blinks you get changing colors).<br/>
    /// The following picture might give you a clearer idea how the layers with their alpha channels work:
    /// 
    /// \image html LayersRGBA.png "RGBA Layers"
    /// </summary>
    public class RGBAToy : ToyBaseUpdatable, IRGBAToy
    {

        #region Layers
        /// <summary>
        /// Gets the dictionary of RGBALayers.
        /// </summary>
        /// <value>
        /// The layers dictionary.
        /// </value>
        [System.Xml.Serialization.XmlIgnore]
        public RGBALayerDictionary Layers { get; private set; }



        #endregion



        #region Outputs
        private IOutput _OutputRed;

        /// <summary>
        /// Name of the IOutput for red.
        /// </summary>
        public string OutputNameRed { get; set; }

        private IOutput _OutputGreen;

        /// <summary>
        /// Name of the IOutput for green.
        /// </summary>
        public string OutputNameGreen { get; set; }

        private IOutput _OutputBlue;

        /// <summary>
        /// Name of the IOutput for blue.
        /// </summary>
        public string OutputNameBlue { get; set; }

        #endregion


        private Cabinet _Cabinet;
        #region Init
        /// <summary>
        /// Initializes the RGBALed toy.
        /// </summary>
        /// <param name="Cabinet"><see cref="Cabinet"/> object to which the <see cref="RGBAToy"/> belongs.</param>
        public override void Init(Cabinet Cabinet)
        {
            _Cabinet = Cabinet;
            InitOutputs(Cabinet);
        }

        private void InitOutputs(Cabinet Cabinet)
        {
            if (Cabinet.Outputs.Contains(OutputNameRed))
            {
                _OutputRed = Cabinet.Outputs[OutputNameRed];
            }
            else
            {
                _OutputRed = null;
            }
            if (Cabinet.Outputs.Contains(OutputNameGreen))
            {
                _OutputGreen = Cabinet.Outputs[OutputNameGreen];
            }
            else
            {
                _OutputGreen = null;
            }
            if (Cabinet.Outputs.Contains(OutputNameBlue))
            {
                _OutputBlue = Cabinet.Outputs[OutputNameBlue];
            }
            else
            {
                _OutputBlue = null;
            }
        }
        #endregion

        #region Finish

        /// <summary>
        /// Finishes the RGBALed toy.<br/>
        /// Resets the the toy and releases all references.
        /// </summary>
        public override void Finish()
        {
            Reset();
            _Cabinet = null;
            _OutputRed = null;
            _OutputGreen = null;
            _OutputBlue = null;
        }
        #endregion




        /// <summary>
        /// Updates the outputs of the RGBAToy.
        /// </summary>
        public override void UpdateOutputs()
        {
            RGBColor RGB = Layers.GetResultingColor();
            if (_OutputRed != null)
            {
                _OutputRed.Value = (byte)RGB.Red;
            }
            if (_OutputGreen != null)
            {
                _OutputGreen.Value = (byte)RGB.Green;
            }
            if (_OutputBlue != null)
            {
                _OutputBlue.Value = (byte)RGB.Blue;
            }
        }


        /// <summary>
        /// Clears all layers and sets all outputs to 0 (off).
        /// </summary>
        public override void Reset()
        {
            Layers.Clear();
            _OutputRed.Value = 0;
            _OutputGreen.Value = 0;
            _OutputBlue.Value = 0;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="RGBAToy"/> class.
        /// </summary>
        public RGBAToy()
        {
            Layers = new RGBALayerDictionary();
        }





    }
}
