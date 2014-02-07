// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseResponse.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>02/07/2014 10:08 AM by Ben Ramey</updated>
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

        public bool HasError
        {
            get
            {
                return Errors != null
                       && Errors.Error != null
                       && Errors.Error.Length > 0;
            }
        }

        public string Message { get; set; }

        #endregion
    }
}