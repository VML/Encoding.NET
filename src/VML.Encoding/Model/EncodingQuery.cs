﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingQuery.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/22/2014 4:16 PM</created>
//  <updated>01/23/2014 11:47 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;
using VML.Encoding.Model.Validation.Attributes;

#endregion

namespace VML.Encoding.Model
{
    public class EncodingQuery
    {
        #region Constructors and Destructors

        public EncodingQuery(string userId, string userKey)
        {
            UserId = userId;
            UserKey = userKey;
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

        [ActionDependentRequired(QueryAction.AddMedia | QueryAction.AddMediaBenchmark)]
        public string SourceFile { get; set; }

        [Required]
        public string UserId { get; private set; }

        [Required]
        public string UserKey { get; private set; }

        #endregion
    }
}