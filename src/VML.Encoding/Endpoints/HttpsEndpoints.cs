// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="HttpsEndpoints.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/30/2014 2:23 PM</created>
//  <updated>02/13/2014 1:11 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using VML.Encoding.Interfaces;

#endregion

namespace VML.Encoding.Endpoints
{
    public class HttpsEndpoints : IEncodingEndpoints
    {
        #region Public Properties

        public virtual string ManageEndpoint
        {
            get
            {
                return "https://manage.encoding.com";
            }
        }

        public virtual string StatusEndpoint
        {
            get
            {
                return "https://status.encoding.com/status.php?format=json";
            }
        }

        #endregion
    }
}