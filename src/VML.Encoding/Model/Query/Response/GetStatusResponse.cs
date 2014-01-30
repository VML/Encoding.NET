// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="GetStatusResponse.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 4:30 PM</created>
//  <updated>01/30/2014 5:24 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using Newtonsoft.Json;

#endregion

namespace VML.Encoding.Model.Query.Response
{
    public class GetStatusResponse : BaseResponse
    {
        #region Public Properties

        public DateTime? Created { get; set; }
        public DateTime? Downloaded { get; set; }
        public DateTime? Finished { get; set; }
        public GetStatusFormat Format { get; set; }
        public string ID { get; set; }
        public string NotifyUrl { get; set; }
        public string PrevStatus { get; set; }
        public string Progress { get; set; }
        public string ProgressCurrent { get; set; }
        public string SourceFile { get; set; }
        public DateTime Started { get; set; }
        public string Status { get; set; }

        [JsonProperty(PropertyName = "time_left")]
        public string TimeLeft { get; set; }

        [JsonProperty(PropertyName = "time_left_current")]
        public string TimeLeftCurrent { get; set; }

        public DateTime Uploaded { get; set; }
        public string UserID { get; set; }

        #endregion
    }

    public class GetStatusFormat
    {
        #region Public Properties

        [JsonProperty(PropertyName = "cf_destination")]
        public string CFDestination { get; set; }

        public DateTime? Created { get; set; }
        public Uri[] Destination { get; set; }

        [JsonProperty(PropertyName = "destination_status")]
        public string[] DestinationStatus { get; set; }

        public DateTime? Finished { get; set; }
        public string ID { get; set; }

        [JsonProperty(PropertyName = "s3_destination")]
        public string S3Destination { get; set; }

        public DateTime? Started { get; set; }
        public string Status { get; set; }

        #endregion
    }
}