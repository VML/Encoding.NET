// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="TextOverlay.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:42 PM</created>
//  <updated>01/29/2014 2:48 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using System.Xml.Serialization;

#endregion

namespace VML.Encoding.Model.Query
{
    public class TextOverlay
    {
        #region Public Properties

        [XmlElement(ElementName = "align_center")]
        public bool AlignCenter { get; set; }

        [XmlElement(ElementName = "overlay_duration")]
        public int Duration { get; set; }

        [XmlElement(ElementName = "font_color")]
        public string FontColor { get; set; }

        [XmlElement(ElementName = "font_rotate")]
        public string FontRotate { get; set; }

        [XmlElement(ElementName = "font_size")]
        public string FontSize { get; set; }

        [XmlElement(ElementName = "font_source")]
        public string FontSource { get; set; }

        [XmlElement(ElementName = "size")]
        public string Size { get; set; }

        [XmlElement(ElementName = "overlay_start")]
        public int Start { get; set; }

        [XmlElement(ElementName = "text")]
        public string Text { get; set; }

        [XmlElement(ElementName = "overlay_x")]
        public string X { get; set; }

        [XmlElement(ElementName = "overlay_y")]
        public string Y { get; set; }

        #endregion
    }
}