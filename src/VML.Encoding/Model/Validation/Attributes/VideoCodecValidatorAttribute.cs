// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ValidVideoCodecAttribute.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 3:04 PM</created>
//  <updated>01/29/2014 4:02 PM by Ben Ramey</updated>
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
    public class VideoCodecValidatorAttribute : ValidatorAttribute
    {
        #region Methods

        protected override Validator DoCreateValidator(Type targetType)
        {
            return new VideoCodecValidator(MessageTemplate, Tag);
        }

        #endregion
    }
}