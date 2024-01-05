namespace SunamoShared.TemplatesNotCompiled;

public class MainWindowSunamo_Ctor
{
    public static void FirstSection<Dispatcher>(string appName, Action<Dispatcher> WpfAppInit, Func<IClipboardHelper> ClipboardHelperWinStdInstance, Action checkForAlreadyRunning, Action applyCryptData, Dispatcher d)
    {
        ThisAppSE.Name = appName;
        ThisApp.EventLogName = appName;

        WpfAppInit(d);
        if (checkForAlreadyRunning != null)
        {
            checkForAlreadyRunning();
        }

        ClipboardHelper.Instance = ClipboardHelperWinStdInstance();
        AppData.ci.CreateAppFoldersIfDontExists(new CreateAppFoldersIfDontExistsArgs());
        applyCryptData();

        XlfResourcesHSunamo.SaveResouresToRLSunamo(LocalizationLanguagesLoader.Load());
    }
}
