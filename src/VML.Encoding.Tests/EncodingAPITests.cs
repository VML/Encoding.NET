// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingAPITests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>02/13/2014 1:11 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using NSubstitute;
using Newtonsoft.Json.Linq;
using VML.Encoding.Interfaces;
using Xunit;

#endregion

namespace VML.Encoding.Tests
{
    public partial class EncodingAPITests
    {
        #region Constants and Fields

        private readonly EncodingAPI _api;
        private readonly IEncodingClient _client;

        #endregion

        #region Constructors and Destructors

        public EncodingAPITests()
        {
            _client = Substitute.For<IEncodingClient>();
            _api = new EncodingAPI(_client);
        }

        #endregion

        #region Public Methods


        [Fact]
        public void AddMedia()
        {
            _client.Execute(Arg.Any<JObject>()).Returns(AddMediaResponse);

            JObject query = new JObject();
            query["action"] = "AddMedia";
            JObject response = _api.AddMedia(query);

            Assert.NotNull(response);
            Assert.Equal("Added", response["message"]);
        }

        [Fact]
        public void AddMedia_NullQuery_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _api.AddMedia(null));
        }

        [Fact]
        public void ExecuteQuery_WrongCredentials_ParsesResponse()
        {
            _client
                .Execute(Arg.Any<JObject>())
                .Returns(WrongCredsResponse);

            JObject response = null;
            Assert.DoesNotThrow(() => response = _api.GetMediaList());
            Assert.NotNull(response);
            Assert.NotNull(response["errors"]);
            Assert.NotNull(response["errors"]["error"]);
            Assert.NotEqual(string.Empty, response["errors"]["error"]);
        }

        [Fact]
        public void GetMediaList()
        {
            _client.Execute(Arg.Any<JObject>())
                   .Returns(GetMediaListResponse);

            JObject response = _api.GetMediaList();

            Assert.NotNull(response);
            Assert.Equal(1, ((JArray)response["media"]).Count);
            var media = response["media"][0];
            Assert.Equal(new DateTime(2013, 1, 1, 12, 12, 12, 0), media["createdate"]);
            Assert.Equal(new DateTime(2013, 1, 1, 12, 12, 12, 0), media["finishdate"]);
            Assert.Equal(new DateTime(2013, 1, 1, 12, 12, 12, 0), media["startdate"]);
            Assert.Equal("mediastatus", media["mediastatus"]);
            Assert.Equal("mediaid", media["mediaid"]);
            Assert.Equal("sourcefile", media["mediafile"]);
        }

        [Fact]
        public void GetStatus()
        {
            _client
                .Execute(Arg.Any<JObject>())
                .Returns(GetStatusResponse);

            JObject response = _api.GetStatus("[MediaID]");

            Assert.NotNull(response);
            Assert.Equal("[MediaID]", response["id"]);
        }

        [Fact]
        public void GetStatus_BlankMediaId_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _api.GetStatus(string.Empty));
        }

        [Fact]
        public void GetStatus_NullMediaId_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _api.GetStatus(null));
        }

        [Fact]
        public void GetStatus_WhitespaceMediaId_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _api.GetStatus(string.Empty));
        }

        #endregion
    }
}