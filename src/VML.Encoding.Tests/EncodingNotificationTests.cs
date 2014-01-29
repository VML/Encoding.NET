// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingNotificationTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 10:29 AM</created>
//  <updated>01/29/2014 12:03 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using System.Xml;
using VML.Encoding.Model;
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
        [PropertyData("XmlResults")]
        public void XmlResults_ParsesCorrectly(string xml)
        {
            NotificationResult result = null;

            Assert.DoesNotThrow(() => result = NotificationXmlSerializer.Deserialize(xml));
            Assert.NotNull(result);

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
                Assert.Equal(destinationUrls[idx], result.Format.Destinations[idx].Destination);
                Assert.Equal(destinationStatus[idx], result.Format.Destinations[idx].DestinationStatus);
            }
        }

        #endregion
    }
}