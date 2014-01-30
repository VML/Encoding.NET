// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseResponse.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 1:40 PM</created>
//  <updated>01/30/2014 1:41 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;

#endregion

namespace VML.Encoding.Model.Query.Response
{
    public class BaseResponse
    {
        #region Public Properties

        public ResponseError Errors { get; set; }
        public string Message { get; set; }

        #endregion
    }
}