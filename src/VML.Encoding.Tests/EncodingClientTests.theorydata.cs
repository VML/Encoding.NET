﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingClientTests.theorydata.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/24/2014 12:31 PM</created>
//  <updated>01/30/2014 11:29 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;
using VML.Encoding.Tests.Support;

#endregion

namespace VML.Encoding.Tests
{
    public partial class EncodingClientTests
    {
        #region Public Properties

        public static IEnumerable<object[]> InvalidCredentials
        {
            get
            {
                return new object[][]
                    {
                        new[] { new TestCredentials { UserId = " " } },
                        new[] { new TestCredentials { UserKey = " " } },
                        new[] { new TestCredentials { UserId = null } },
                        new[] { new TestCredentials { UserKey = null } },
                        new[] { new TestCredentials { UserId = string.Empty } },
                        new[] { new TestCredentials { UserKey = string.Empty } },
                    };
            }
        }

        public static IEnumerable<object[]> ValidQueries
        {
            get
            {
                return new[]
                    {
                        new object[]
                            {
                                new EncodingQuery(new TestCredentials())
                                    {
                                        Action = QueryAction.AddMedia,
                                    },
                                string.Empty
                            },
                    };
            }
        }

        #endregion
    }
}