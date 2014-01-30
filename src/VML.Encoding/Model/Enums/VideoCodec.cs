// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="VideoCodec.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:25 PM</created>
//  <updated>01/30/2014 11:05 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;

#endregion

namespace VML.Encoding.Model.Enums
{
    [Flags]
    public enum VideoCodec
    {
        flv = 0x200000,
        libx264 = 0x1,
        vp6 = 0x2,
        wmv2 = 0x4,
        msmpeg4 = 0x10,
        h263 = 0x20,
        mpeg4 = 0x40,
        libtheora = 0x100,
        libvpx = 0x200,
        none = 0x400,
        mpeg2video = 0x1000,
        mpeg1video = 0x2000,
        xdcam = 0x4000,
        dvcpro = 0x10000,
        dvcpro50 = 0x20000,
        dvcprohd = 0x40000,
        xdcamhd422 = 0x100000
    }
}