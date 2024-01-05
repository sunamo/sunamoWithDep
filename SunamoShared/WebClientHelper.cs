namespace SunamoShared;

public partial class WebClientHelper
{
    static WebClient wc = new WebClient();

    public static Stream GetResponseStream(string address, HttpMethod method)
    {
        return wc.OpenRead(address);
    }
}
