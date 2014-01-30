// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Overlay.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:40 PM</created>
//  <updated>01/30/2014 11:19 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using System.Xml.Serialization;

#endregion

namespace VML.Encoding.Model.Query
{
    public class Overlay
    {
        #region Public Properties

        [XmlElement(ElementName = "overlay_bottom")]
        public string Bottom { get; set; }

        [XmlElement(ElementName = "overlay_duration")]
        public string Duration { get; set; }

        [XmlElement(ElementName = "keep_audio")]
        public bool KeepAudio { get; set; }

        [XmlElement(ElementName = "overlay_left")]
        public string Left { get; set; }

        [XmlElement(ElementName = "overlay_right")]
        public string Right { get; set; }

        [XmlElement(ElementName = "size")]
        public string Size { get; set; }

        [XmlElement(ElementName = "overlay_source")]
        public Uri Source { get; set; }

        [XmlElement(ElementName = "overlay_start")]
        public string Start { get; set; }

        [XmlElement(ElementName = "overlay_top")]
        public string Top { get; set; }

        #endregion
    }
}