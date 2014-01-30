// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="QueryExecutor.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 11:23 AM</created>
//  <updated>01/30/2014 4:01 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using RestSharp;
using VML.Encoding.Endpoints;
using VML.Encoding.Interfaces;

#endregion

namespace VML.Encoding
{
    public class QueryExecutor : IQueryExecutor
    {
        #region Constants and Fields

        private readonly IEncodingEndpoints _endpoints;
        private readonly IRestClient _restClient;

        #endregion

        #region Constructors and Destructors

        public QueryExecutor(IEncodingEndpoints endpoints)
            : this(endpoints, null)
        {
        }

        public QueryExecutor(IEncodingEndpoints endpoints, IRestClient restClient)
        {
            _endpoints = endpoints ?? new HttpsEndpoints();
            _restClient = restClient ?? new RestClient();
        }

        #endregion

        #region Public Methods

        public virtual string ExecuteQuery(string data)
        {
            _restClient.BaseUrl = _endpoints.ManageEndpoint;

            RestRequest request = new RestRequest(Method.POST);
            request.AddParameter("json", data, ParameterType.RequestBody);
            IRestResponse restResponse = _restClient.Execute(request);

            return restResponse.Content;
        }

        public virtual string ExecuteStatus(string data)
        {
            return string.Empty;
        }

        #endregion
    }
}