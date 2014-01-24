// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ActionDependentRequiredAttribute.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/23/2014 10:45 AM</created>
//  <updated>01/23/2014 11:27 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using VML.EncodingDotCom.Validation.Validators;

#endregion

namespace VML.EncodingDotCom.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ActionDependentRequiredAttribute : ValidatorAttribute
    {
        #region Constants and Fields

        private readonly QueryAction _actions;

        #endregion

        #region Constructors and Destructors

        public ActionDependentRequiredAttribute(QueryAction actions)
        {
            _actions = actions;
        }

        #endregion

        #region Methods

        protected override Validator DoCreateValidator(Type targetType)
        {
            return new ActionDependentRequired(_actions, null, null);
        }

        #endregion
    }
}