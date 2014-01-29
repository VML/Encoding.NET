// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Metadata.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:37 PM</created>
//  <updated>01/29/2014 2:48 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using System.Xml.Serialization;

#endregion

namespace VML.Encoding.Model.Query
{
    public class Metadata
    {
        #region Public Properties

        [XmlElement(ElementName = "album")]
        public string Album { get; set; }

        [XmlElement(ElementName = "author")]
        public string Author { get; set; }

        [XmlElement(ElementName = "copyright")]
        public string Copyright { get; set; }

        [XmlElement(ElementName = "descriptioin")]
        public string Description { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        #endregion
    }
}