// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingQueryBlueprint.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/23/2014 11:35 AM</created>
//  <updated>01/23/2014 12:31 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Plant.Core;

#endregion

namespace VML.EncodingDotCom.Tests.Blueprints
{
    internal class EncodingQueryBlueprint : IBlueprint
    {
        #region Public Methods

        public void SetupPlant(BasePlant p)
        {
            p.DefineConstructionOf<EncodingQuery>(
                new
                    {
                        UserId = "fake_userId",
                        UserKey = "fake_userKey",
                    },
                eq =>
                    {
                        eq.MediaId = "fake_mediaid";
                        eq.SourceFile = "http://example.com";
                    });
        }

        #endregion
    }
}