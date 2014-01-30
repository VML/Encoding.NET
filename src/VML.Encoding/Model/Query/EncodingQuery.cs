// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingQuery.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:14 PM</created>
//  <updated>01/30/2014 12:20 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;
using System.Xml.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
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
            UserId = credentials.UserId;
            UserKey = credentials.UserKey;
        }

        #endregion

        #region Public Properties

        [XmlElement(ElementName = "action")]
        public QueryAction Action { get; set; }

        [XmlElement(ElementName = "format")]
        public dynamic Format { get; set; }

        [XmlElement(ElementName = "mediaid")]
        [ActionDependentRequired(
            QueryAction.UpdateMedia
            | QueryAction.ProcessMedia
            | QueryAction.CancelMedia
            | QueryAction.GetMediaInfo
            | QueryAction.GetStatus)]
        public string MediaId { get; set; }

        [XmlElement(ElementName = "notify")]
        [IgnoreNulls]
        [ValidatorComposition(CompositionType.Or)]
        [RegexValidator(@"^https?.*")]
        [RegexValidator(@"mailto:\s*.+@.+\..+")]
        public string Notify { get; set; }

        [XmlElement(ElementName = "notify_encoding_errors")]
        [IgnoreNulls]
        [ValidatorComposition(CompositionType.Or)]
        [RegexValidator(@"^https?.*")]
        [RegexValidator(@"mailto:\s*.+@.+\..+")]
        public string NotifyEncodingErrors { get; set; }

        [XmlElement(ElementName = "notify_format")]
        public QueryFormat NotifyFormat { get; set; }

        [XmlElement(ElementName = "region")]
        public string Region { get; set; }

        [XmlElement(ElementName = "source")]
        [ActionDependentRequired(QueryAction.AddMedia | QueryAction.AddMediaBenchmark)]
        public string[] SourceFiles { get; set; }

        [XmlElement(ElementName = "split_screen")]
        public dynamic SplitScreen { get; set; }

        [XmlElement(ElementName = "userid")]
        [Required]
        public string UserId { get; private set; }

        [XmlElement(ElementName = "userkey")]
        [Required]
        public string UserKey { get; private set; }

        #endregion
    }
}