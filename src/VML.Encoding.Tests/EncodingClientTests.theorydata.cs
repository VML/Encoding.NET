// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingClientTests.theorydata.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/24/2014 12:31 PM</created>
//  <updated>01/30/2014 4:01 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;
using VML.Encoding.Tests.Support;

#endregion

namespace VML.Encoding.Tests
{
    public partial class EncodingClientTests
    {
        #region Public Properties

        public static IEnumerable<object[]> InvalidCredentials
        {
            get
            {
                return new object[][]
                    {
                        new[] { new TestCredentials { UserId = " " } },
                        new[] { new TestCredentials { UserKey = " " } },
                        new[] { new TestCredentials { UserId = null } },
                        new[] { new TestCredentials { UserKey = null } },
                        new[] { new TestCredentials { UserId = string.Empty } },
                        new[] { new TestCredentials { UserKey = string.Empty } },
                    };
            }
        }

        public static IEnumerable<object[]> ValidQueries
        {
            get
            {
                return new[]
                    {
                        new object[]
                            {
                                new EncodingQuery(new TestCredentials())
                                    {
                                        Action = QueryAction.AddMedia,
                                        SourceFiles =
                                            new List<Uri>
                                                {
                                                    new Uri(
                                                        "http://libertylink.vmldev.com/Templates/RelatePlus/Styles/video/poc.mp4")
                                                },
                                        Format = new
                                            {
                                                output = "mp4",
                                                size = "768x432",
                                                audio_bitrate = "128k",
                                                audio_sample_rate = "44100",
                                                audio_channels_number = "2",
                                                framerate = "30",
                                                keep_aspect_ratio = "yes",
                                                video_codec = "libx264",
                                                profile = "main",
                                                audio_codec = "dolby_aac",
                                                two_pass = "no",
                                                turbo = "no",
                                                twin_turbo = "no",
                                                cbr = "no",
                                                deinterlacing = "auto",
                                                keyframe = "300",
                                                audio_volume = "100",
                                                rotate = "def",
                                                metadata_copy = "no",
                                                strip_chapters = "no",
                                                hint = "no",
                                                overlay = new[]
                                                    {
                                                        new
                                                            {
                                                                overlay_source =
                                                                    "http://vml-encoding.herokuapp.com/ryan_doll.jpg",
                                                                overlay_left = "274.794",
                                                                overlay_top = "107.25",
                                                                size = "227.927x183.898",
                                                                overlay_start = "42.733",
                                                                overlay_duration = "0.034",
                                                                keep_audio = "0"
                                                            }
                                                    }
                                            }
                                    },
                                JsonConvert.SerializeObject(
                                    new
                                        {
                                            query = new
                                                {
                                                    action = "AddMedia",
                                                    format = new
                                                        {
                                                            output = "mp4",
                                                            size = "768x432",
                                                            audio_bitrate = "128k",
                                                            audio_sample_rate = "44100",
                                                            audio_channels_number = "2",
                                                            framerate = "30",
                                                            keep_aspect_ratio = "yes",
                                                            video_codec = "libx264",
                                                            profile = "main",
                                                            audio_codec = "dolby_aac",
                                                            two_pass = "no",
                                                            turbo = "no",
                                                            twin_turbo = "no",
                                                            cbr = "no",
                                                            deinterlacing = "auto",
                                                            keyframe = "300",
                                                            audio_volume = "100",
                                                            rotate = "def",
                                                            metadata_copy = "no",
                                                            strip_chapters = "no",
                                                            hint = "no",
                                                            overlay = new[]
                                                                {
                                                                    new
                                                                        {
                                                                            overlay_source =
                                                                                "http://vml-encoding.herokuapp.com/ryan_doll.jpg",
                                                                            overlay_left = "274.794",
                                                                            overlay_top = "107.25",
                                                                            size = "227.927x183.898",
                                                                            overlay_start = "42.733",
                                                                            overlay_duration = "0.034",
                                                                            keep_audio = "0"
                                                                        }
                                                                }
                                                        },
                                                    source = new[]
                                                        {
                                                            "http://libertylink.vmldev.com/Templates/RelatePlus/Styles/video/poc.mp4"
                                                        },
                                                    userid = new TestCredentials().UserId,
                                                    userkey = new TestCredentials().UserKey,
                                                }
                                        })
                            },
                    }
                    ;
            }
        }

        #endregion
    }
}