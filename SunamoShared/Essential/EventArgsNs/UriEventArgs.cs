namespace SunamoShared.Essential.EventArgsNs;

public delegate void UriEventHandler(object sender, UriEventArgs e);

public class UriEventArgs : EventArgs
{
    private Uri _uri = null;

    public UriEventArgs(Uri uri)
    {
        _uri = uri;
    }

    public Uri Uri { get { return _uri; } }
}
