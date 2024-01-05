using SunamoLang;
using SunamoTypeOfMessage;

namespace SunamoThisApp;



public partial class ThisApp : ThisAppSE
{
    public static Langs l = Langs.en;
    public static bool useShortAsDt = true;
    public static bool runInDebug = true;
    /// <summary>
    /// sess.i18n
    /// </summary>
    public static Func<string, string> i18n;

    // Everywhere is used just ThisApp.cd. 
    //public static Dispatcher cd = null;
    //public static DispatcherPriority cdp = DispatcherPriority.Normal;
    /*
     * Nemůže tu být 
     * Pokud si chci vybrat zda má SunamoLogger dědit od SunamoThisApp nebo naopak
     * tak je logičtější první možnost
     * 
     * dočasně to musím zakomentovat než vyřeším zbytek možností
     */
    //        public static TypedLoggerBase NopeOrDebugTyped()
    //        {
    //#if DEBUG2
    //                    return TypedDebugLogger.Instance;
    //#elif !DEBUG2
    //            // Is possible also use CmdApp.ConsoleOrDebugTyped
    //            return TypedDummyLogger.Instance;
    //            //return TypedConsoleLogger.Instance;
    //#endif
    //        }

    public static bool check = false;


    static string project = null;
    /// <summary>
    /// Name = Solution
    /// Project = Project
    /// </summary>
    public static string Project
    {
        get
        {
            if (project == null)
            {
                return Name;
            }
            return project;
        }
        set
        {
            project = value;
        }
    }
    public static string _Name
    {
        get
        {
            return AllStrings.lowbar + Name;
        }
    }



    public static readonly bool initialized = false;
    public static string Namespace = "";

    static string eventLogName = null;

    /// <summary>
    /// může být null, pak se EL nebude využívat
    /// </summary>
    public static string EventLogName
    {
        get => eventLogName;
        set
        {
            eventLogName = string.IsNullOrEmpty(value) ? null : SH.SubstringIfAvailable(value, 8);
        }
    }

    public static event SetStatusDelegate StatusSetted;

    public static void SetStatusXlf(TypeOfMessage st, string key)
    {
        SetStatus(st, i18n(key));
    }

    public static void SetStatus(TypeOfMessage st, string status, params string[] args)
    {
        var format = /*SH.Format2*/ string.Format(status, args);
        if (format.Trim() != string.Empty)
        {
            if (StatusSetted == null)
            {
                // For unit tests
                //////////DebugLogger.Instance.WriteLine(st + ": " + format);
            }
            else
            {
                StatusSetted(st, format);
            }
        }
    }

    public static void StatusFromText(string v)
    {
        if (!string.IsNullOrEmpty(v))
        {
            var tom = StatusHelperSunamo.IsStatusMessage(ref v);
            SetStatus(tom, v);
        }
    }

    /// <summary>
    /// Strings which is on lines calling this method is not translate
    /// Debug method when I running app on release and app is behave extraordinary
    /// </summary>
    /// <param name="v"></param>
    /// <param name="o"></param>
    public static void a(string v, params string[] o)
    {

        ThisApp.Appeal(v, o);
    }

    public static void Success(string v, params string[] o)
    {
        SetStatus(TypeOfMessage.Success, v, o);
    }

    public static void Info(string v, params string[] o)
    {
        SetStatus(TypeOfMessage.Information, v, o);
    }

    public static void Error(string v, params string[] o)
    {
        SetStatus(TypeOfMessage.Error, v, o);
    }

    public static void Warning(string v, params string[] o)
    {
        SetStatus(TypeOfMessage.Warning, v, o);
    }

    public static void Ordinal(string v, params string[] o)
    {
        SetStatus(TypeOfMessage.Ordinal, v, o);
    }

    public static void Appeal(string v, params string[] o)
    {
        SetStatus(TypeOfMessage.Appeal, v, o);
    }

    public static void ResultWithException<T>(ResultWithException<T> result, string replacementWhenSuccess = null, bool showToStringWhenSuccess = false)
    {
        if (!EqualityComparer<T>.Default.Equals(result.Data, default(T)))
        {
            if (showToStringWhenSuccess)
            {
                Info(result.Data.ToString());
            }
            else if (replacementWhenSuccess != null)
            {
                Info(replacementWhenSuccess);
            }
        }
        else
        {
            Error(result.exc);
        }
    }
}
