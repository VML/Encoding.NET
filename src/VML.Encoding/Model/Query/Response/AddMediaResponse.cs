// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AddMediaResponse.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>01/30/2014 4:01 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;

#endregion

namespace VML.Encoding.Model.Query.Response
{
    public class AddMediaResponse : BaseResponse
    {
        #region Public Properties

        public string MediaID { get; set; }

        #endregion
    }
}