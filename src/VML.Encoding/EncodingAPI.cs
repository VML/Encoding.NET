// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingAPI.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>01/31/2014 10:17 AM by Ben Ramey</updated>
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

        public EncodingQuery CreateQuery(QueryAction action)
        {
            return _client.CreateQuery(action);
        }

        public GetMediaListResponse GetMediaList()
        {
            var query = CreateQuery(QueryAction.GetMediaList);
            return ExecuteQuery<GetMediaListResponse>(query);
        }

        public GetStatusResponse GetStatus(string mediaId)
        {
            if (string.IsNullOrWhiteSpace(mediaId))
            {
                throw new ArgumentNullException("mediaId");
            }

            var query = CreateQuery(QueryAction.GetStatus);
            query.MediaId = mediaId;
            return ExecuteQuery<GetStatusResponse>(query);
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