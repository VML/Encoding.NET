// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEncodingCredentials.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/13/2014 12:26 PM</created>
//  <updated>02/13/2014 1:11 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;

#endregion

namespace VML.Encoding.Interfaces
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