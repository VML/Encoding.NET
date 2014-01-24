// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingSessionTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/22/2014 3:42 PM</created>
//  <updated>01/23/2014 10:58 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VML.EncodingDotCom.Tests.TheoryData;
using Xunit;
using Xunit.Extensions;

#endregion

namespace VML.EncodingDotCom.Tests
{
    public partial class EncodingSessionTests
    {
        #region Public Methods

        [Fact]
        public void Constructor_EmptyUserId_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EncodingSession(string.Empty, "fake"));
        }

        [Fact]
        public void Constructor_EmptyUserKey_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EncodingSession("fake", string.Empty));
        }

        [Fact]
        public void Constructor_NullUserId_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EncodingSession(null, "fake"));
        }

        [Fact]
        public void Constructor_NullUserKey_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EncodingSession("fake", null));
        }

        [Fact]
        public void Constructor_WhitespaceUserId_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EncodingSession("  ", "fake"));
        }

        [Fact]
        public void Constructor_WhitespaceUserKey_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EncodingSession("fake", "  "));
        }

        [Fact]
        public void CreateQuery_ValidQuery()
        {
            const string userId = "fake_userid";
            const string userKey = "fake_userKey";

            using (var session = new EncodingSession(userId, userKey))
            {
                EncodingQuery query = session.CreateQuery(QueryAction.AddMedia);

                Assert.NotNull(query);

                Assert.NotNull(query.UserId);
                Assert.Equal(userId, query.UserId);

                Assert.NotNull(query.UserKey);
                Assert.Equal(userKey, query.UserKey);

                Assert.Equal(QueryAction.AddMedia, query.Action);
            }
        }

        [Theory]
        [ClassData(typeof(MediaIdRequiredQueryActions))]
        public void Execute_InvalidQuery_ThrowsException(QueryAction action)
        {
            using (var session = new EncodingSession("fake", "fake"))
            {
                EncodingQuery query = session.CreateQuery(action);

                Assert.Throws<ValidationException>(
                    () => session.Execute(query));
            }
        }

        #endregion
    }
}