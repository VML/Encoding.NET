// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MediaIdRequiredQueryActions.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/23/2014 9:33 AM</created>
//  <updated>01/23/2014 10:50 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace VML.Encoding.Tests.TheoryData
{
    public class MediaIdRequiredQueryActions : IEnumerable<object[]>
    {
        #region Constants and Fields

        private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { QueryAction.UpdateMedia },
                new object[] { QueryAction.ProcessMedia },
                new object[] { QueryAction.CancelMedia },
                new object[] { QueryAction.GetMediaInfo },
                new object[] { QueryAction.GetStatus }
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