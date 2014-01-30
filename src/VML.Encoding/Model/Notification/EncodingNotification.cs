// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingNotification.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:13 PM</created>
//  <updated>01/30/2014 11:05 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using Newtonsoft.Json;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Serialization;

#endregion

namespace VML.Encoding.Model.Notification
{
    [JsonConverter(typeof(NotificationJsonConverter))]
    public class EncodingNotification
    {
        #region Public Properties

        public Result Result { get; set; }

        #endregion

        #region Public Methods

        public static EncodingNotification Parse(string jsonOrXml, QueryFormat queryFormat)
        {
            EncodingNotification notification;

            switch (queryFormat)
            {
                case QueryFormat.XML:
                    notification = NotificationXmlSerializer.Deserialize(jsonOrXml);
                    break;
                case QueryFormat.JSON:
                    notification = JsonConvert.DeserializeObject<EncodingNotification>(jsonOrXml);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("queryFormat");
            }

            return notification;
        }

        #endregion
    }
}