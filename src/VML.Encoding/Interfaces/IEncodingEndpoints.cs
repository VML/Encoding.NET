// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEncodingEndpoints.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>02/13/2014 1:11 PM by Ben Ramey</updated>
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