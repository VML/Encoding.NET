// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Region.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 2:18 PM</created>
//  <updated>01/30/2014 11:05 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.ComponentModel;
using System.Linq;

#endregion

namespace VML.Encoding.Model.Enums
{
    public enum Region
    {
        [Description("us-east-1")]
        USEast1,

        [Description("us-west-1")]
        USWest1,

        [Description("us-west-2")]
        USWest2,

        [Description("eu-west-1")]
        EUWest1,

        [Description("ap-southeast-1")]
        APSoutheast1,

        [Description("ap-southeast-2")]
        APSoutheast2,

        [Description("ap-northeast-1")]
        APNortheast1,

        [Description("sa-east-1")]
        SAEast1
    }
}