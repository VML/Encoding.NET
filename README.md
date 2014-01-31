# Encoding.NET

A C# API wrapper for the Encoding.com API.

See the Encoding.com API documentation for details on various calls, required fields and response data.  You can find the documentation here: [http://www.encoding.com/api](http://www.encoding.com/api)

## Basic Usage

Here some basic examples of how to use the this library.  Check out the GitHub wiki for documentation and more examples.

### Setup

    var credentials = new BasicCredentials("<userid>", "<userkey>");
    var api = new EncodingAPI(credentials);

### GetStatus
  
    string mediaId = "xxxxx";
    GetStatusResponse response = api.GetStatus(mediaId);
  
### GetMediaList

    GetMediaListResponse response = api.GetMediaList();
  
