// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AudioCodec.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:28 PM</created>
//  <updated>01/30/2014 4:01 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;

#endregion

namespace VML.Encoding.Model.Enums
{
    [Flags]
    public enum AudioCodec
    {
        ac3 = 0x1,
        libfaac = 0x2,
        dolby_aac = 0x4,
        dolby_heaac = 0x10,
        dolby_heaacv2 = 0x20,
        eac3 = 0x40,
        wmav2 = 0x100,
        libmp3lame = 0x200,
        libvorbis = 0x400,
        libamr_nb = 0x1000,
        pcm_s16be = 0x2000,
        pcm_s16le = 0x4000,
        mp2 = 0x10000,
        copy = 0x20000,
        pcm_s24le = 0x40000,
        pcm_s24l = 0x100000
    }
}