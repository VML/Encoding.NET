// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingQueryTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/24/2014 12:31 PM</created>
//  <updated>01/30/2014 11:05 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Plant.Core;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;
using VML.Encoding.Model.Validation;
using VML.Encoding.Tests.TheoryData;
using Xunit;
using Xunit.Extensions;

#endregion

namespace VML.Encoding.Tests
{
    public class EncodingQueryTests
    {
        #region Constants and Fields

        private readonly BasePlant _plant;

        #endregion

        #region Constructors and Destructors

        public EncodingQueryTests()
        {
            _plant = new BasePlant().WithBlueprintsFromAssemblyOf<EncodingQueryTests>();
        }

        #endregion

        #region Public Methods

        [Theory]
        [ClassData(typeof(MediaIdRequiredQueryActions))]
        public void MediaIdRequiredActions_NoMediaId_IsInvalid(QueryAction action)
        {
            EncodingQuery query = _plant.Create<EncodingQuery>();
            Assert.True(query.IsValid());

            query.MediaId = string.Empty;
            Assert.False(query.IsValid());
        }

        [Fact]
        public void NoUserId_Invalid()
        {
            EncodingQuery query = _plant.Create<EncodingQuery>("nouserid");
            Assert.False(query.IsValid());
        }

        [Fact]
        public void NoUserKey_Invalid()
        {
            EncodingQuery query = _plant.Create<EncodingQuery>("nouserkey");
            Assert.False(query.IsValid());
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("bob")]
        public void NotifyEncodingErrors_InvalidUrl_IsInvalid(string url)
        {
            var query = _plant.Create<EncodingQuery>();
            Assert.True(query.IsValid());

            query.NotifyEncodingErrors = url;

            Assert.False(query.IsValid());
        }

        [Theory]
        [InlineData("http://bob.com")]
        [InlineData("https://bob.com")]
        [InlineData("mailto:joe@smith.com")]
        public void NotifyEncodingErrors_ValidUrl_IsValid(string url)
        {
            var query = _plant.Create<EncodingQuery>();
            Assert.True(query.IsValid());

            query.NotifyEncodingErrors = url;

            Assert.True(query.IsValid());
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("bob")]
        public void Notify_InvalidUrl_IsInvalid(string url)
        {
            var query = _plant.Create<EncodingQuery>();
            Assert.True(query.IsValid());

            query.Notify = url;

            Assert.False(query.IsValid());
        }

        [Theory]
        [InlineData("http://bob.com")]
        [InlineData("https://bob.com")]
        [InlineData("mailto:joe@smith.com")]
        public void Notify_ValidUrl_IsValid(string url)
        {
            var query = _plant.Create<EncodingQuery>();
            Assert.True(query.IsValid());

            query.Notify = url;

            Assert.True(query.IsValid());
        }

        [Theory]
        [ClassData(typeof(SourceFileRequiredQueryActions))]
        public void SourceFileRequiredActions_NoSourceFile_IsInvalid(QueryAction action)
        {
            EncodingQuery query = _plant.Create<EncodingQuery>();
            Assert.True(query.IsValid());

            query.SourceFiles = new string[0];
            Assert.False(query.IsValid());
        }

        #endregion
    }
}