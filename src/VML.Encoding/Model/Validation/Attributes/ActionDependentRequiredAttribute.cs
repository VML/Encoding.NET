﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ActionDependentRequiredAttribute.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/28/2014 5:59 PM</created>
//  <updated>01/28/2014 6:00 PM by Ben Ramey</updated>
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