namespace SunamoShared;


/// <summary>
///     Není ve sunamo, tím pádem nebudu dávat do NS
///     Třída byla vytvořena abych nemusel importovat System.Web pro metody jež nejsou v WebUtility
/// </summary>
public class HttpUtility : HttpUtilitySE
{
    public static NameValueCollection ParseQueryString(string responseContent)
    {
        return HttpUtilitySE.ParseQueryString(responseContent);

    }


    public static string HtmlDecode(string v)
    {
        return WebUtility.HtmlDecode(v);
    }

    public static string HtmlEncode(string html)
    {
        return HtmlEncodeWithCompatibility(html);
    }

    public static string HtmlEncodeWithCompatibility(string html, bool backwardCompatibility = true)
    {
        if (html == null)
        {
            ThrowEx.Custom("html");
        }
        // replace & by &amp; but only once!
        Regex rx = backwardCompatibility
            ? new Regex("&(?!(amp;)|(lt;)|(gt;)|(quot;))", RegexOptions.IgnoreCase)
            : new Regex("&(?!(amp;)|(lt;)|(gt;)|(quot;)|(nbsp;)|(reg;))", RegexOptions.IgnoreCase);
        return rx.Replace(html, "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");
    }

    public static string UrlEncode(string slnName)
    {
        return WebUtility.UrlEncode(slnName);
    }

    public static string UrlDecode(string v)
    {
        return WebUtility.UrlDecode(v);
    }
}
