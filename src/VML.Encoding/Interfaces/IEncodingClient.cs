// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEncodingClient.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>01/30/2014 4:01 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;

#endregion

namespace VML.Encoding.Interfaces
{
    public interface IEncodingClient
    {
        #region Public Methods

        EncodingQuery CreateQuery(QueryAction action);

        string Execute(EncodingQuery query);

        #endregion
    }
}