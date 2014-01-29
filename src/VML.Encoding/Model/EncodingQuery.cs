﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingQuery.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/28/2014 5:59 PM</created>
//  <updated>01/29/2014 10:18 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using VML.Encoding.Model.Interfaces;
using VML.Encoding.Model.Validation.Attributes;

#endregion

namespace VML.Encoding.Model
{
    public class EncodingQuery
    {
        #region Constructors and Destructors

        public EncodingQuery(IEncodingCredentials credentials)
        {
            UserId = credentials.UserId;
            UserKey = credentials.UserKey;
        }

        #endregion

        #region Public Properties

        public QueryAction Action { get; set; }

        [ActionDependentRequired(
            QueryAction.UpdateMedia
            | QueryAction.ProcessMedia
            | QueryAction.CancelMedia
            | QueryAction.GetMediaInfo
            | QueryAction.GetStatus)]
        public string MediaId { get; set; }

        [IgnoreNulls]
        [ValidatorComposition(CompositionType.Or)]
        [RegexValidator(@"^https?.*")]
        [RegexValidator(@"mailto:\s*.+@.+\..+")]
        public string Notify { get; set; }

        [IgnoreNulls]
        [ValidatorComposition(CompositionType.Or)]
        [RegexValidator(@"^https?.*")]
        [RegexValidator(@"mailto:\s*.+@.+\..+")]
        public string NotifyEncodingErrors { get; set; }

        public NotifyFormat NotifyFormat { get; set; }

        [ActionDependentRequired(QueryAction.AddMedia | QueryAction.AddMediaBenchmark)]
        public string[] SourceFiles { get; set; }

        [Required]
        public string UserId { get; private set; }

        [Required]
        public string UserKey { get; private set; }

        #endregion
    }
}