// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AudioCodecValidator.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 8:32 AM</created>
//  <updated>01/30/2014 11:05 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;

#endregion

namespace VML.Encoding.Model.Validation.Validators
{
    public class AudioCodecValidator : BaseValidator<AudioCodec>
    {
        #region Constants and Fields

        private static readonly Dictionary<FormatOutput, AudioCodec> Rules = new Dictionary
            <FormatOutput, AudioCodec>
            {
                { FormatOutput.mp3, AudioCodec.libmp3lame },
                {
                    FormatOutput.m4a,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                    | AudioCodec.ac3
                },
                {
                    FormatOutput.flv,
                    AudioCodec.libmp3lame | AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac
                    | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.mp4,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                    | AudioCodec.ac3
                },
                {
                    FormatOutput.fl9,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.m4v,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.ipod,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.iphone,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.ipad,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.appletv,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.psp,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.wowza,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.roku_1200,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.roku_1800,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.roku_2700,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.roku_800,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.kindle_fire,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.mov,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                    | AudioCodec.eac3
                },
                {
                    FormatOutput.iphone_stream,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.ipad_stream,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.wowza_multibitrate,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.smooth_streaming,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.hds,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                {
                    FormatOutput.roku_hls,
                    AudioCodec.libfaac | AudioCodec.dolby_aac | AudioCodec.dolby_heaac | AudioCodec.dolby_heaacv2
                },
                { FormatOutput.wmv, AudioCodec.wmav2 | AudioCodec.libmp3lame },
                { FormatOutput.wma, AudioCodec.wmav2 | AudioCodec.libmp3lame },
                { FormatOutput.zune, AudioCodec.wmav2 | AudioCodec.libmp3lame },
                { FormatOutput.ogg, AudioCodec.libvorbis },
                { FormatOutput.webm, AudioCodec.libvorbis },
                { FormatOutput.threegp, AudioCodec.libamr_nb },
                { FormatOutput.android, AudioCodec.libamr_nb | AudioCodec.libfaac },
                { FormatOutput.mpeg2, AudioCodec.pcm_s16be | AudioCodec.pcm_s16le | AudioCodec.ac3 },
                { FormatOutput.mpeg1, AudioCodec.mp2 | AudioCodec.copy },
                { FormatOutput.mpegts, AudioCodec.ac3 },
                { FormatOutput.mov_prores, AudioCodec.pcm_s16le | AudioCodec.pcm_s24le },
                { FormatOutput.mxf, AudioCodec.pcm_s16le | AudioCodec.pcm_s24le },
                { FormatOutput.dnxhd_mxf, AudioCodec.pcm_s16le | AudioCodec.pcm_s24le },
            };

        #endregion

        #region Constructors and Destructors

        public AudioCodecValidator(string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
        }

        #endregion

        #region Properties

        protected override string DefaultMessageTemplate
        {
            get
            {
                return "You must set a valid audio codec for the corresponding output value.";
            }
        }

        #endregion

        #region Methods

        protected override void DoValidate(
            AudioCodec objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            Format target = (Format)currentTarget;
            bool validCodec = !Rules.ContainsKey(target.Output)
                              || (Rules[target.Output] & objectToValidate) == objectToValidate;

            if (validCodec)
            {
                return;
            }

            AddInvalidResult(key, validationResults);
        }

        #endregion
    }
}