// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SizeValidator.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 4:07 PM</created>
//  <updated>01/30/2014 11:05 AM by Ben Ramey</updated>
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
    public class SizeValidator : BaseValidator<string>
    {
        #region Constants and Fields

        private static readonly Regex FormatRegex = new Regex(@"^\d+x\d+$");

        private static readonly Dictionary<FormatOutput, Func<string, VideoCodec, bool>> Rules = new Dictionary
            <FormatOutput, Func<string, VideoCodec, bool>>
            {
                {
                    FormatOutput.threegp,
                    (s, codec) =>
                    codec != VideoCodec.h263
                    || new[] { "128x96", "176x144", "352x288", "704x576", "1408x1152" }.Contains(s)
                },
                { FormatOutput.appletv, (s, codec) => s == "710x480" },
                { FormatOutput.zune, (s, codec) => new[] { "320x180", "320x240" }.Contains(s) },
                // all vp6 dimensions must be divisible by 16
                {
                    FormatOutput.flv,
                    (s, codec) => codec != VideoCodec.vp6 || s.Split('x').All(dim => int.Parse(dim) % 16 == 0)
                },
                {
                    FormatOutput.mxf,
                    (s, codec) =>
                    new[] { "720x480", "960x720", "1280x720", "1280x1080", "1440x1080", "1920x1080" }.Contains(s)
                },
            };

        #endregion

        #region Constructors and Destructors

        public SizeValidator(string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
        }

        #endregion

        #region Properties

        protected override string DefaultMessageTemplate
        {
            get
            {
                return "You must set a valid size for the given output format.";
            }
        }

        #endregion

        #region Methods

        protected override void DoValidate(
            string objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            Format target = (Format)currentTarget;

            bool validCodec = FormatRegex.IsMatch(objectToValidate)
                              && DimensionsAreEven(objectToValidate)
                              &&
                              (!Rules.ContainsKey(target.Output)
                               || Rules[target.Output](objectToValidate, target.VideoCodec.Value));

            if (validCodec)
            {
                return;
            }

            AddInvalidResult(key, validationResults);
        }

        private bool DimensionsAreEven(string objectToValidate)
        {
            string[] parts = objectToValidate.Split('x');
            int w = int.Parse(parts[0]);
            int h = int.Parse(parts[1]);

            return w % 2 == 0 && h % 2 == 0;
        }

        #endregion
    }
}