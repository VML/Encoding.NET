// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ResponseError.cs" company="VML">
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
    public class ResponseError
    {
        #region Public Properties

        public string[] Error { get; set; }

        #endregion
    }
}