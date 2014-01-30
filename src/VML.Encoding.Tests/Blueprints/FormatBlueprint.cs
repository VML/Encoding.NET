// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FormatBlueprint.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 3:15 PM</created>
//  <updated>01/30/2014 11:05 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using Plant.Core;
using VML.Encoding.Model.Enums;
using VML.Encoding.Model.Query;

#endregion

namespace VML.Encoding.Tests.Blueprints
{
    internal class FormatBlueprint : IBlueprint
    {
        #region Public Methods

        public void SetupPlant(BasePlant p)
        {
            p.DefinePropertiesOf(
                new Format
                    {
                        Output = FormatOutput.flv,
                        CXMode = 1
                    });
        }

        #endregion
    }
}