// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingQueryTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/23/2014 9:31 AM</created>
//  <updated>01/23/2014 12:34 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Plant.Core;
using VML.Encoding.Tests.TheoryData;
using VML.Encoding.Validation;
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
            EncodingQuery query = _plant.Create<EncodingQuery>(new { UserId = string.Empty });
            Assert.False(query.IsValid());
        }

        [Fact]
        public void NoUserKey_Invalid()
        {
            EncodingQuery query = _plant.Create<EncodingQuery>(new { UserKey = string.Empty });
            Assert.False(query.IsValid());
        }

        [Theory]
        [ClassData(typeof(SourceFileRequiredQueryActions))]
        public void SourceFileRequiredActions_NoSourceFile_IsInvalid(QueryAction action)
        {
            EncodingQuery query = _plant.Create<EncodingQuery>();
            Assert.True(query.IsValid());

            query.SourceFile = string.Empty;
            Assert.False(query.IsValid());
        }

        #endregion
    }
}