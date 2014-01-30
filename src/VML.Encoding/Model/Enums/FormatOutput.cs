// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FormatOutput.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:19 PM</created>
//  <updated>01/30/2014 11:05 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.ComponentModel;
using System.Linq;
using System;

#endregion

namespace VML.Encoding.Model.Enums
{
    public enum FormatOutput
    {
        flv,
        fl9,
        wmv,
        mov,

        [Description("3gp")]
        threegp,
        mp4,
        m4v,
        ipod,
        iphone,
        ipad,
        android,
        ogg,
        webm,
        appletv,
        psp,
        zune,
        mp3,
        wma,
        m4a,
        thumbnail,
        image,
        mpeg1,
        mpeg2,
        iphone_stream,
        ipad_stream,
        muxer,
        wowza,
        wowza_multibitrate,
        roku_800,
        roku_1200,
        roku_1800,
        roku_2700,
        roku_hls,
        mpegts,
        dnxhd,
        vidly,
        vidly_lite,
        kindle_fire,
        eac3,
        smooth_streaming,
        hds,
        closed_captions,
        mov_prores,
        mxf,
        dnxhd_mxf,
        waveform,
    }
}