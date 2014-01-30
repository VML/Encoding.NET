// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingValidatorAttribute.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 9:44 AM</created>
//  <updated>01/30/2014 11:05 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

#endregion

namespace VML.Encoding.Model.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class EncodingValidatorAttribute : ValidatorAttribute
    {
        #region Constants and Fields

        private readonly Type _validatorType;

        #endregion

        #region Constructors and Destructors

        public EncodingValidatorAttribute(Type validatorType)
        {
            _validatorType = validatorType;
        }

        #endregion

        #region Methods

        protected override Validator DoCreateValidator(Type targetType)
        {
            return (Validator)Activator.CreateInstance(_validatorType, MessageTemplate, Tag);
        }

        #endregion
    }
}