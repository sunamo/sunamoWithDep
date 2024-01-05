namespace SunamoExceptions.OnlyInSE;



//namespace SunamoExceptions
//{


/// <summary>
///     Exc není ve sunamo, proto jsem smazal NS
/// </summary>
public class Exc
{
    /// <summary>
    ///     Is setting in SpecialFoldersHelper.aspnet
    ///     value holder for all aspnet projects
    ///     tuhle proměnnou odstranit, je tu jen
    /// </summary>
    public static bool aspnet = false;

    #region For easy copy in SunamoException project

    private static bool first = true;
    private static readonly StringBuilder sb = new();

    /// <param name="stopAtFirstSystem"></param>
    /// <returns></returns>
    public static string GetStackTrace(bool stopAtFirstSystem = false)
    {
        var r = GetStackTrace2(false, stopAtFirstSystem);
        return r.Item3;
    }

    /// <summary>
    ///     type, methodName, stacktrace
    ///     Remove GetStackTrace (first line
    /// </summary>
    /// <returns></returns>
    public static Tuple<string, string, string> /*(string, string, string)*/ GetStackTrace2(
    bool fillAlsoFirstTwo = true,
    bool stopAtFirstSystem = false)
    {
        if (stopAtFirstSystem)
            if (first)
                first = false;

        StackTrace st = new();

        var v = st.ToString();
        var l = SHSE.Split(v, Environment.NewLine);
        //Trim(l);
        l.RemoveAt(0);

        var i = 0;

        string type = null;
        string methodName = null;

        for (; i < l.Count; i++)
        {
            var item = l[i];

            if (fillAlsoFirstTwo)
                if (!item.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(item, out type, out methodName);
                    fillAlsoFirstTwo = false;
                }

            if (item.StartsWith(CsConsts.atSystemDot))
            {
                //Tohle nevím k čemu to je, vypadá to jako kdyby mě to dělalo duplikát již existujícího
                //l = l.Take(i).ToList();
                l.Add(string.Empty);
                l.Add(string.Empty);

                break;
            }
        }

        return new Tuple<string, string, string>(type, methodName, string.Join(Environment.NewLine, l));
    }

    /// <summary>
    ///     na vstupu musí např. dostat    at EveryLine.SearchCodeElementsUC.SearchCodeElementsUC_Loaded(Object sender,
    ///     RoutedEventArgs e) in E:\vs\Projects\_Selling\EveryLine\EveryLine\UC\EveryLineUC.xaml.cs:line 362
    /// </summary>
    /// <param name="l"></param>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    public static void TypeAndMethodName(string l, out string type, out string methodName)
    {
        var s2 = l.Split("at ")[1].Trim();
        var s = s2.Split("(")[0];
        // zakomentováno, v SE nechci mít žádné duplicitní metody
        //s = SHSE.RemoveAfterFirst(s, AllCharsSE.lb);
        var p = SHSE.SplitChar(s, AllCharsSE.dot);

        methodName = p[p.Count - 1];
        p.RemoveAt(p.Count - 1);
        type = string.Join(AllStringsSE.dot, p);
    }

    public static bool _trimTestOnEnd = true;

    /// <summary>
    ///     Print name of calling method, not GetCurrentMethod
    ///     If is on end Test, will trim
    /// </summary>
    public static string CallingMethod(int v = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(v).GetMethod();
        var methodName = methodBase.Name;
        if (_trimTestOnEnd) methodName = SHSE.TrimEnd(methodName, XlfKeys.Test);

        return methodName;
    }

    #region MyRegion

    public static object lockObject = new();

    public static string MethodOfOccuredFromStackTrace(string exc)
    {
        var st = exc.Split(Environment.NewLine)[0];
        var dx = st.IndexOf(" in ");
        if (dx != -1) st = st.Substring(dx);

        return st;
    }

    /// <summary>
    ///     Usage: GetStackTrace2
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    private static List<string> GetLines(string v)
    {
        var l = v.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        return l;
    }

    #endregion

    #endregion
}
//}
