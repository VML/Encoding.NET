// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AudioChannelsNumberValidator.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 10:16 AM</created>
//  <updated>01/30/2014 11:05 AM by Ben Ramey</updated>
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
    public class AudioChannelsNumberValidator : BaseValidator<int>
    {
        #region Constants and Fields

        private static readonly Dictionary<FormatOutput, int[]> Rules = new Dictionary
            <FormatOutput, int[]>
            {
                { FormatOutput.threegp, new[] { 1 } },
                { FormatOutput.android, new[] { 1, 2 } },
            };

        #endregion

        #region Constructors and Destructors

        public AudioChannelsNumberValidator(string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
        }

        #endregion

        #region Properties

        protected override string DefaultMessageTemplate
        {
            get
            {
                return "You must set a valid audio channels number for the corresponding output value.";
            }
        }

        #endregion

        #region Methods

        protected override void DoValidate(
            int objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            Format target = (Format)currentTarget;

            bool validCodec = Rules.ContainsKey(target.Output)
                                  ? Rules[target.Output].Contains(objectToValidate)
                                  : objectToValidate > 0;

            if (validCodec)
            {
                return;
            }

            AddInvalidResult(key, validationResults);
        }

        #endregion
    }
}