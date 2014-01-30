// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Format.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:15 PM</created>
//  <updated>01/30/2014 4:01 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using System.Xml.Serialization;
using VML.Encoding.Model.Enums;

#endregion

namespace VML.Encoding.Model.Notification
{
    public class Format
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