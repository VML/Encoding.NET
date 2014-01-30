// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="QueryExecutor.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 11:23 AM</created>
//  <updated>01/30/2014 12:59 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using VML.Encoding.Interfaces;

#endregion

namespace VML.Encoding
{
    public class QueryExecutor : IQueryExecutor
    {
        #region Constants and Fields

        private IEncodingEndpoints _endpoints;

        #endregion

        #region Constructors and Destructors

        public QueryExecutor(IEncodingEndpoints endpoints)
        {
            _endpoints = endpoints;
        }

        #endregion

        #region Public Methods

        public virtual void ExecuteQuery(string data)
        {
        }

        public virtual void ExecuteStatus(string data)
        {
        }

        #endregion
    }
}