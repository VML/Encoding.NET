// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ResponseWrapper.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>01/30/2014 4:01 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;

#endregion

namespace VML.Encoding.Model.Query.Response
{
    public class ResponseWrapper<T>
    {
        #region Public Properties

        public T Response { get; set; }

        #endregion
    }
}