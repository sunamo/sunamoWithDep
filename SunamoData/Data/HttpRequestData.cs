namespace SunamoData.Data;

public class HttpRequestData
{
    public Dictionary<string, string> headers = new Dictionary<string, string>();
    public string contentType = null;
    public string accept = null;
    public Encoding encodingPostData;
    //public int? timeout = null; // Není v třídě HttpKnownHeaderNames
    public bool? keepAlive = null;
    /// <summary>
    /// Assign: StreamContent,ByteArrayContent,FormUrlEncodedContent,StringContent,MultipartContent,MultipartFormDataContent
    /// </summary>
    public HttpContent content = null;
    public int timeoutInS = 60;
    /// <summary>
    /// null for auto detect also when will be in headers available different value
    /// </summary>
    public bool? forceEndoding = false;
    /// <summary>
    /// Must be set also forceEndoding = true
    /// </summary>
    public Encoding forcedEncoding = null;
    public bool throwEx = true;
}
