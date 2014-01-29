// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="NotificationFormat.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 10:41 AM</created>
//  <updated>01/29/2014 10:42 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;

#endregion

namespace VML.Encoding.Model
{
    public class NotificationFormat
    {
        #region Public Properties

        public string Description { get; set; }
        public FormatDestination[] Destinations { get; set; }
        public QueryFormat Output { get; set; }
        public TaskStatus Status { get; set; }
        public string Suggestion { get; set; }

        #endregion
    }
}