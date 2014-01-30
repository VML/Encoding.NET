// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IQueryExecutor.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 11:23 AM</created>
//  <updated>01/30/2014 11:27 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;

#endregion

namespace VML.Encoding.Interfaces
{
    public interface IQueryExecutor
    {
        #region Public Methods

        void Execute(string query);

        #endregion
    }
}