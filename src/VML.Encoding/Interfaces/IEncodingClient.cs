// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEncodingClient.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>02/13/2014 1:27 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using Newtonsoft.Json.Linq;

#endregion

namespace VML.Encoding.Interfaces
{
    public interface IEncodingClient
    {
        #region Public Methods

        string Execute(JObject query);

        #endregion
    }
}