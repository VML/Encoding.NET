﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ValidationExtensions.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/28/2014 5:59 PM</created>
//  <updated>01/29/2014 4:02 PM by Ben Ramey</updated>
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

        /// <summary>
        ///     Executes validation and returns true if valid and false if not.
        /// </summary>
        /// <typeparam name="T">Type of object to validate</typeparam>
        /// <param name="objToValidate">Object to validate</param>
        /// <returns>True if valid, false if not.</returns>
        public static bool IsValid<T>(this T objToValidate)
        {
            try
            {
                objToValidate.Validate();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Performs validation and throws a ValidationException if the object is invalid.
        /// </summary>
        /// <typeparam name="T">Type of object to validate</typeparam>
        /// <param name="objToValidate">Object to validate</param>
        public static void Validate<T>(this T objToValidate)
        {
            Validator<T> validator = ValidationFactory.CreateValidator<T>();
            ValidationResults results = validator.Validate(objToValidate);

            if (results.IsValid)
            {
                return;
            }

            string msg = string.Join("\n", results.Select(r => r.Message));
            msg = string.Format("Invalid object! {0}", msg);

            throw new ValidationException(msg);
        }

        #endregion
    }
}