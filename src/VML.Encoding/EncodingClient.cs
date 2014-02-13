// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingClient.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 8:59 AM</created>
//  <updated>02/13/2014 1:31 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using VML.Encoding.Endpoints;
using VML.Encoding.Interfaces;
using VML.Encoding.Support;

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

        public string Execute(JObject query)
        {
            query["userid"] = _credentials.UserId;
            query["userkey"] = _credentials.UserKey;

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