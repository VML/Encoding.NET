// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingDateTimeConverter.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/31/2014 11:14 AM</created>
//  <updated>02/13/2014 1:11 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace VML.Encoding.Model.Serialization
{
    public class EncodingDateTimeConverter : DateTimeConverterBase
    {
        #region Public Methods

        public override object ReadJson(
            JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Date)
            {
                return reader.Value;
            }

            if (reader.TokenType != JsonToken.String)
            {
                throw new JsonSerializationException("Unexpected tokenp arsing date.  Expected String, got {0}");
            }

            string dateText = reader.Value.ToString();

            DateTime date;
            if (DateTime.TryParse(dateText, out date))
            {
                return date;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToUniversalTime());
        }

        #endregion
    }
}