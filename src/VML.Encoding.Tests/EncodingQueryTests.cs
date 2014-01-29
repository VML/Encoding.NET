// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingQueryTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/24/2014 12:31 PM</created>
//  <updated>01/28/2014 6:00 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Plant.Core;
using VML.Encoding.Model;
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