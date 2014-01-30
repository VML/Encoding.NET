// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingQuery.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:14 PM</created>
//  <updated>01/30/2014 4:01 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Interfaces;
using VML.Encoding.Model.Validation.Attributes;

#endregion

namespace VML.Encoding.Model.Query
{
    public class EncodingQuery
    {
        #region Constructors and Destructors

        public EncodingQuery(IEncodingCredentials credentials)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }

            UserId = credentials.UserId;
            UserKey = credentials.UserKey;

            SourceFiles = new List<Uri>();
        }

        #endregion

        #region Public Properties

        [JsonConverter(typeof(StringEnumConverter))]
        public QueryAction Action { get; set; }

        public dynamic Format { get; set; }

        [JsonProperty(PropertyName = "mediaid")]
        [ActionDependentRequired(
            QueryAction.UpdateMedia
            | QueryAction.ProcessMedia
            | QueryAction.CancelMedia
            | QueryAction.GetMediaInfo
            | QueryAction.GetStatus, MessageTemplate = "MediaId must be set for this query action.")]
        public string MediaId { get; set; }

        [IgnoreNulls]
        [ValidatorComposition(CompositionType.Or)]
        [RegexValidator(@"^https?.*")]
        [RegexValidator(@"mailto:\s*.+@.+\..+")]
        public string Notify { get; set; }

        [JsonProperty(PropertyName = "notify_encoding_errors")]
        [IgnoreNulls]
        [ValidatorComposition(CompositionType.Or)]
        [RegexValidator(@"^https?.*")]
        [RegexValidator(@"mailto:\s*.+@.+\..+")]
        public string NotifyEncodingErrors { get; set; }

        [JsonProperty(PropertyName = "notify_format")]
        [JsonConverter(typeof(StringEnumConverter))]
        public QueryFormat? NotifyFormat { get; set; }

        public string Region { get; set; }

        [JsonProperty(PropertyName = "source")]
        [ActionDependentRequired(QueryAction.AddMedia | QueryAction.AddMediaBenchmark,
            MessageTemplate = "SourceFiles must be set for this query action.")]
        public IList<Uri> SourceFiles { get; set; }

        [JsonProperty(PropertyName = "split_screen")]
        public dynamic SplitScreen { get; set; }

        [JsonProperty(PropertyName = "userid")]
        [Required]
        public string UserId { get; private set; }

        [JsonProperty(PropertyName = "userkey")]
        [Required]
        public string UserKey { get; private set; }

        #endregion
    }
}