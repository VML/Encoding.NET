// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ActionDependentRequiredValidator.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/28/2014 5:59 PM</created>
//  <updated>01/30/2014 5:06 PM by Ben Ramey</updated>
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
    public class ActionDependentRequiredValidator<T> : BaseValidator<T>
    {
        #region Constants and Fields

        private readonly QueryAction _actions;

        #endregion

        #region Constructors and Destructors

        public ActionDependentRequiredValidator(QueryAction actions, string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
            _actions = actions;
        }

        public ActionDependentRequiredValidator(string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
        }

        #endregion

        #region Properties

        protected override string DefaultMessageTemplate
        {
            get
            {
                return "You must set an appropriate value for this query action.";
            }
        }

        #endregion

        #region Methods

        protected override void DoValidate(
            T objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            EncodingQuery target = (EncodingQuery)currentTarget;

            if (typeof(T) == typeof(string))
            {
                string stringToValidate = objectToValidate as string;
                ValidateString(stringToValidate, key, validationResults, target);
            }
            else if (typeof(T) == typeof(IList<Uri>))
            {
                IList<Uri> arrayToValidate = objectToValidate as IList<Uri>;
                ValidateStringArray(arrayToValidate, key, validationResults, target);
            }
        }

        private void ValidateString(
            string objectToValidate, string key, ValidationResults validationResults, EncodingQuery target)
        {
            if ((target.Action & _actions) != target.Action
                || !string.IsNullOrWhiteSpace(objectToValidate))
            {
                return;
            }

            AddInvalidResult(key, validationResults);
        }

        private void ValidateStringArray(
            IList<Uri> arrayToValidate, string key, ValidationResults validationResults, EncodingQuery target)
        {
            if (arrayToValidate != null
                && (arrayToValidate.Count > 0
                    || (target.Action & _actions) != target.Action))
            {
                return;
            }

            AddInvalidResult(key, validationResults);
        }

        #endregion
    }
}