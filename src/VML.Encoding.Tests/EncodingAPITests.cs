// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingAPITests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>01/30/2014 4:43 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using NSubstitute;
using Plant.Core;
using VML.Encoding.Interfaces;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;
using VML.Encoding.Model.Query.Response;
using Xunit;

#endregion

namespace VML.Encoding.Tests
{
    public class EncodingAPITests
    {
        #region Constants and Fields

        private readonly EncodingAPI _api;
        private readonly BasePlant _plant;

        #endregion

        #region Constructors and Destructors

        public EncodingAPITests()
        {
            var client = Substitute.For<IEncodingClient>();
            // add media response
            client
                .Execute(Arg.Is<EncodingQuery>(eq => eq.Action == QueryAction.AddMedia))
                .Returns("{\"response\":{\"message\":\"Added\",\"MediaID\":\"some_mediaid\"}}");
            // getmedialist response
            client
                .Execute(Arg.Is<EncodingQuery>(eq => eq.Action == QueryAction.GetMediaList))
                .Returns(
                    "{\"response\":{\"media\":[{\"mediafile\":\"sourcefile\",\"mediaid\":\"mediaid\",\"mediastatus\":\"mediastatus\",\"createdate\":\"2013-01-01 12:12:12\",\"startdate\":\"2013-01-01 12:12:12\",\"finishdate\":\"2013-01-01 12:12:12\"}]}}");
            // getstatus response
            client
                .Execute(Arg.Is<EncodingQuery>(eq => eq.Action == QueryAction.GetStatus))
                .Returns(
                    @"{""response"":{""id"":""[MediaID]"",""userid"":""[UserID]"",""sourcefile"":""[SourceFile]"",""status"":""[MediaStatus]"",""notifyurl"":""[NotifyURL]"",""created"":""2013-1-1"",""started"":""2013-1-1"",""finished"":""2013-1-1"",""prevstatus"":""[MediaStatus]"",""downloaded"":""2013-1-1"",""uploaded"":""2013-1-1"",""time_left"":""[TotalTimeLeft]"",""progress"":""[TotalProgress]"",""time_left_current"":""[StatusTimeLeft]"",""progress_current"":""[StatusProgress]"",""format"":[{""id"":""[ID]"",""status"":""[Status]"",""created"":""2013-1-1"",""started"":""2013-1-1"",""finished"":""2013-1-1"",""s3_destination"":""[TempS3Link]"",""cf_destination"":""[TempCFLink]"",""destination"":[""[URL]"",""[URL_2]"",""[URL_N]""],""destination_status"":[""[Saved|Error(ErrorDescription)]"",""[Saved|Error(ErrorDescription)]"",""[Saved|Error(ErrorDescription)]""]},]}}");
            

            _api = new EncodingAPI(client);
            _plant = new BasePlant().WithBlueprintsFromAssemblyOf<EncodingQueryTests>();
        }

        #endregion

        #region Public Methods

        [Fact]
        public void AddMedia()
        {
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
        public void GetMediaList()
        {
            var query = _plant.Create<EncodingQuery>();
            GetMediaListResponse response = _api.GetMediaList(query);

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
        public void GetMediaList_NullQuery_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _api.GetMediaList(null));
        }

        [Fact]
        public void GetStatus()
        {
            var query = _plant.Create<EncodingQuery>();
            GetStatusResponse response = _api.GetStatus(query);

            Assert.NotNull(response);
            Assert.Equal("[MediaID]", response.ID);
        }

        [Fact]
        public void GetStatus_NullQuery_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _api.GetStatus(null));
        }

        #endregion
    }
}