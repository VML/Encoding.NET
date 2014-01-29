// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Logo.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:38 PM</created>
//  <updated>01/29/2014 2:48 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using System.Xml.Serialization;
using VML.Encoding.Model.Enums;

#endregion

namespace VML.Encoding.Model.Query
{
    public class Logo
    {
        #region Public Properties

        [XmlElement(ElementName = "logo_mode")]
        public VideoCodec Mode { get; set; }

        [XmlElement(ElementName = "logo_source")]
        public VideoCodec Source { get; set; }

        [XmlElement(ElementName = "logo_threshold")]
        public VideoCodec Threshold { get; set; }

        [XmlElement(ElementName = "logo_x")]
        public VideoCodec X { get; set; }

        [XmlElement(ElementName = "logo_y")]
        public VideoCodec Y { get; set; }

        #endregion
    }
}