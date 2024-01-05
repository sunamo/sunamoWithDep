namespace SunamoInterfaces.Interfaces;

public interface IClipboardMonitor
{
    // need to create static
    //IClipboardMonitor Instance { get; }
    //bool? monitor { get; set; }
    /// <summary>
    ///     Whether after copy to clipboard from any source allow monitoring
    /// </summary>
    bool? afterSet { get; set; }

    bool pernamentlyBlock { get; set; }
}
