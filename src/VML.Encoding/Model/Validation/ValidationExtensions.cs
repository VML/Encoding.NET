// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ValidationExtensions.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/28/2014 5:59 PM</created>
//  <updated>01/28/2014 6:00 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation;

#endregion

namespace VML.Encoding.Model.Validation
{
    public static class ValidationExtensions
    {
        #region Public Methods

        public static bool IsValid<T>(this T objToValidate)
        {
            return objToValidate.IsValid(false);
        }

        public static bool IsValid<T>(this T objToValidate, bool throwIfInvalid)
        {
            Validator<T> validator = ValidationFactory.CreateValidator<T>();
            ValidationResults results = validator.Validate(objToValidate);

            if (!results.IsValid && throwIfInvalid)
            {
                string msg = string.Join("\n", results.Select(r => r.Message));
                msg = string.Format("Invalid object! {0}", msg);

                throw new ValidationException(msg);
            }

            return results.IsValid;
        }

        #endregion
    }
}