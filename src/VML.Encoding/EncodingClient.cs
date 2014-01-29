// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingClient.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 8:59 AM</created>
//  <updated>01/29/2014 4:02 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Interfaces;
using VML.Encoding.Model.Query;
using VML.Encoding.Model.Validation;

#endregion

namespace VML.Encoding
{
    public class EncodingClient
    {
        #region Constants and Fields

        private readonly IEncodingCredentials _credentials;

        #endregion

        #region Constructors and Destructors

        public EncodingClient(IEncodingCredentials credentials)
        {
            credentials.Validate();

            _credentials = credentials;
        }

        #endregion

        #region Public Methods

        public EncodingQuery CreateQuery(QueryAction action)
        {
            var query = new EncodingQuery(_credentials)
                {
                    Action = action
                };

            return query;
        }

        public bool Execute(EncodingQuery query)
        {
            query.Validate();

            return false;
        }

        #endregion
    }
}