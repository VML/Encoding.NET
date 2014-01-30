// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AudioBitrateValidator.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 9:14 AM</created>
//  <updated>01/30/2014 9:51 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;

#endregion

namespace VML.Encoding.Model.Validation.Validators
{
    public class AudioBitrateValidator : BaseValidator<string>
    {
        #region Constants and Fields

        private static readonly Regex OtherOutputRule = new Regex(@"^\d+k$");

        private static readonly Dictionary<FormatOutput, string[]> Rules = new Dictionary
            <FormatOutput, string[]>
            {
                { FormatOutput.threegp, new[] { "4.75k", "5.15k", "5.9k", "6.7k", "7.4k", "7.95k", "10.2k", "12.2K" } },
                {
                    FormatOutput.flv,
                    new[]
                        {
                            "32k", "40k", "48k", "56k", "64k", "80k", "96k", "112k", "128k", "144k", "160k", "192k",
                            "224k", "256k", "320k"
                        }
                },
                {
                    FormatOutput.wmv,
                    new[]
                        {
                            "32k", "40k", "48k", "56k", "64k", "80k", "96k", "112k", "128k", "144k", "160k", "192k",
                            "224k", "256k", "320k"
                        }
                },
                {
                    FormatOutput.mp3,
                    new[]
                        {
                            "32k", "40k", "48k", "56k", "64k", "80k", "96k", "112k", "128k", "144k", "160k", "192k",
                            "224k", "256k", "320k"
                        }
                },
                {
                    FormatOutput.wma,
                    new[]
                        {
                            "32k", "40k", "48k", "56k", "64k", "80k", "96k", "112k", "128k", "144k", "160k", "192k",
                            "224k", "256k", "320k"
                        }
                },
                {
                    FormatOutput.zune,
                    new[]
                        {
                            "32k", "40k", "48k", "56k", "64k", "80k", "96k", "112k", "128k", "144k", "160k", "192k",
                            "224k", "256k", "320k"
                        }
                },
                {
                    FormatOutput.ogg,
                    new[] { "45k", "64k", "80k", "96k", "112k", "128k", "160k", "192k", "224k", "256k", "320k", "500k" }
                },
                {
                    FormatOutput.webm,
                    new[] { "45k", "64k", "80k", "96k", "112k", "128k", "160k", "192k", "224k", "256k", "320k", "500k" }
                },
            };

        #endregion

        #region Constructors and Destructors

        public AudioBitrateValidator(string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
        }

        #endregion

        #region Properties

        protected override string DefaultMessageTemplate
        {
            get
            {
                return "You must set a valid audio bitrate for the corresponding output value.";
            }
        }

        #endregion

        #region Methods

        protected override void DoValidate(
            string objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            Format target = (Format)currentTarget;

            bool validCodec = Rules.ContainsKey(target.Output)
                                  ? Rules[target.Output].Contains(objectToValidate)
                                  : OtherOutputRule.IsMatch(objectToValidate);

            if (validCodec)
            {
                return;
            }

            AddInvalidResult(key, validationResults);
        }

        #endregion
    }
}