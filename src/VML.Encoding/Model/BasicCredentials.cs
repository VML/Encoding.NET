// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BasicCredentials.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 9:52 AM</created>
//  <updated>01/29/2014 4:02 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;
using VML.Encoding.Model.Interfaces;

#endregion

namespace VML.Encoding.Model
{
    public class BasicCredentials : IEncodingCredentials
    {
        #region Constructors and Destructors

        public BasicCredentials(string userId, string userKey)
        {
            UserId = userId;
            UserKey = userKey;
        }

        #endregion

        #region Public Properties

        [Required]
        public string UserId { get; private set; }

        [Required]
        public string UserKey { get; private set; }

        #endregion
    }
}