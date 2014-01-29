// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EnumExtensions.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 4:02 PM</created>
//  <updated>01/29/2014 4:02 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.ComponentModel;
using System.Linq;

#endregion

namespace VML.Encoding.Support.Extensions
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