// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Result.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:15 PM</created>
//  <updated>01/29/2014 2:16 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using System.Xml.Serialization;
using VML.Encoding.Model.Enums;

#endregion

namespace VML.Encoding.Model.Notification
{
    [XmlRoot(ElementName = "result")]
    public class Result
    {
        #region Public Properties

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "format")]
        public Format Format { get; set; }

        [XmlElement(ElementName = "mediaid")]
        public string MediaId { get; set; }

        [XmlElement(ElementName = "source")]
        public string Source { get; set; }

        [XmlElement(ElementName = "status")]
        public MediaStatus Status { get; set; }

        #endregion
    }
}