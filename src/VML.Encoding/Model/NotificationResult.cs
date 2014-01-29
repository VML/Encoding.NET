// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="NotificationResult.cs" company="VML">
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
    public class NotificationResult
    {
        #region Public Properties

        public string Description { get; set; }
        public NotificationFormat Format { get; set; }
        public string MediaId { get; set; }
        public string Source { get; set; }
        public MediaStatus Status { get; set; }

        #endregion
    }
}