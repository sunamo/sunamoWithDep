namespace SunamoExceptions.InSunamoIsDerivedFrom;

public class HttpUtilitySE
{
    /// <summary>
    ///     Jsou tu 2 možnosti:
    ///     1) tato metoda
    ///     2) Microsoft.AspNet.WebApi.Client - https://stackoverflow.com/a/22167748
    ///     Protože import balíčků, zvláště těch které s projektem vůbec nesouvisí může způsobit problémy, proto je ve SE
    /// </summary>
    /// <param name="queryString"></param>
    /// <returns></returns>
    public static NameValueCollection ParseQueryString(string queryString)
    {
        NameValueCollection queryParameters = new();
        var querySegments = queryString.Split('&');
        foreach (var segment in querySegments)
        {
            var parts = segment.Split('=');
            if (parts.Length > 0)
            {
                var key = parts[0].Trim('?', ' ');
                var val = parts[1].Trim();

                queryParameters.Add(key, val);
            }
        }

        return queryParameters;
    }
}
