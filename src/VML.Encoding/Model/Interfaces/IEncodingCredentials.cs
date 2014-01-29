// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEncodingCredentials.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 9:01 AM</created>
//  <updated>01/29/2014 4:02 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;

#endregion

namespace VML.Encoding.Model.Interfaces
{
    public interface IEncodingCredentials
    {
        #region Public Properties

        [Required]
        string UserId { get; }

        [Required]
        string UserKey { get; }

        #endregion
    }
}