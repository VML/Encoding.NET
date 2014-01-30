// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingClient.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 8:59 AM</created>
//  <updated>01/30/2014 4:01 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using VML.Encoding.Endpoints;
using VML.Encoding.Interfaces;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Interfaces;
using VML.Encoding.Model.Query;
using VML.Encoding.Model.Validation;

#endregion

namespace VML.Encoding
{
    public class EncodingClient : IEncodingClient
    {
        #region Constants and Fields

        private readonly IEncodingCredentials _credentials;
        private readonly IQueryExecutor _executor;

        #endregion

        #region Constructors and Destructors

        public EncodingClient(IEncodingCredentials credentials)
            : this(credentials, null)
        {
        }

        public EncodingClient(IEncodingCredentials credentials, IQueryExecutor executor)
        {
            credentials.Validate();

            _credentials = credentials;
            _executor = executor ?? new QueryExecutor(new HttpsEndpoints());
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

        public string Execute(EncodingQuery query)
        {
            query.Validate();

            JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                };
            string json = JsonConvert.SerializeObject(new { query }, settings);

            return _executor.ExecuteQuery(json);
        }

        #endregion
    }
}