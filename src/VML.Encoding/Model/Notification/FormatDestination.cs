// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FormatDestination.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:15 PM</created>
//  <updated>01/29/2014 2:16 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using VML.Encoding.Model.Enums;

#endregion

namespace VML.Encoding.Model.Notification
{
    public class FormatDestination
    {
        #region Public Properties

        public DestinationStatus Status { get; set; }
        public string Url { get; set; }

        #endregion
    }
}