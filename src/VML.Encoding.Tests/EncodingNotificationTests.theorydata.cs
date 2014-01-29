// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingNotificationTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/29/2014 10:29 AM</created>
//  <updated>01/29/2014 10:41 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace VML.Encoding.Tests
{
    public partial class EncodingNotificationTests
    {
        public static IEnumerable<object[]> XmlResults
        {
            get
            {
                return new object[][]
                    {
                        new [] { @"<?xml version=""1.0""?>
<result>
    <mediaid>MediaID</mediaid>
    <source>SourceFile</source>
    <status>Finished</status>
    <description> ErrorDescription</description>
    <format>
        <output>JSON</output>
        <destination>http://example/1</destination>
        <destination_status>Saved</destination_status>
        <destination>http://example/2</destination>
        <destination_status>Error</destination_status>
        <destination>http://example/n</destination>
        <destination_status>Error</destination_status>
        <status>Finished</status>
        <description>ErrorDescription</description>
        <suggestion>ErrorSuggestion</suggestion>
    </format>
</result>" }, 
                        new [] { @"<?xml version=""1.0""?>
<result>
    <mediaid>MediaID</mediaid>
    <source>SourceFile</source>
    <status>Error</status>
    <description> ErrorDescription</description>
    <format>
        <output>XML</output>
        <destination>http://example/1</destination>
        <destination_status>Saved</destination_status>
        <destination>http://example/2</destination>
        <destination_status>Error</destination_status>
        <destination>http://example/n</destination>
        <destination_status>Error</destination_status>
        <status>Error</status>
        <description>ErrorDescription</description>
        <suggestion>ErrorSuggestion</suggestion>
    </format>
</result>" }, 
                    };
            }
        }
    }
}