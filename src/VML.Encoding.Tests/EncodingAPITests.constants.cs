// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EncodingAPITests.constants.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/31/2014 10:36 AM</created>
//  <updated>01/31/2014 10:38 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;

#endregion

namespace VML.Encoding.Tests
{
    public partial class EncodingAPITests
    {
        #region Constants and Fields

        private const string AddMediaResponse = "{\"response\":{\"message\":\"Added\",\"MediaID\":\"some_mediaid\"}}";

        private const string GetMediaListResponse =
            "{\"response\":{\"media\":[{\"mediafile\":\"sourcefile\",\"mediaid\":\"mediaid\",\"mediastatus\":\"mediastatus\",\"createdate\":\"2013-01-01 12:12:12\",\"startdate\":\"2013-01-01 12:12:12\",\"finishdate\":\"2013-01-01 12:12:12\"}]}}";

        private const string GetStatusResponse =
            "{\"response\":{\"id\":\"[MediaID]\",\"userid\":\"[UserID]\",\"sourcefile\":\"[SourceFile]\",\"status\":\"[MediaStatus]\",\"notifyurl\":\"[NotifyURL]\",\"created\":\"2013-1-1\",\"started\":\"2013-1-1\",\"finished\":\"2013-1-1\",\"prevstatus\":\"[MediaStatus]\",\"downloaded\":\"2013-1-1\",\"uploaded\":\"0000-00-00 00:00:00\",\"time_left\":\"[TotalTimeLeft]\",\"progress\":\"[TotalProgress]\",\"time_left_current\":\"[StatusTimeLeft]\",\"progress_current\":\"[StatusProgress]\",\"format\":{\"id\":\"[ID]\",\"status\":\"[Status]\",\"created\":\"2013-1-1\",\"started\":\"2013-1-1\",\"finished\":\"2013-1-1\",\"s3_destination\":\"[TempS3Link]\",\"cf_destination\":\"[TempCFLink]\",\"destination\":[\"[URL]\",\"[URL_2]\",\"[URL_N]\"],\"destination_status\":[\"[Saved|Error(ErrorDescription)]\",\"[Saved|Error(ErrorDescription)]\",\"[Saved|Error(ErrorDescription)]\"]}}}";

        #endregion
    }
}