// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingQueryBlueprint.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/24/2014 12:31 PM</created>
//  <updated>01/29/2014 10:17 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Plant.Core;
using VML.Encoding.Model;
using VML.Encoding.Model.Query;
using VML.Encoding.Tests.Support;

#endregion

namespace VML.Encoding.Tests.Blueprints
{
    internal class EncodingQueryBlueprint : IBlueprint
    {
        #region Public Methods

        public void SetQueryProperties(EncodingQuery eq)
        {
            eq.MediaId = "fake_mediaid";
            eq.SourceFiles = new[] { "http://example.com" };
        }

        public void SetupPlant(BasePlant p)
        {
            p.DefineVariationOf<EncodingQuery>(
                "nouserkey",
                new
                    {
                        UserKey = string.Empty
                    },
                SetQueryProperties);
            p.DefineVariationOf<EncodingQuery>(
                "nouserid",
                new
                    {
                        UserId = string.Empty
                    },
                SetQueryProperties);

            p.DefineConstructionOf<EncodingQuery>(
                new
                    {
                        credentials = new TestCredentials()
                    },
                SetQueryProperties);
        }

        #endregion
    }
}