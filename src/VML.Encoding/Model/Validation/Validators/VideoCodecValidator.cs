// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ValidVideoCodec.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:59 PM</created>
//  <updated>01/29/2014 4:15 PM by Ben Ramey</updated>
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
    public class VideoCodecValidator : BaseValidator<VideoCodec>
    {
        #region Constants and Fields

        private static readonly Dictionary<FormatOutput, VideoCodec> Rules = new Dictionary
            <FormatOutput, VideoCodec>
            {
                { FormatOutput.flv, VideoCodec.flv | VideoCodec.libx264 | VideoCodec.vp6 },
                { FormatOutput.fl9, VideoCodec.libx264 },
                { FormatOutput.wmv, VideoCodec.wmv2 | VideoCodec.msmpeg4 },
                { FormatOutput.zune, VideoCodec.wmv2 | VideoCodec.msmpeg4 },
                { FormatOutput.threegp, VideoCodec.h263 | VideoCodec.mpeg4 | VideoCodec.libx264 },
                { FormatOutput.android, VideoCodec.h263 | VideoCodec.mpeg4 | VideoCodec.libx264 },
                { FormatOutput.m4v, VideoCodec.mpeg4 },
                { FormatOutput.mp4, VideoCodec.mpeg4 | VideoCodec.libx264 },
                { FormatOutput.ipod, VideoCodec.mpeg4 | VideoCodec.libx264 },
                { FormatOutput.iphone, VideoCodec.mpeg4 | VideoCodec.libx264 },
                { FormatOutput.ipad, VideoCodec.mpeg4 | VideoCodec.libx264 },
                { FormatOutput.appletv, VideoCodec.mpeg4 | VideoCodec.libx264 },
                { FormatOutput.psp, VideoCodec.mpeg4 | VideoCodec.libx264 },
                { FormatOutput.ogg, VideoCodec.libtheora },
                { FormatOutput.webm, VideoCodec.libvpx },
                { FormatOutput.mp3, VideoCodec.none },
                { FormatOutput.wma, VideoCodec.none },
                { FormatOutput.mpeg2, VideoCodec.mpeg2video },
                { FormatOutput.mpeg1, VideoCodec.mpeg1video },
                {
                    FormatOutput.mov,
                    VideoCodec.mpeg4 | VideoCodec.libx264 | VideoCodec.xdcam | VideoCodec.dvcpro | VideoCodec.dvcpro50
                    | VideoCodec.dvcprohd
                },
                { FormatOutput.mpegts, VideoCodec.libx264 | VideoCodec.mpeg2video },
                {
                    FormatOutput.mxf,
                    VideoCodec.dvcpro | VideoCodec.dvcpro50 | VideoCodec.dvcprohd | VideoCodec.xdcamhd422
                },
            };

        #endregion

        #region Constructors and Destructors

        public VideoCodecValidator(string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
        }

        #endregion

        #region Properties

        protected override string DefaultMessageTemplate
        {
            get
            {
                return "You must set a valid video codec for the corresponding output value.";
            }
        }

        #endregion

        #region Methods

        protected override void DoValidate(
            VideoCodec objectToValidate, object currentTarget, string key, ValidationResults validationResults)
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