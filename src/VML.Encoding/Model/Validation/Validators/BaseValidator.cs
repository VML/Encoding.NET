// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseValidator.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 3:12 PM</created>
//  <updated>01/29/2014 3:12 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation;

#endregion

namespace VML.Encoding.Model.Validation.Validators
{
    public abstract class BaseValidator<T> : Validator<T>
    {
        public BaseValidator(string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
        }

        protected void AddInvalidResult(string key, ValidationResults validationResults)
        {
            var result = new ValidationResult(
                MessageTemplate ?? DefaultMessageTemplate,
                this,
                key,
                "",
                null);
            validationResults.AddResult(result);
        }
    }
}