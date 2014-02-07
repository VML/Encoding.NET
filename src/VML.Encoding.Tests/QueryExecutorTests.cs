// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="QueryExecutorTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>01/30/2014 4:14 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using NSubstitute;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using VML.Encoding.Endpoints;
using VML.Encoding.Model;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;
using Xunit;

#endregion

namespace VML.Encoding.Tests
{
    public class QueryExecutorTests
    {
        #region Public Methods

        [Fact]
        public void ExecuteQuery()
        {
            string expectedData = "fake_data";
            var endpoints = new HttpsEndpoints();
            var mockClient = Substitute.For<IRestClient>();
            var executor = new QueryExecutor(endpoints, mockClient);

            IRestRequest request = null;
            mockClient
                .WhenForAnyArgs(client => client.Execute(Arg.Any<IRestRequest>()))
                .Do(ci => request = ci.Args().First() as IRestRequest);

            executor.ExecuteQuery(expectedData);

            Assert.NotNull(request);
            Assert.Equal("json", request.Parameters.First().Name);
            Assert.Equal(ParameterType.GetOrPost, request.Parameters.First().Type);
            Assert.Equal(expectedData, request.Parameters[0].Value);
            Assert.Equal(mockClient.BaseUrl, endpoints.ManageEndpoint);
            mockClient.Received(1).Execute(request);
        }

        #endregion
    }
}