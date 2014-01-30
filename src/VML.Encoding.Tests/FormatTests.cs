// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FormatTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 3:14 PM</created>
//  <updated>01/29/2014 5:08 PM by Ben Ramey</updated>
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
        [InlineData(FormatOutput.roku_hls, "4.75k")]
        [InlineData(FormatOutput.threegp, "5.25k")]
        [InlineData(FormatOutput.threegp, "2.2k")]
        [InlineData(FormatOutput.flv, "45k")]
        [InlineData(FormatOutput.mp3, "161k")]
        [InlineData(FormatOutput.webm, "50k")]
        public void InvalidAudioBitrate_IsInvalid(FormatOutput output, string bitrate)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Output = output;
            format.AudioBitrate = bitrate;

            Assert.False(format.IsValid());
        }

        [Theory]
        [InlineData(FormatOutput.roku_hls, "10k")]
        [InlineData(FormatOutput.threegp, "4.75k")]
        [InlineData(FormatOutput.threegp, "5.15k")]
        [InlineData(FormatOutput.threegp, "10.2k")]
        [InlineData(FormatOutput.ogg, "45k")]
        [InlineData(FormatOutput.ogg, "160k")]
        [InlineData(FormatOutput.ogg, "224k")]
        public void ValidAudioBitrate_IsValid(FormatOutput output, string bitrate)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Output = output;
            format.AudioBitrate = bitrate;

            Assert.True(format.IsValid());
        }

        [Theory]
        [InlineData(FormatOutput.mp3, AudioCodec.libmp3lame)]
        [InlineData(FormatOutput.m4a, AudioCodec.libfaac)]
        public void ValidAudioCodec_IsValid(FormatOutput output, AudioCodec codec)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Output = output;
            format.AudioCodec = codec;

            format.Validate();
            Assert.True(format.IsValid());
        }

        [Theory]
        [InlineData(FormatOutput.mp3, AudioCodec.ac3)]
        [InlineData(FormatOutput.m4a, AudioCodec.libmp3lame)]
        public void InvalidAudioCodec_IsInvalid(FormatOutput output, AudioCodec codec)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Output = output;
            format.AudioCodec = codec;

            Assert.False(format.IsValid());
        }

        [Theory]
        [InlineData("103")]
        [InlineData("2.3k")]
        public void InvalidBitrate_IsInvalid(string bitrate)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Bitrate = bitrate;

            Assert.False(format.IsValid());
        }

        [Theory]
        [InlineData(-10)]
        public void InvalidDuration_IsInvalid(int duration)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Duration = duration;
            Assert.False(format.IsValid());
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("1/-3")]
        [InlineData("-20/3")]
        public void InvalidFramerate_IsInvalid(string framerate)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Framerate = framerate;
            Assert.False(format.IsValid());

            format.Framerate = null;
            format.FramerateUpperThreshold = framerate;
            Assert.False(format.IsValid());
        }

        [Theory]
        [InlineData("330.2")]
        [InlineData("2.3k")]
        public void InvalidMaxRateAndMinRate_IsInvalid(string rate)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.MaxRate = rate;
            Assert.False(format.IsValid());

            format.MaxRate = null;
            format.MinRate = rate;
            Assert.False(format.IsValid());
        }

        [Theory]
        [InlineData("bob")]
        [InlineData("1.2:3")]
        [InlineData("1:3.3")]
        public void InvalidSetAspectRatios_IsInvalid(string aspectRatio)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.SetAspectRatio = aspectRatio;

            Assert.False(format.IsValid());
        }

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
        [InlineData("-12")]
        [InlineData("-22.123")]
        public void InvalidStartFinish_IsInvalid(string startOrFinish)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Start = startOrFinish;
            Assert.False(format.IsValid());

            format.Start = null;
            format.Finish = startOrFinish;
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
        [InlineData("103k")]
        public void ValidBitrate_IsValid(string bitrate)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Bitrate = bitrate;

            Assert.True(format.IsValid());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(200)]
        [InlineData(0)]
        public void ValidDuration_IsValid(int duration)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Duration = duration;
            Assert.True(format.IsValid());
        }

        [Theory]
        [InlineData("1")]
        [InlineData("200/239")]
        [InlineData("2392")]
        public void ValidFramerate_IsValid(string framerate)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Framerate = framerate;
            Assert.True(format.IsValid());

            format.FramerateUpperThreshold = framerate;
            Assert.True(format.IsValid());
        }

        [Theory]
        [InlineData("103k")]
        [InlineData("103")]
        public void ValidMaxRateAndMinRate_IsValid(string rate)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.MaxRate = rate;
            Assert.True(format.IsValid());

            format.MinRate = rate;
            Assert.True(format.IsValid());
        }

        [Theory]
        [InlineData("source")]
        [InlineData("1:3")]
        [InlineData("1.23")]
        public void ValidSetAspectRatios_IsValid(string aspectRatio)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.SetAspectRatio = aspectRatio;

            Assert.True(format.IsValid());
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

        [Theory]
        [InlineData("1.2")]
        [InlineData("23")]
        [InlineData("12:20:22:21")]
        [InlineData("12:20:22;21")]
        public void ValidStartFinish_IsValid(string startOrFinish)
        {
            var format = _plant.Build<Format>();
            format.Validate();

            format.Start = startOrFinish;
            Assert.True(format.IsValid());

            format.Finish = startOrFinish;
            Assert.True(format.IsValid());
        }

        #endregion
    }
}