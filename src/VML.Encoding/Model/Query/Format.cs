﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Format.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:14 PM</created>
//  <updated>01/29/2014 3:13 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using System.Xml.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Validation.Attributes;

#endregion

namespace VML.Encoding.Model.Query
{
    public class Format
    {
        #region Public Properties

        [XmlElement(ElementName = "add_meta")]
        public bool AddMeta { get; set; }

        [XmlElement(ElementName = "audio_bitrate")]
        public string AudioBitrate { get; set; }

        [XmlElement(ElementName = "audio_channels_number")]
        public int AudioChannelsNumber { get; set; }

        [XmlElement(ElementName = "audio_codec")]
        public AudioCodec AudioCodec { get; set; }

        [XmlElement(ElementName = "audio_normalization")]
        public string AudioNormalization { get; set; }

        [XmlElement(ElementName = "audio_sample_rate")]
        public int AudioSampleRate { get; set; }

        [XmlElement(ElementName = "audio_sync")]
        public string AudioSync { get; set; }

        [XmlElement(ElementName = "audio_volume")]
        public string AudioVolume { get; set; }

        [XmlElement(ElementName = "bframes")]
        public string BFrames { get; set; }

        [XmlElement(ElementName = "bitrate")]
        public string Bitrate { get; set; }

        [XmlElement(ElementName = "bufsize")]
        public string BufSize { get; set; }

        [XmlElement(ElementName = "cxmode")]
        [RangeValidator(
            1, RangeBoundaryType.Inclusive, 2, RangeBoundaryType.Inclusive, ErrorMessage = "{1} must be either 1 or 2")]
        public int CXMode { get; set; }

        [XmlElement(ElementName = "crop_bottom")]
        public string CropBottom { get; set; }

        [XmlElement(ElementName = "crop_left")]
        public string CropLeft { get; set; }

        [XmlElement(ElementName = "crop_right")]
        public string CropRight { get; set; }

        [XmlElement(ElementName = "crop_top")]
        public string CropTop { get; set; }

        public string[] Destinations { get; set; }

        [XmlElement(ElementName = "duration")]
        public string Duration { get; set; }

        [XmlElement(ElementName = "fade_in")]
        public string FadeIn { get; set; }

        [XmlElement(ElementName = "fade_out")]
        public string FadeOut { get; set; }

        [XmlElement(ElementName = "force_interlaced")]
        public ForceInterlaced ForceInterlaced { get; set; }

        [XmlElement(ElementName = "framerate")]
        public string Framerate { get; set; }

        [XmlElement(ElementName = "framerate_upper_threshold")]
        public string FramerateUpperThreshold { get; set; }

        [XmlElement(ElementName = "gop")]
        public string GOP { get; set; }

        [XmlElement(ElementName = "hint")]
        public bool Hint { get; set; }

        [XmlElement(ElementName = "kfinttype")]
        [IgnoreNulls]
        [RangeValidator(
            1, RangeBoundaryType.Inclusive, 2, RangeBoundaryType.Inclusive, ErrorMessage = "{1} must be either 1 or 2")]
        public int? KFintType { get; set; }

        [XmlElement(ElementName = "keep_aspect_ratio")]
        public bool KeepAspectRatio { get; set; }

        [XmlElement(ElementName = "keyframe")]
        [RangeValidator(
            0, RangeBoundaryType.Inclusive, 2, RangeBoundaryType.Ignore,
            ErrorMessage = "{1} must be a non-negative integer")]
        public int Keyframe { get; set; }

        [XmlElement(ElementName = "level")]
        public int Level { get; set; }

        [XmlElement(ElementName = "logo")]
        public Logo Logo { get; set; }

        [XmlElement(ElementName = "maxrate")]
        public string MaxRate { get; set; }

        [XmlElement(ElementName = "metadata")]
        public Metadata Metadata { get; set; }

        [XmlElement(ElementName = "minrate")]
        public string MinRate { get; set; }

        [XmlElement(ElementName = "noise_reduction")]
        [RangeValidator(
            0, RangeBoundaryType.Inclusive, 6, RangeBoundaryType.Inclusive, ErrorMessage = "{1} must be between 0 and 6"
            )]
        public int NoiseReduction { get; set; }

        [XmlElement(ElementName = "output")]
        public FormatOutput Output { get; set; }

        public Overlay[] Overlays { get; set; }

        [XmlElement(ElementName = "Profile")]
        public Profile Profile { get; set; }

        [XmlElement(ElementName = "rc_init_occupancy")]
        public string RCInitOccupancy { get; set; }

        [XmlElement(ElementName = "rotate")]
        public string Rotate { get; set; }

        [XmlElement(ElementName = "set_aspect_ratio")]
        public string SetAspectRatio { get; set; }

        [XmlElement(ElementName = "set_rotate")]
        public string SetRotate { get; set; }

        [XmlElement(ElementName = "sharpness")]
        [IgnoreNulls]
        [RangeValidator(
            0, RangeBoundaryType.Inclusive, 7, RangeBoundaryType.Inclusive, ErrorMessage = "{1} must be between 0 or 7")
        ]
        public int? Sharpness { get; set; }

        [XmlElement(ElementName = "size")]
        public string Size { get; set; }

        [XmlElement(ElementName = "start")]
        public string Start { get; set; }

        [XmlElement(ElementName = "strip_chapters")]
        public bool StripChapters { get; set; }

        public TextOverlay[] TextOverlays { get; set; }

        [XmlElement(ElementName = "turbo")]
        public bool Turbo { get; set; }

        [XmlElement(ElementName = "upct")]
        [IgnoreNulls]
        [RangeValidator(
            0, RangeBoundaryType.Inclusive, 100, RangeBoundaryType.Inclusive,
            ErrorMessage = "{1} must be between 0 and 100")]
        public int? UPCT { get; set; }

        [XmlElement(ElementName = "vp6_profile")]
        [IgnoreNulls]
        [RangeValidator(
            1, RangeBoundaryType.Inclusive, 2, RangeBoundaryType.Inclusive, ErrorMessage = "{1} must be either 1 or 2")]
        public int? VP6Profile { get; set; }

        [XmlElement(ElementName = "video_codec")]
        [ValidVideoCodec]
        public VideoCodec VideoCodec { get; set; }

        [XmlElement(ElementName = "video_codec_parameters")]
        public string VideoCodecParameters { get; set; }

        [XmlElement(ElementName = "video_sync")]
        public string VideoSync { get; set; }

        #endregion
    }
}