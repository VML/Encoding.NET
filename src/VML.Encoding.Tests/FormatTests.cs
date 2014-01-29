// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FormatTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 3:14 PM</created>
//  <updated>01/29/2014 3:18 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Plant.Core;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;
using VML.Encoding.Model.Validation;
using Xunit;
using Xunit.Extensions;

#endregion

namespace VML.Encoding.Tests
{
    public class FormatTests
    {
        #region Constants and Fields

        private readonly BasePlant _plant;

        #endregion

        #region Constructors and Destructors

        public FormatTests()
        {
            _plant = new BasePlant().WithBlueprintsFromAssemblyOf<FormatTests>();
        }

        #endregion

        #region Public Methods

        [Theory]
        [InlineData(FormatOutput.flv, VideoCodec.h263)]
        [InlineData(FormatOutput.mp4, VideoCodec.libtheora)]
        [InlineData(FormatOutput.webm, VideoCodec.none)]
        [InlineData(FormatOutput.threegp, VideoCodec.flv)]
        public void InvalidVideoCodecs_IsInvalid(FormatOutput output, VideoCodec codec)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Output = output;
            format.VideoCodec = codec;

            Assert.False(format.IsValid());
        }

        #endregion
    }
}