// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingAPITests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>02/07/2014 2:07 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using NSubstitute;
using Plant.Core;
using VML.Encoding.Interfaces;
using VML.Encoding.Model;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;
using VML.Encoding.Model.Query.Response;
using Xunit;

#endregion

namespace VML.Encoding.Tests
{
    public partial class EncodingAPITests
    {
        #region Constants and Fields

        private readonly EncodingAPI _api;
        private readonly IEncodingClient _client;
        private readonly BasePlant _plant;

        #endregion

        #region Constructors and Destructors

        public EncodingAPITests()
        {
            _plant = new BasePlant().WithBlueprintsFromAssemblyOf<EncodingQueryTests>();

            _client = Substitute.For<IEncodingClient>();
            _api = new EncodingAPI(_client);
        }

        #endregion

        #region Public Methods

        [Fact]
        public void AddMedia()
        {
            _client
                .Execute(Arg.Is<EncodingQuery>(eq => eq.Action == QueryAction.AddMedia))
                .Returns(AddMediaResponse);

            var query = _plant.Create<EncodingQuery>();
            AddMediaResponse response = _api.AddMedia(query);

            Assert.NotNull(response);
            Assert.Equal("Added", response.Message);
        }

        [Fact]
        public void AddMedia_NullQuery_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _api.AddMedia(null));
        }

        [Fact]
        public void ExecuteQuery_WrongCredentials_ParsesResponse()
        {
            var query = _plant.Create<EncodingQuery>();
            query.Action = QueryAction.GetMediaList;
            _client
                .Execute(Arg.Is<EncodingQuery>(eq => eq.Action == QueryAction.GetMediaList))
                .Returns(WrongCredsResponse);
            _client.CreateQuery(Arg.Any<QueryAction>())
                   .Returns(query);

            GetMediaListResponse response = null;
            Assert.DoesNotThrow(() => response = _api.GetMediaList());
            Assert.NotNull(response);
            Assert.NotNull(response.Errors);
            Assert.NotNull(response.Errors.Error);
            Assert.NotEqual(string.Empty, response.Errors.Error);
        }

        [Fact]
        public void GetMediaList()
        {
            var query = _plant.Create<EncodingQuery>();
            query.Action = QueryAction.GetMediaList;

            _client.CreateQuery(Arg.Any<QueryAction>())
                   .Returns(query);
            _client.Execute(Arg.Is<EncodingQuery>(eq => TestForMediaList(eq)))
                   .Returns(GetMediaListResponse);

            GetMediaListResponse response = _api.GetMediaList();

            Assert.NotNull(response);
            Assert.Equal(1, response.Media.Length);
            Assert.Equal(new DateTime(2013, 1, 1, 12, 12, 12, 0), response.Media[0].CreateDate);
            Assert.Equal(new DateTime(2013, 1, 1, 12, 12, 12, 0), response.Media[0].FinishDate);
            Assert.Equal(new DateTime(2013, 1, 1, 12, 12, 12, 0), response.Media[0].StartDate);
            Assert.Equal("mediastatus", response.Media[0].MediaStatus);
            Assert.Equal("mediaid", response.Media[0].MediaID);
            Assert.Equal("sourcefile", response.Media[0].MediaFile);
        }

        [Fact]
        public void GetStatus()
        {
            var query = _plant.Create<EncodingQuery>();
            query.Action = QueryAction.GetStatus;

            _client.CreateQuery(Arg.Any<QueryAction>())
                   .Returns(query);
            _client
                .Execute(Arg.Is<EncodingQuery>(eq => eq.Action == QueryAction.GetStatus))
                .Returns(GetStatusResponse);

            GetStatusResponse response = _api.GetStatus(query.MediaId);

            Assert.NotNull(response);
            Assert.Equal("[MediaID]", response.ID);
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

        #region Methods

        protected bool TestForMediaList(EncodingQuery eq)
        {
            return eq.Action == QueryAction.GetMediaList;
        }

        #endregion
    }
}