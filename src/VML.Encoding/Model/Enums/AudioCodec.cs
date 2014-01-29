// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AudioCodec.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:28 PM</created>
//  <updated>01/29/2014 2:48 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;

#endregion

namespace VML.Encoding.Model.Enums
{
    public enum AudioCodec
    {
        ac3,
        libfaac,
        dolby_aac,
        dolby_heaac,
        dolby_heaacv2,
        eac3,
        wmav2,
        libmp3lame,
        libvorbis,
        libamr_nb,
        pcm_s16be,
        pcm_s16le,
        mp2,
        copy,
        pcm_s24le,
        pcm_s24l
    }
}