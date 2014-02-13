// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingClientTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/24/2014 12:31 PM</created>
//  <updated>02/13/2014 1:11 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NSubstitute;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using VML.Encoding.Interfaces;
using VML.Encoding.Tests.Support;
using Xunit;
using Xunit.Extensions;

#endregion

namespace VML.Encoding.Tests
{
    public partial class EncodingClientTests
    {
        #region Public Methods

        [Theory]
        [PropertyData("InvalidCredentials")]
        public void Constructor_InvalidCredentials_ThrowsException(TestCredentials creds)
        {
            Assert.Throws<ValidationException>(() => new EncodingClient(creds));
        }

        [Theory]
        [PropertyData("ValidQueries")]
        public void Execute_SerializesQuery(JObject query)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                };
            string serializedQuery = JsonConvert.SerializeObject(new { query }, settings);
            var mockExecutor = Substitute.For<IQueryExecutor>();
            var creds = new TestCredentials();
            var client = new EncodingClient(creds, mockExecutor);

            client.Execute(query);

            mockExecutor.Received().ExecuteQuery(serializedQuery);
        }

        #endregion
    }
}