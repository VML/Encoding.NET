// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEncodingEndpoints.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 12:54 PM</created>
//  <updated>01/30/2014 12:54 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;

#endregion

namespace VML.Encoding.Interfaces
{
    public interface IEncodingEndpoints
    {
        #region Public Properties

        string ManageEndpoint { get; }
        string StatusEndpoint { get; }

        #endregion
    }
}