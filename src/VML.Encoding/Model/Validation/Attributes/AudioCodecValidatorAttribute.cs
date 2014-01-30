// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AudioCodecValidatorAttribute.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 8:44 AM</created>
//  <updated>01/30/2014 8:45 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using VML.Encoding.Model.Validation.Validators;

#endregion

namespace VML.Encoding.Model.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class AudioCodecValidatorAttribute : ValidatorAttribute
    {
        #region Methods

        protected override Validator DoCreateValidator(Type targetType)
        {
            return new AudioCodecValidator(MessageTemplate, Tag);
        }

        #endregion
    }
}