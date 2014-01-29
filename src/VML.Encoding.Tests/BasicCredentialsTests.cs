// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BasicCredentialsTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 9:49 AM</created>
//  <updated>01/29/2014 10:17 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using VML.Encoding.Model;
using VML.Encoding.Model.Validation;
using Xunit;
using Xunit.Extensions;

#endregion

namespace VML.Encoding.Tests
{
    public class BasicCredentialsTests
    {
        #region Public Methods

        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_NoUserId_IsInvalid(string userId)
        {
            var creds = new BasicCredentials(userId, "fake_userkey");
            Assert.False(creds.IsValid());
        }

        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_NoUserKey_IsInvalid(string userKey)
        {
            var creds = new BasicCredentials("fake_userid", userKey);
            Assert.False(creds.IsValid());
        }

        [Fact]
        public void Constructor_Valid_IsValid()
        {
            var creds = new BasicCredentials("fake_userid", "fake_userkey");
            Assert.True(creds.IsValid());

            Assert.Equal("fake_userid", creds.UserId);
            Assert.Equal("fake_userkey", creds.UserKey);
        }

        #endregion
    }
}