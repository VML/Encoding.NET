// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="NotificationResult.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 10:41 AM</created>
//  <updated>01/29/2014 11:23 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace VML.Encoding.Model
{
    [XmlRoot(ElementName = "result")]
    public class NotificationResult
    {
        #region Public Properties

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "format")]
        public NotificationFormat Format { get; set; }

        [XmlElement(ElementName = "mediaid")]
        public string MediaId { get; set; }

        [XmlElement(ElementName = "source")]
        public string Source { get; set; }

        [XmlElement(ElementName = "status")]
        public MediaStatus Status { get; set; }

        #endregion
    }
}