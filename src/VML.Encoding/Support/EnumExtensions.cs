// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EnumExtensions.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/13/2014 12:27 PM</created>
//  <updated>02/13/2014 1:11 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.ComponentModel;
using System.Linq;

#endregion

namespace VML.Encoding.Support
{
    public static class EnumExtensions
    {
        #region Public Methods

        public static string ToDescription(this Enum value)
        {
            var da =
                (DescriptionAttribute[])
                (value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return da.Length > 0 ? da[0].Description : value.ToString();
        }

        #endregion
    }
}