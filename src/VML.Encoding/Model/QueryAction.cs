// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="QueryAction.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/28/2014 5:59 PM</created>
//  <updated>01/29/2014 10:17 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;

#endregion

namespace VML.Encoding.Model
{
    /// <summary>
    ///     Available encoding.com query actions.  http://www.encoding.com/api#ActionList
    /// </summary>
    [Flags]
    public enum QueryAction
    {
        AddMedia = 0,
        AddMediaBenchmark = 2,
        UpdateMedia = 4,
        ProcessMedia = 8,
        CancelMedia = 16,
        GetMediaList = 32,
        GetStatus = 64,
        GetMediaInfo = 128,
        GetMediaInfoEx = 256,
        RestartMedia = 1024,
        RestartMediaErrors = 2048,
        RestartMediaTask = 4096,
        StopMedia = 8192
    }
}