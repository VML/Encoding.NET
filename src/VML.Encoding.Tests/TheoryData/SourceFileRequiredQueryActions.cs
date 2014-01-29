// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SourceFileRequiredQueryActions.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/24/2014 12:31 PM</created>
//  <updated>01/29/2014 10:17 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VML.Encoding.Model;

#endregion

namespace VML.Encoding.Tests.TheoryData
{
    public class SourceFileRequiredQueryActions : IEnumerable<object[]>
    {
        #region Constants and Fields

        private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { QueryAction.AddMedia },
                new object[] { QueryAction.AddMediaBenchmark },
            };

        #endregion

        #region Public Methods

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        #endregion

        #region Explicit Interface Methods

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}