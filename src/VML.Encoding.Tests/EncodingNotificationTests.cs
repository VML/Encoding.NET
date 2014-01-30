// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingNotificationTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 10:29 AM</created>
//  <updated>01/30/2014 11:05 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using System.Xml;
using Newtonsoft.Json.Linq;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Notification;
using VML.Encoding.Model.Serialization;
using Xunit;
using Xunit.Extensions;

#endregion

namespace VML.Encoding.Tests
{
    public partial class EncodingNotificationTests
    {
        #region Public Methods

        [Theory]
        [PropertyData("JsonResults")]
        public void Parse_JsonString_IsValid(string json)
        {
            var response = EncodingNotification.Parse(json, QueryFormat.JSON);
            CompareJsonAndNotificationResult(json, response.Result);
        }

        [Theory]
        [PropertyData("XmlResults")]
        public void Parse_XmlString_IsValid(string xml)
        {
            var response = EncodingNotification.Parse(xml, QueryFormat.XML);
            CompareXmlAndNotificationResult(xml, response.Result);
        }

        [Theory]
        [PropertyData("XmlResults")]
        public void XmlResults_ParsesCorrectly(string xml)
        {
            EncodingNotification notification = null;

            Assert.DoesNotThrow(() => notification = NotificationXmlSerializer.Deserialize(xml));
            Assert.NotNull(notification);

            CompareXmlAndNotificationResult(xml, notification.Result);
        }

        #endregion

        #region Methods

        private static void CompareXmlAndNotificationResult(string xml, Result result)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            string mediaId = doc.SelectSingleNode("/result/mediaid").InnerText;
            string source = doc.SelectSingleNode("/result/source").InnerText;
            MediaStatus status =
                (MediaStatus)Enum.Parse(typeof(MediaStatus), doc.SelectSingleNode("/result/status").InnerText);
            string description = doc.SelectSingleNode("/result/description").InnerText;
            QueryFormat formatOutput =
                (QueryFormat)Enum.Parse(typeof(QueryFormat), doc.SelectSingleNode("/result/format/output").InnerText);
            TaskStatus formatStatus =
                (TaskStatus)Enum.Parse(typeof(TaskStatus), doc.SelectSingleNode("/result/format/status").InnerText);
            string formatDescription = doc.SelectSingleNode("/result/format/description").InnerText;
            string formatSuggestion = doc.SelectSingleNode("/result/format/suggestion").InnerText;
            string[] destinationUrls = doc.SelectNodes("/result/format/destination")
                                          .Cast<XmlNode>()
                                          .Select(xn => xn.InnerText)
                                          .ToArray();
            DestinationStatus[] destinationStatus = doc.SelectNodes("/result/format/destination_status")
                                                       .Cast<XmlNode>()
                                                       .Select(
                                                           xn =>
                                                           (DestinationStatus)
                                                           Enum.Parse(typeof(DestinationStatus), xn.InnerText))
                                                       .ToArray();

            Assert.Equal(mediaId, result.MediaId);
            Assert.Equal(source, result.Source);
            Assert.Equal(status, result.Status);
            Assert.Equal(description, result.Description);
            Assert.Equal(formatOutput, result.Format.Output);
            Assert.Equal(formatStatus, result.Format.Status);
            Assert.Equal(formatDescription, result.Format.Description);
            Assert.Equal(formatSuggestion, result.Format.Suggestion);

            Assert.NotNull(result.Format.Destinations);
            Assert.Equal(destinationUrls.Length, result.Format.Destinations.Length);

            for (int idx = 0; idx < destinationUrls.Length; idx++)
            {
                Assert.Equal(destinationUrls[idx], result.Format.Destinations[idx].Url);
                Assert.Equal(destinationStatus[idx], result.Format.Destinations[idx].Status);
            }
        }

        private void CompareJsonAndNotificationResult(string jsonString, Result result)
        {
            dynamic json = JObject.Parse(jsonString);

            Assert.Equal((string)json.result.mediaid, result.MediaId);
            Assert.Equal((string)json.result.source, result.Source);
            Assert.Equal((MediaStatus)json.result.status, result.Status);
            Assert.Equal((string)json.result.description, result.Description);
            Assert.Equal((QueryFormat)json.result.format.output, result.Format.Output);
            Assert.Equal((TaskStatus)json.result.format.status, result.Format.Status);
            Assert.Equal((string)json.result.format.description, result.Format.Description);
            Assert.Equal((string)json.result.format.suggestion, result.Format.Suggestion);

            string[] urls = ((JArray)json.result.format.destination).Select(d => d.Value<string>()).ToArray();
            DestinationStatus[] statuses = ((JArray)json.result.format.destination_status)
                .Select(ds => (DestinationStatus)Enum.Parse(typeof(DestinationStatus), ds.Value<string>()))
                .ToArray();

            Assert.NotNull(result.Format.Destinations);
            Assert.Equal(urls.Length, result.Format.Destinations.Length);

            for (int idx = 0; idx < urls.Length; idx++)
            {
                Assert.Equal(urls[idx], result.Format.Destinations[idx].Url);
                Assert.Equal(statuses[idx], result.Format.Destinations[idx].Status);
            }
        }

        #endregion
    }
}