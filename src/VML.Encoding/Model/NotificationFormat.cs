// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="NotificationFormat.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 10:41 AM</created>
//  <updated>01/29/2014 11:58 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using System.Xml.Serialization;

#endregion

namespace VML.Encoding.Model
{
    public class NotificationFormat
    {
        #region Public Properties

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        public FormatDestination[] Destinations { get; set; }

        [XmlElement(ElementName = "output")]
        public QueryFormat Output { get; set; }

        [XmlElement(ElementName = "status")]
        public TaskStatus Status { get; set; }

        [XmlElement(ElementName = "suggestion")]
        public string Suggestion { get; set; }

        #endregion
    }
}