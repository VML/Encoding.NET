// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingAPI.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 1:32 PM</created>
//  <updated>01/30/2014 1:59 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Newtonsoft.Json;
using VML.Encoding.Interfaces;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Interfaces;
using VML.Encoding.Model.Query;
using VML.Encoding.Model.Query.Response;

#endregion

namespace VML.Encoding
{
    public class EncodingAPI
    {
        #region Constants and Fields

        private readonly IEncodingClient _client;

        #endregion

        #region Constructors and Destructors

        public EncodingAPI(IEncodingCredentials credentials)
            : this(new EncodingClient(credentials))
        {
        }

        public EncodingAPI(IEncodingClient client)
        {
            _client = client;
        }

        #endregion

        #region Public Methods

        public AddMediaResponse AddMedia(EncodingQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            query.Action = QueryAction.AddMedia;
            return ExecuteQuery<AddMediaResponse>(query);
        }

        public GetMediaListResponse GetMediaList(EncodingQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            query.Action = QueryAction.GetMediaList;
            return ExecuteQuery<GetMediaListResponse>(query);
        }

        #endregion

        #region Methods

        private T ExecuteQuery<T>(EncodingQuery query)
        {
            string responseContent = _client.Execute(query);

            ResponseWrapper<T> responseWrapper = JsonConvert.DeserializeObject<ResponseWrapper<T>>(responseContent);
            return responseWrapper.Response;
        }

        #endregion
    }
}