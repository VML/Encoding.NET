// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="QueryAction.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:12 PM</created>
//  <updated>01/29/2014 4:02 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;

#endregion

namespace VML.Encoding.Model.Enums
{
    /// <summary>
    ///     Available encoding.com query actions.  http://www.encoding.com/api#ActionList
    /// </summary>
    [Flags]
    public enum QueryAction
    {
        AddMedia = 0x1,
        AddMediaBenchmark = 0x2,
        UpdateMedia = 0x4,
        ProcessMedia = 0x10,
        CancelMedia = 0x20,
        GetMediaList = 0x40,
        GetStatus = 0x100,
        GetMediaInfo = 0x200,
        GetMediaInfoEx = 0x400,
        RestartMedia = 0x1000,
        RestartMediaErrors = 0x2000,
        RestartMediaTask = 0x4000,
        StopMedia = 0x10000
    }
}