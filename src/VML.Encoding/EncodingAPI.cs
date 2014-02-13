// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingAPI.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>02/13/2014 1:30 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using VML.Encoding.Interfaces;

#endregion

namespace VML.Encoding
{
    public class EncodingAPI : IEncodingAPI
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

        public JObject AddMedia(JObject query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            query["action"] = "AddMedia";
            return ExecuteQuery(query);
        }

        public JObject CancelMedia(string mediaId)
        {
            JObject query = new JObject();
            query["action"] = "CancelMedia";
            query["mediaid"] = mediaId;
            return ExecuteQuery(query);
        }

        public JObject GetMediaList()
        {
            JObject query = new JObject();
            query["action"] = "GetMediaList";
            return ExecuteQuery(query);
        }

        public JObject GetStatus(string mediaId)
        {
            if (string.IsNullOrWhiteSpace(mediaId))
            {
                throw new ArgumentNullException("mediaId");
            }

            JObject query = new JObject();
            query["action"] = "GetStatus";
            query["mediaid"] = mediaId;
            return ExecuteQuery(query);
        }

        #endregion

        #region Methods

        private JObject ExecuteQuery(JObject query)
        {
            string responseContent = _client.Execute(query);
            JObject rawResponse = JObject.Parse(responseContent);

            return (JObject)rawResponse["response"];
        }

        #endregion
    }
}