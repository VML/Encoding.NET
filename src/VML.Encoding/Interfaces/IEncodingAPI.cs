// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEncodingAPI.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/07/2014 9:31 AM</created>
//  <updated>02/07/2014 9:31 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;
using VML.Encoding.Model.Query.Response;

#endregion

namespace VML.Encoding.Interfaces
{
    public interface IEncodingAPI
    {
        #region Public Methods

        AddMediaResponse AddMedia(EncodingQuery query);

        EncodingQuery CreateQuery(QueryAction action);

        GetMediaListResponse GetMediaList();

        GetStatusResponse GetStatus(string mediaId);

        #endregion
    }
}