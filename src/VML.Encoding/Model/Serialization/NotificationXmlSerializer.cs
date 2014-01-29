using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Xml.Serialization;

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
            : base(typeof(NotificationResult), "")
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
                                Destination = url,
                                DestinationStatus =
                                    (DestinationStatus)Enum.Parse(typeof(DestinationStatus), _destinationStatuses[idx])
                            })
                                    .ToArray();
            }
        }

        #endregion

        #region Public Methods

        public static NotificationResult Deserialize(string xml)
        {
            NotificationXmlSerializer serializer = new NotificationXmlSerializer();

            NotificationResult result;
            using (TextReader reader = new StringReader(xml))
            {
                result = (NotificationResult)serializer.Deserialize(reader);
                result.Format.Destinations = serializer.Destinations;
            }

            return result;
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