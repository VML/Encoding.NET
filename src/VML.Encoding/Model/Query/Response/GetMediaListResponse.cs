﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="GetMediaListResponse.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>01/30/2014 6:02 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using Newtonsoft.Json;
using VML.Encoding.Model.Serialization;

#endregion

namespace VML.Encoding.Model.Query.Response
{
    public class GetMediaListResponse : BaseResponse
    {
        #region Public Properties

        public MediaListItem[] Media { get; set; }

        #endregion
    }

    public class MediaListItem
    {
        #region Public Properties

        [JsonConverter(typeof(EncodingDateTimeConverter))]
        public DateTime? CreateDate { get; set; }

        [JsonConverter(typeof(EncodingDateTimeConverter))]
        public DateTime? FinishDate { get; set; }

        public string MediaFile { get; set; }
        public string MediaID { get; set; }
        public string MediaStatus { get; set; }

        [JsonConverter(typeof(EncodingDateTimeConverter))]
        public DateTime? StartDate { get; set; }

        #endregion
    }
}