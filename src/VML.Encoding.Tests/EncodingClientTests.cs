// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingClientTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/24/2014 12:31 PM</created>
//  <updated>01/28/2014 5:51 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VML.Encoding.Infrastructure;
using VML.Encoding.Model;
using VML.Encoding.Tests.TheoryData;
using Xunit;
using Xunit.Extensions;

#endregion

namespace VML.Encoding.Tests
{
    public partial class EncodingClientTests
    {
        #region Public Methods

        [Fact]
        public void Constructor_EmptyUserId_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EncodingClient(string.Empty, "fake"));
        }

        [Fact]
        public void Constructor_EmptyUserKey_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EncodingClient("fake", string.Empty));
        }

        [Fact]
        public void Constructor_NullUserId_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EncodingClient(null, "fake"));
        }

        [Fact]
        public void Constructor_NullUserKey_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EncodingClient("fake", null));
        }

        [Fact]
        public void Constructor_WhitespaceUserId_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EncodingClient("  ", "fake"));
        }

        [Fact]
        public void Constructor_WhitespaceUserKey_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EncodingClient("fake", "  "));
        }

        [Fact]
        public void CreateQuery_ValidQuery()
        {
            const string userId = "fake_userid";
            const string userKey = "fake_userKey";

            var session = new EncodingClient(userId, userKey);
            EncodingQuery query = session.CreateQuery(QueryAction.AddMedia);

            Assert.NotNull(query);

            Assert.NotNull(query.UserId);
            Assert.Equal(userId, query.UserId);

            Assert.NotNull(query.UserKey);
            Assert.Equal(userKey, query.UserKey);

            Assert.Equal(QueryAction.AddMedia, query.Action);
        }

        [Theory]
        [ClassData(typeof(MediaIdRequiredQueryActions))]
        public void Execute_InvalidQuery_ThrowsException(QueryAction action)
        {
            var session = new EncodingClient("fake", "fake");
            EncodingQuery query = session.CreateQuery(action);

            Assert.Throws<ValidationException>(
                () => session.Execute(query));
        }

        #endregion
    }
}