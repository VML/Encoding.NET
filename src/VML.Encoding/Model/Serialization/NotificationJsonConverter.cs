// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="NotificationJsonConverter.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 12:43 PM</created>
//  <updated>01/29/2014 2:48 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Notification;

#endregion

namespace VML.Encoding.Model.Serialization
{
    public class NotificationJsonConverter : JsonConverter
    {
        #region Public Methods

        public override bool CanConvert(Type objectType)
        {
            return typeof(EncodingNotification) == objectType;
        }

        public override object ReadJson(
            JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            EncodingNotification notification = new EncodingNotification();

            dynamic json = JObject.Load(reader);

            notification.Result = new Result
                {
                    Description = (string)json.result.description,
                    Format = new Format
                        {
                            Description = (string)json.result.format.description,
                            Output = json.result.format.output,
                            Status = json.result.format.status,
                            Suggestion = (string)json.result.format.suggestion
                        },
                    MediaId = (string)json.result.mediaid,
                    Source = (string)json.result.source,
                    Status = json.result.status,
                };

            string[] destinations = ((JArray)json.result.format.destination)
                .Select(d => d.Value<string>())
                .ToArray();

            DestinationStatus[] statuses = ((JArray)json.result.format.destination_status)
                .Select(ds => (DestinationStatus)Enum.Parse(typeof(DestinationStatus), ds.Value<string>()))
                .ToArray();

            notification.Result.Format.Destinations = new FormatDestination[destinations.Length];
            for (int idx = 0; idx < destinations.Length; idx++)
            {
                notification.Result.Format.Destinations[idx] = new FormatDestination
                    {
                        Url = destinations[idx],
                        Status = statuses[idx]
                    };
            }

            return notification;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}