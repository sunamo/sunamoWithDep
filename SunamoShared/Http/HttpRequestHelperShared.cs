namespace SunamoShared.Http;


/// <summary>
/// Can be only in shared coz is not available in standard
/// </summary>
public static partial class HttpRequestHelper
{

    /// <summary>
    /// In earlier time return ext
    /// Now return whether was downloaded
    /// </summary>
    /// <param name="path"></param>
    /// <param name="uri"></param>
    /// <returns></returns>
    public static
#if ASYNC
    async Task<string>
#else
    string
#endif
 DownloadOrRead(string path, string uri, DownloadOrReadArgs a = null)
    {
        if (a == null)
        {
            a = new DownloadOrReadArgs();
        }

        string html = null;

        if (!FS.ExistsFile(path) || a.forceDownload)
        {
            Download(uri, null, path);
        }

        html =
#if ASYNC
    await
#endif
 TF.ReadAllText(path);

        return html;
    }

    /*
     * Měl jsem tu i metodu jež vracela fn
     *
     */
    //public static string DownloadOrRead(string uri)
    //{
    //    string fn = null;
    //    return DownloadOrRead(ref fn, uri);
    //}

    /// <summary>
    /// As folder is use Cache
    /// </summary>
    /// <param name="cache"></param>
    /// <param name="uri"></param>
    public static
#if ASYNC
    async Task<string>
#else
    string
#endif
 DownloadOrRead(/*ref string fn,*/ string uri, DownloadOrReadArgs a = null)
    {
        #region Část kódu kretá se používala když jsem vracel fn
        //var v = UH.GetFileNameWithoutExtension(uri);
        //var qs = UH.GetQueryAsHttpRequest(new Uri( uri));
        //fn = FS.ReplaceInvalidFileNameChars(v + qs);
        #endregion

        var uriShort = ShortPathFromUri(uri);

        var fn = Path.Combine(AppData.ci.GetFolder(AppFolders.Cache), SH.AppendIfDontEndingWith(uriShort, AllExtensions.html));
        return
#if ASYNC
    await
#endif
 DownloadOrRead(fn, uri, a);
    }

    public static bool ExistsPage(string url)
    {
        try
        {
            //Creating the HttpWebRequest
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //Setting the Request method HEAD, you can also use GET too.
            request.Method = "HEAD";
            //Getting the Web Response.
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //Returns TRUE if the Status code == 200
            response.Close();
            return (response.StatusCode == HttpStatusCode.OK);
        }
        catch
        {
            //Any exception will returns false.
            return false;
        }
    }

    /// <summary>
    /// Is not async coz t.Result
    /// </summary>
    /// <param name="address"></param>
    public static
#if ASYNC
        async Task<string>
#else
        string
#endif
        GetResponseText(string address)
    {
        var request = (HttpWebRequest)WebRequest.CreateHttp(address);
        request.Timeout = int.MaxValue;
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.64 Safari/537.11";
        var t =

            request.GetResponseAsync();
        //HttpWebResponse response = null;
        // var response = (HttpWebResponse)t.Result;
        WebResponse result2 =
#if ASYNC
            await t;
#else
            AsyncHelper.ci.GetResult<WebResponse>(t);
#endif


        if (false)
        {
            //Encoding encoding = null;

            //if (response.CharacterSet == "")
            //{
            //    //encoding = Encoding.UTF8;
            //}
            //else
            //{
            //    encoding = Encoding.GetEncoding(response.CharacterSet);
            //}

            //using (var responseStream = response.GetResponseStream())
            //{
            //    StreamReader reader = null;
            //    if (encoding == null)
            //    {
            //        reader = new StreamReader(responseStream, true);
            //    }
            //    else
            //    {
            //        reader = new StreamReader(responseStream, encoding);
            //    }
            //    string vr = reader.ReadToEnd();

            //    //response.Dispose();
            //    result2.Dispose();

            //    return vr;
            //}
        }

        var ts = result2.ToString();
        return ts;

    }

    /// <summary>
    /// Same url:
    /// HttpClientHelper.GetResponseText - Exception: The remote server returned an error: (400) Bad Request., response is null
    /// HttpClientHelper.GetResponseText - really xml, exists response
    /// Pros: Better is HttpClientHelper because I can parse error
    /// Cons: HttpClientHelper.GetResponseText not return HttpWebResponse object, only HttpResponseMessage

    /// </summary>
    /// <param name="address"></param>
    /// <param name="method"></param>
    /// <param name="hrd"></param>
    public static string GetResponseText(string address, HttpMethod method, HttpRequestData hrd = null)
    {
        HttpWebResponse response;
        return GetResponseText(address, method, hrd, out response);
    }



    /// <param name = "address"></param>
    public static Stream GetResponseStream(string address, HttpMethod method)
    {
        var request = (HttpWebRequest)WebRequest.Create(address);
        request.Method = method.Method;
        HttpWebResponse response = null;
        try
        {
            response = (HttpWebResponse)request.GetResponse();
        }
        catch (System.Exception)
        {
            return null;
        }

        return response.GetResponseStream();
    }

    public static string GetResponseText(string address, HttpMethod method, HttpRequestData hrd, out HttpWebResponse response)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
        return GetResponseText(request, method, hrd, out response);
    }

    /// <summary>
    /// A3 can be null
    /// Dont forger Dispose on A4
    /// </summary>
    /// <param name = "address"></param>
    /// <param name = "method"></param>
    /// <param name = "hrd"></param>
    public static string GetResponseText(HttpWebRequest request, HttpMethod method, HttpRequestData hrd, out HttpWebResponse response)
    {
        NetHelperSunamo.NEVER_EAT_POISON_Disable_CertificateValidation();

        response = null;

        if (hrd == null)
        {
            hrd = new HttpRequestData();
        }

        var address = request.Address.ToString();

        int dex = address.IndexOf(AllChars.q);
        string adressCopy = address;
        if (method.Method.ToUpper() == "POST")
        {
            if (dex != -1)
            {
                address = address.Substring(0, dex);
            }
        }

        // Cant create new instance, in A1 can be setted up property which is not allowed in Headers
        //request.Address = address;

        string result = null;

        request.Method = method.Method;

        if (method == HttpMethod.Post)
        {
            string query = adressCopy.Substring(dex + 1);
            Encoding encoder = null;
            if (hrd.encodingPostData == null)
            {
                encoder = new ASCIIEncoding();
            }
            else
            {
                encoder = hrd.encodingPostData;
            }

            byte[] data = encoder.GetBytes(query);
            request.ContentType = "application/x-www-urlencoded";
            request.ContentLength = data.Length;
            request.GetRequestStream().Write(data, 0, data.Length);
        }

        //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.64 Safari/537.11";
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Safari/537.36";
        if (hrd.contentType != null)
        {
            request.ContentType = hrd.contentType;
        }

        if (hrd.accept != null)
        {
            request.Accept = hrd.accept;
        }

        if (hrd != null)
        {
            foreach (var item in hrd.headers)
            {
                request.Headers.Add(item.Key, item.Value);
            }
        }

        WebResponse wr = null;

        try
        {
            wr = request.GetResponse();
            response = (HttpWebResponse)wr;

            Encoding encoding = null;
            if (response.CharacterSet == "")
            {
                //encoding = Encoding.UTF8;
            }
            else
            {
                encoding = Encoding.GetEncoding(response.CharacterSet);
            }

            using (var responseStream = response.GetResponseStream())
            {
                StreamReader reader = null;
                if (hrd.forceEndoding.HasValue)
                {
                    if (hrd.forceEndoding.GetValueOrDefault())
                    {
                        reader = new StreamReader(responseStream, hrd.forcedEncoding);
                    }
                    else
                    {
                        if (encoding == null)
                        {
                            reader = new StreamReader(responseStream, true);
                        }
                        else
                        {
                            reader = new StreamReader(responseStream, encoding);
                        }
                    }
                }
                else
                {
                    reader = new StreamReader(responseStream, true);
                }

                result = reader.ReadToEnd();
            }

        }
        catch (System.Exception ex)
        {
            if (hrd.throwEx)
            {
                result = Exceptions.TextOfExceptions(ex) + AllStrings.space + request.RequestUri.ToString();
            }
        }

        return result;
    }

    /// <summary>
    /// If return empty array, SharedAlgorithms.lastError contains HttpError
    /// </summary>
    /// <param name = "address"></param>
    public static byte[] GetResponseBytes(string address, HttpMethod method, int timeoutInMs = 30000)
    {
        var request = (HttpWebRequest)WebRequest.Create(address);
        request.Method = method.Method;
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.64 Safari/537.11";
        WebResponse r = null;

        int times = 5;


        r = SharedAlgorithms.RepeatAfterTimeXTimes<WebResponse>(times, timeoutInMs, new Func<WebResponse>(request.GetResponse));
        if (EqualityComparer<WebResponse>.Default.Equals(r, default(WebResponse)))
        {
            var before = ThrowEx.FullNameOfExecutedCode(type, Exc.CallingMethod());
            ThisApp.Warning( Exceptions.RepeatAfterTimeXTimesFailed(before, times, timeoutInMs, address, SharedAlgorithms.lastError));
            return new byte[0];
        }
        else
        {
            HttpWebResponse response = (HttpWebResponse)r;
            using (response)
            {
                Encoding encoding = null;
                if (response.CharacterSet == "")
                {
                    encoding = Encoding.UTF8;
                }
                else
                {
                    encoding = Encoding.GetEncoding(response.CharacterSet);
                }

                using (var responseStream = response.GetResponseStream())
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        responseStream.CopyTo(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        using (var reader = new StreamReader(ms, encoding))
                        {
                            using (BinaryReader br = new BinaryReader(reader.BaseStream))
                            {
                                return br.ReadBytes((int)ms.Length);
                            }
                        }
                    }
                }
            }
        }
    }



    public static string BeforeTestingIpAddress(string vr)
    {
        if (vr == "::1")
        {
            vr = Consts.sunamoNetIp;
        }

        return vr;
    }


}
