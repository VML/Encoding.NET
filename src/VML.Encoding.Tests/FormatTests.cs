// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FormatTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 3:14 PM</created>
//  <updated>01/29/2014 4:43 PM by Ben Ramey</updated>
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
        [InlineData(FormatOutput.flv, "2x5")]
        [InlineData(FormatOutput.flv, "3x4")]
        [InlineData(FormatOutput.threegp, "2x4")]
        [InlineData(FormatOutput.appletv, "2x4")]
        [InlineData(FormatOutput.zune, "2x4")]
        [InlineData(FormatOutput.mxf, "2x4")]
        public void InvalidSizes_IsInvalid(FormatOutput output, string size)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Output = output;
            format.Size = size;

            Assert.False(format.IsValid());
        }

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

        [Theory]
        [InlineData(FormatOutput.flv, VideoCodec.flv, "2x4")]
        [InlineData(FormatOutput.flv, VideoCodec.flv, "1002x2992")]
        [InlineData(FormatOutput.flv, VideoCodec.vp6, "16x16")]
        [InlineData(FormatOutput.flv, VideoCodec.vp6, "32x64")]
        [InlineData(FormatOutput.zune, VideoCodec.wmv2, "320x180")]
        [InlineData(FormatOutput.zune, VideoCodec.wmv2, "320x240")]
        [InlineData(FormatOutput.mxf, VideoCodec.dvcpro50, "720x480")]
        [InlineData(FormatOutput.mxf, VideoCodec.dvcpro50, "960x720")]
        [InlineData(FormatOutput.mxf, VideoCodec.dvcpro50, "1280x720")]
        [InlineData(FormatOutput.mxf, VideoCodec.dvcpro50, "1280x1080")]
        [InlineData(FormatOutput.mxf, VideoCodec.dvcpro50, "1440x1080")]
        [InlineData(FormatOutput.mxf, VideoCodec.dvcpro50, "1920x1080")]
        [InlineData(FormatOutput.threegp, VideoCodec.h263, "128x96")]
        [InlineData(FormatOutput.threegp, VideoCodec.h263, "176x144")]
        [InlineData(FormatOutput.threegp, VideoCodec.h263, "352x288")]
        [InlineData(FormatOutput.threegp, VideoCodec.h263, "704x576")]
        [InlineData(FormatOutput.threegp, VideoCodec.h263, "1408x1152")]
        [InlineData(FormatOutput.appletv, VideoCodec.mpeg4, "710x480")]
        public void ValidSizes_IsValid(FormatOutput output, VideoCodec codec, string size)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.VideoCodec = codec;
            format.Output = output;
            format.Size = size;

            Assert.True(format.IsValid());
        }

        #endregion
    }
}