// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingNotification.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 10:41 AM</created>
//  <updated>01/29/2014 12:29 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using VML.Encoding.Model.Serialization;

#endregion

namespace VML.Encoding.Model
{
    [JsonConverter(typeof(NotificationJsonConverter))]
    public class EncodingNotification
    {
        #region Public Properties

        public NotificationResult Result { get; set; }

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