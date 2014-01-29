// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingClientTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/24/2014 12:31 PM</created>
//  <updated>01/29/2014 10:17 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VML.Encoding.Model;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;
using VML.Encoding.Tests.Support;
using VML.Encoding.Tests.TheoryData;
using Xunit;
using Xunit.Extensions;

#endregion

namespace VML.Encoding.Tests
{
    public partial class EncodingClientTests
    {
        #region Public Methods

        [Theory]
        [PropertyData("InvalidCredentials")]
        public void Constructor_InvalidCredentials_ThrowsException(TestCredentials creds)
        {
            Assert.Throws<ValidationException>(() => new EncodingClient(creds));
        }

        [Fact]
        public void CreateQuery_ValidQuery()
        {
            var creds = new TestCredentials();
            var client = new EncodingClient(creds);
            EncodingQuery query = client.CreateQuery(QueryAction.AddMedia);

            Assert.NotNull(query);

            Assert.NotNull(query.UserId);
            Assert.Equal(creds.UserId, query.UserId);

            Assert.NotNull(query.UserKey);
            Assert.Equal(creds.UserKey, query.UserKey);

            Assert.Equal(QueryAction.AddMedia, query.Action);
        }

        [Theory]
        [ClassData(typeof(MediaIdRequiredQueryActions))]
        public void Execute_InvalidQuery_ThrowsException(QueryAction action)
        {
            var client = new EncodingClient(new TestCredentials());
            EncodingQuery query = client.CreateQuery(action);

            Assert.Throws<ValidationException>(
                () => client.Execute(query));
        }

        #endregion
    }
}