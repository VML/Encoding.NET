// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="NotificationXmlSerializer.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 11:59 AM</created>
//  <updated>01/30/2014 4:01 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Xml.Serialization;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Notification;

#endregion

namespace VML.Encoding.Model.Serialization
{
    public class NotificationXmlSerializer : XmlSerializer
    {
        #region Constants and Fields

        private readonly List<string> _destinationStatuses;
        private readonly List<string> _destinationUrls;

        #endregion

        #region Constructors and Destructors

        public NotificationXmlSerializer()
            : base(typeof(Result), "")
        {
            _destinationUrls = new List<string>();
            _destinationStatuses = new List<string>();
            UnknownElement += NotificationXmlSerializer_UnknownElement;
        }

        #endregion

        #region Properties

        protected FormatDestination[] Destinations
        {
            get
            {
                return
                    _destinationUrls.Select(
                        (url, idx) =>
                        new FormatDestination
                            {
                                Url = url,
                                Status =
                                    (DestinationStatus)Enum.Parse(typeof(DestinationStatus), _destinationStatuses[idx])
                            })
                                    .ToArray();
            }
        }

        #endregion

        #region Public Methods

        public static EncodingNotification Deserialize(string xml)
        {
            NotificationXmlSerializer serializer = new NotificationXmlSerializer();

            Result result;
            using (TextReader reader = new StringReader(xml))
            {
                result = (Result)serializer.Deserialize(reader);
                result.Format.Destinations = serializer.Destinations;
            }

            return new EncodingNotification { Result = result };
        }

        #endregion

        #region Methods

        private void NotificationXmlSerializer_UnknownElement(object sender, XmlElementEventArgs e)
        {
            if (e.Element.Name == "destination")
            {
                _destinationUrls.Add(e.Element.InnerText);
            }
            else if (e.Element.Name == "destination_status")
            {
                _destinationStatuses.Add(e.Element.InnerText);
            }
        }

        #endregion
    }
}