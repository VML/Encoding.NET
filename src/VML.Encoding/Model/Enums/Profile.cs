// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Profile.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:44 PM</created>
//  <updated>01/30/2014 4:01 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.ComponentModel;
using System.Linq;
using System;

#endregion

namespace VML.Encoding.Model.Enums
{
    public enum Profile
    {
        [Description("high")]
        High,

        [Description("main")]
        Main,

        [Description("baseline")]
        Baseline
    }
}