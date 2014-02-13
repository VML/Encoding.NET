// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEncodingAPI.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/07/2014 9:31 AM</created>
//  <updated>02/13/2014 1:27 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;
using Newtonsoft.Json.Linq;

#endregion

namespace VML.Encoding.Interfaces
{
    public interface IEncodingAPI
    {
        #region Public Methods

        JObject AddMedia(JObject query);

        JObject CancelMedia(string mediaId);

        JObject GetMediaList();

        JObject GetStatus(string mediaId);

        #endregion
    }
}