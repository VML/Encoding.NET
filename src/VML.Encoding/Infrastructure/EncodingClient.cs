﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingClient.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/28/2014 5:59 PM</created>
//  <updated>01/28/2014 6:00 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using VML.Encoding.Model;
using VML.Encoding.Model.Validation;

#endregion

namespace VML.Encoding.Infrastructure
{
    public class EncodingClient
    {
        #region Constants and Fields

        private readonly string _userId;
        private readonly string _userKey;

        #endregion

        #region Constructors and Destructors

        public EncodingClient(string userId, string userKey)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException("userId");
            }
            if (string.IsNullOrWhiteSpace(userKey))
            {
                throw new ArgumentNullException("userKey");
            }

            _userId = userId;
            _userKey = userKey;
        }

        #endregion

        #region Public Methods

        public EncodingQuery CreateQuery(QueryAction action)
        {
            var query = new EncodingQuery(_userId, _userKey)
                {
                    Action = action
                };

            return query;
        }

        public bool Execute(EncodingQuery query)
        {
            if (!query.IsValid(true))
            {
                return false;
            }

            return false;
        }

        #endregion
    }
}