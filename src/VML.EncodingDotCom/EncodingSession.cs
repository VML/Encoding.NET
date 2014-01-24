// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingSession.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/22/2014 4:16 PM</created>
//  <updated>01/23/2014 10:58 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using VML.EncodingDotCom.Validation;

#endregion

namespace VML.EncodingDotCom
{
    public class EncodingSession : IDisposable
    {
        #region Constants and Fields

        private readonly string _userId;
        private readonly string _userKey;

        #endregion

        #region Constructors and Destructors

        public EncodingSession(string userId, string userKey)
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

        public void Dispose()
        {
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