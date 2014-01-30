// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AudioSampleRateValidator.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 9:56 AM</created>
//  <updated>01/30/2014 9:59 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;

#endregion

namespace VML.Encoding.Model.Validation.Validators
{
    public class AudioSampleRateValidator : BaseValidator<int>
    {
        #region Constants and Fields

        private static readonly Dictionary<FormatOutput, int[]> Rules = new Dictionary
            <FormatOutput, int[]>
            {
                { FormatOutput.threegp, new[] { 8000 } },
                { FormatOutput.flv, new[] { 11025, 22050, 44100 } },
                { FormatOutput.mp3, new[] { 11025, 22050, 44100 } },
                { FormatOutput.ogg, new[] { 16000, 32000, 44100, 22050, 11025, 19200 } },
                { FormatOutput.webm, new[] { 16000, 32000, 44100, 22050, 11025, 19200 } },
                { FormatOutput.wmv, new[] { 11025, 22050, 32000, 44100, 48000 } },
                { FormatOutput.wma, new[] { 11025, 22050, 32000, 44100, 48000 } },
                { FormatOutput.zune, new[] { 11025, 22050, 32000, 44100, 48000 } },
                { FormatOutput.mpeg2, new[] { 44100, 48000 } },
            };

        #endregion

        #region Constructors and Destructors

        public AudioSampleRateValidator(string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
        }

        #endregion

        #region Properties

        protected override string DefaultMessageTemplate
        {
            get
            {
                return "You must set a valid audio sample rate for the corresponding output value.";
            }
        }

        #endregion

        #region Methods

        protected override void DoValidate(
            int objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            Format target = (Format)currentTarget;

            bool validCodec = !Rules.ContainsKey(target.Output)
                              || Rules[target.Output].Contains(objectToValidate);

            if (validCodec)
            {
                return;
            }

            AddInvalidResult(key, validationResults);
        }

        #endregion
    }
}