﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingQueryTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/24/2014 12:31 PM</created>
//  <updated>01/30/2014 4:54 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using Plant.Core;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;
using VML.Encoding.Model.Validation;
using VML.Encoding.Tests.Support;
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

        [Fact]
        public void Constructor_NullCredentials_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new EncodingQuery(null));
        }

        [Fact]
        public void Constructor_Properties_NotNull()
        {
            var query = new EncodingQuery(new TestCredentials());

            Assert.NotNull(query.SourceFiles);
        }

        [Theory]
        [ClassData(typeof(MediaIdRequiredQueryActions))]
        public void MediaIdRequiredActions_NoMediaId_IsInvalid(QueryAction action)
        {
            EncodingQuery query = _plant.Create<EncodingQuery>();
            query.Validate();

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
            query.Validate();

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
            query.Validate();

            query.NotifyEncodingErrors = url;

            Assert.True(query.IsValid());
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("bob")]
        public void Notify_InvalidUrl_IsInvalid(string url)
        {
            var query = _plant.Create<EncodingQuery>();
            query.Validate();

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
            query.Validate();

            query.Notify = url;

            Assert.True(query.IsValid());
        }

        [Theory]
        [ClassData(typeof(SourceFileRequiredQueryActions))]
        public void SourceFileRequiredActions_NoSourceFile_IsInvalid(QueryAction action)
        {
            EncodingQuery query = _plant.Create<EncodingQuery>();
            query.Validate();

            query.SourceFiles = new List<Uri>();
            Assert.False(query.IsValid());
        }

        [Fact]
        public void SourceFile_NotRequiredAction_IsValid()
        {
            EncodingQuery query = _plant.Create<EncodingQuery>();
            query.Validate();

            query.Action = QueryAction.GetStatus;
            Assert.True(query.IsValid());
        }

        #endregion
    }
}