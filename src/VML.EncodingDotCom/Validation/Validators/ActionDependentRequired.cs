// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ActionDependentRequired.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/23/2014 10:42 AM</created>
//  <updated>01/23/2014 11:26 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation;

#endregion

namespace VML.EncodingDotCom.Validation.Validators
{
    public class ActionDependentRequired : Validator<string>
    {
        #region Constants and Fields

        private readonly QueryAction _actions;

        #endregion

        #region Constructors and Destructors

        public ActionDependentRequired(QueryAction actions, string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
            _actions = actions;
        }

        public ActionDependentRequired(string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
        }

        #endregion

        #region Properties

        protected override string DefaultMessageTemplate
        {
            get
            {
                return "You must set a MediaId when performing a media action.";
            }
        }

        #endregion

        #region Methods

        protected override void DoValidate(
            string objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            EncodingQuery target = (EncodingQuery)currentTarget;

            if ((target.Action & _actions) == target.Action
                && string.IsNullOrWhiteSpace(objectToValidate))
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

        #endregion
    }
}