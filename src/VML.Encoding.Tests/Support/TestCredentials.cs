// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="TestCredentials.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 9:02 AM</created>
//  <updated>02/13/2014 1:11 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using VML.Encoding.Interfaces;

#endregion

namespace VML.Encoding.Tests.Support
{
    public class TestCredentials : IEncodingCredentials
    {
        #region Constructors and Destructors

        public TestCredentials()
        {
            UserId = "fake_userid";
            UserKey = "fake_userkey";
        }

        #endregion

        #region Public Properties

        public string UserId { get; set; }

        public string UserKey { get; set; }

        #endregion
    }
}