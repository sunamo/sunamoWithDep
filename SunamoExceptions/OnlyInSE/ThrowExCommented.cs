namespace SunamoExceptions.OnlyInSE;

//using System;
//using System.Collections.Generic;
//using System.Text;

//public partial class ThrowEx
//{
//    #region For easy copy from ThrowEx.cs
//    public static Func<char, bool> IsLockedByBitLocker;

//    public static bool LockedByBitLocker(string path)
//    {
//        // pokračovat na tohle
//        if (IsLockedByBitLocker != null)
//        {
//            var p = path[0];

//            if (IsLockedByBitLocker(p))
//            {
//                Custom($"Drive {p}:\\ is locked by BitLocker");
//                return true;
//            }
//        }
//        return false;
//    }
//    #endregion

//    #region For easy copy from SunExc/ThrowEx.cs
//    public static void ExcAsArg(Exception ex, string message = Consts.se)
//        {
//            ThrowEx.ThrowIsNotNull(Exceptions.ExcAsArg, ex, message);
//        }

//    #region DifferentCountInLists
//    public static void FolderCannotBeDeleted( string repairedBlogPostsFolder, Exception ex)
//    {
//        ThrowIsNotNull(Exceptions.FolderCannotBeDeleted(FullNameOfExecutedCode(t.Item1, t.Item2, true), repairedBlogPostsFolder, ex));
//    }
//    #endregion
//    #endregion
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;


//public partial class ThrowEx
//{
//    #region For easy copy from ThrowEx64.cs
//    public static void NotImplementedCase(object niCase)
//    {
//        ThrowIsNotNull(Exceptions.NotImplementedCase, niCase);
//    }

//    public static void Custom(string v)
//    {
//        ThrowIsNotNull(Exceptions.Custom, v);
//    }



//    private static void ThrowIsNotNull(Func<string, string> f)
//    {
//        ThrowEx.ThrowIsNotNull(f);
//    }

//    private static void ThrowIsNotNull(Func<string, object, string> f, object o)
//    {
//        ThrowEx.ThrowIsNotNull(f, o);
//    }

//    private static void ThrowIsNotNull(Func<string, string, string> f, string a1)
//    {
//        ThrowEx.ThrowIsNotNull(f, a1);
//    }

//    /// <summary>
//    /// true if everything is OK
//    /// false if some error occured
//    ///
//    /// </summary>
//    /// <param name="f"></param>
//    /// <param name="a1"></param>
//    /// <param name="a2"></param>
//    /// <returns></returns>
//    private static bool ThrowIsNotNull(Func<string, string, IList, string> f, string a1, IList a2)
//    {
//        return ThrowEx.ThrowIsNotNull(f, a1, a2);
//    }

//    private static void ThrowIsNotNull<T>(Func<string, string, T[], string> f, string a1, params T[] a2)
//    {
//        ThrowEx.ThrowIsNotNull(f, a1, a2);
//    }

//    private static string FullNameOfExecutedCode()
//    {
//        return ThrowEx.FullNameOfExecutedCode(t.Item1, t.Item2, true);
//    }

//    public static void NotImplementedMethod()
//    {
//        ThrowIsNotNull(Exceptions.NotImplementedMethod);
//    }
//    #endregion

//    #region For easy copy from SunExc\ThrowExShared.cs
//    /// <summary>
//    /// A1 have to be Dictionary<T,U>, not IDictionary without generic
//    /// </summary>
//    /// <typeparam name="T"></typeparam>
//    /// <typeparam name="U"></typeparam>
//    /// <param name="type"></param>
//    /// <param name="v"></param>
//    /// <param name="en"></param>
//    /// <param name="dictName"></param>
//    /// <param name="key"></param>
//    public static void KeyNotFound<T, U>(IDictionary<T, U> en, string dictName, T key)
//    {
//        ThrowIsNotNull(Exceptions.KeyNotFound(FullNameOfExecutedCode(t.Item1, t.Item2), en, dictName, key));
//    }

//    public static void NotValidXml( string path, Exception ex)
//    {
//        bool v = ThrowIsNotNull(Exceptions.NotValidXml(FullNameOfExecutedCode(t.Item1, t.Item2), path, ex));
//    }

//    #region For easy copy in SunamoException project
//#pragma warning disable
//    public static void DummyNotThrow(Exception ex)
//    {

//    }
//#pragma warning enable






//    /// <summary>
//    /// Verify whether A3 contains A4
//    /// true if everything is OK
//    /// false if some error occured
//    /// </summary>
//    /// <param name="type"></param>
//    /// <param name="v"></param>
//    /// <param name="p"></param>
//    /// <param name="after"></param>
//    public static bool NotContains(string stacktrace, object type, string v, string p, params string[] after)
//    {
//        return ThrowIsNotNull(Exceptions.NotContains(FullNameOfExecutedCode(type, v, true), p, after));
//    }



//    /// <summary>
//    /// Default use here method with one argument
//    /// Return false in case of exception, otherwise true
//    /// In console app is needed put in into try-catch error due to there is no globally handler of errors
//    /// </summary>
//    /// <param name="type"></param>
//    /// <param name="methodName"></param>
//    /// <param name="exception"></param>
//    //public static bool ThrowIsNotNull( string exception)
//    //{
//    //    if (exception != null)
//    //    {

//    //        ThrowEx.Custom(exception, cm);
//    //        return false;
//    //    }
//    //    return true;
//    //}
//    #endregion
//    #endregion
//}


////using sunamo;
////using System;
////using System.Collections;
////using System.Reflection;

////public partial class ThrowEx
////{
////    public static string lastError;


////    public static void FirstLetterIsNotUpper(string selectedFile)
////    {
////        ThrowIsNotNull(Exceptions.FirstLetterIsNotUpper, selectedFile);
////    }

////    private static void ThrowIsNotNull(Func<string, string, string> firstLetterIsNotUpper, string selectedFile)
////    {
////        throw new NotImplementedException();
////    }

////    /// <summary>
////    /// Je lichý
////    /// </summary>
////    /// <param name="colName"></param>
////    /// <param name="e"></param>
////    /// <returns></returns>
////    public static bool IsOdd(string colName, IList e)
////    {
////        Func<string, string, IList, string> f = Exceptions.IsOdd;
////        return ThrowIsNotNull(f, colName, e);
////    }

////    private static bool ThrowIsNotNull(Func<string, string, IList, string> f, string colName, IList e)
////    {
////        return false;
////    }

////    public static void UncommentNextRows()
////    {
////        ThrowIsNotNull(Exceptions.UncommentNextRows);
////    }

////    private static void ThrowIsNotNull(Func<string, string> uncommentNextRows)
////    {

////    }

////    #region For easy copy from SunExc/ThrowExShared64.cs - all ok 17-10-21


////    public static void DifferentCountInLists(string namefc, int countfc, string namesc, int countsc)
////    {
////        ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(t.Item1, t.Item2, true), namefc, countfc, namesc, countsc));
////    }

////    public static void DifferentCountInLists(string namefc, IList replaceFrom, string namesc, IList replaceTo)
////    {
////        DifferentCountInLists(namefc, replaceFrom.Count(), namesc, replaceTo.Count());
////    }

////    public static void Custom(string message, bool reallyThrow = true)
////    {
////        ThrowIsNotNull(Exceptions.Custom(FullNameOfExecutedCode(t.Item1, t.Item2, true), message), reallyThrow);
////    }

////    public static bool reallyThrow2 = true;

////#if MB
////    static void ShowMb(string s)
////    {

////        TranslateDictionary.ShowMb(s);
////    }
////#endif

////    public static void ThrowIsNotNull(Func<string, Exception, string, string> f, Exception ex, string message)
////    {
////        t = Exc.GetStackTrace2(true);

////        var exc = f(FullNameOfExecutedCode(t.Item1, t.Item2), ex, message);
////        ThrowIsNotNull(exc);
////    }

////    public static void ThrowIsNotNull(Func<string, object, string> f, object o)
////    {
////        t = Exc.GetStackTrace2(true);

////        var exc = f(FullNameOfExecutedCode(t.Item1, t.Item2), o);
////        ThrowIsNotNull(exc);
////    }

////    public static void ThrowIsNotNull(Func<string, string> f)
////    {
////        t = Exc.GetStackTrace2(true);

////        var exc = f(FullNameOfExecutedCode(t.Item1, t.Item2));
////        ThrowIsNotNull(exc);
////    }

////    public static void ThrowIsNotNull(Func<string, string, string> f, string a1)
////    {
////        t = Exc.GetStackTrace2(true);

////        var exc = f(FullNameOfExecutedCode(t.Item1, t.Item2), a1);
////        ThrowIsNotNull(exc);
////    }

////    /// <summary>
////    /// true if everything is OK
////    /// false if some error occured
////    ///
////    /// </summary>
////    /// <param name="f"></param>
////    /// <param name="a1"></param>
////    /// <param name="a2"></param>
////    /// <returns></returns>
////    public static bool ThrowIsNotNull(Func<string, string, IList, string> f, string a1, IList a2)
////    {
////        t = Exc.GetStackTrace2(true);

////        var exc = f(FullNameOfExecutedCode(t.Item1, t.Item2), a1, a2);
////        return ThrowIsNotNull(exc);
////    }

////    public static void ThrowIsNotNull<T>(Func<string, string, T[], string> f, string a1, params T[] a2)
////    {
////        t = Exc.GetStackTrace2(true);

////        var exc = f(FullNameOfExecutedCode(t.Item1, t.Item2), a1, a2);
////        ThrowIsNotNull(exc);
////    }

////    static string lastMethod = null;

////    /// <summary>
////    /// true if everything is OK
////    /// false if some error occured
////    /// In console app is needed put in into try-catch error due to there is no globally handler of errors
////    /// </summary>
////    /// <param name="exception"></param>
////    public static bool ThrowIsNotNull(string exception, bool reallyThrow = true)
////    {
////        // Výjimky se tak často nevyhazují. Tohle je daň za to že jsem tu měl arch
////        // jež nebyla dobře navržená. V ThrowEx se to již podruhé volat nebude.

////        if (exception != null)
////        {
////            t = Exc.GetStackTrace2(true);
////            var cm = t.Item2;
////            if (lastMethod == cm)
////            {
////#if MB
////                ShowMb("lastMethod == cm");
////#endif
////                return false;
////            }
////            else
////            {
////#if MB
////                if (lastMethod == null)
////                {
////                    ShowMb("lastMethod = " + Consts.nulled);
////                }
////                else
////                {
////                    ShowMb("lastMethod = " + lastMethod.ToString());
////                }
////#endif
////                lastMethod = cm;
////            }

////            if (Exc.aspnet)
////            {
////                exception = exception.Replace("Violation of PRIMARY KEY constraint", ShortenedExceptions.ViolationOfPK);

////                // Will be written in globalasax error
////                writeServerError(t.Item3, exception);

////                /*
////reallyThrow - method arg
////reallyThrow2 - is setted in ShowMb and all excs handlers in WpfAppShared.cs
////                 */

////                if (reallyThrow && reallyThrow2)
////                {
////                    throw new Exception(exception);
////                }
////            }
////            else
////            {
////#if MB
////                //ShowMb($"reallyThrow = {reallyThrow} && reallyThrow2 = {reallyThrow2}");
////#endif

////                if (reallyThrow && reallyThrow2)
////                {
////#if MB
////                    ShowMb("Throw exc");
////#endif
////                    if (showExceptionWindow != null)
////                    {
////                        var nl = Environment.NewLine;

////                        showExceptionWindow(t.Item3 + nl + nl + exception);
////                    }
////                    else
////                    {
////                        throw new Exception(exception);
////                    }
////                }
////            }
////        }
////        return true;
////    }

////    /// <summary>
////    /// !FS.IsWindowsPathFormat
////    /// </summary>
////    /// <param name="stacktrace"></param>
////    /// <param name="type"></param>
////    /// <param name="methodName"></param>
////    /// <param name="argName"></param>
////    /// <param name="argValue"></param>
////    public static void IsNotWindowsPathFormat(string argName, string argValue)
////    {
////        t = Exc.GetStackTrace2();
////        ThrowIsNotNull(Exceptions.IsNotWindowsPathFormat(FullNameOfExecutedCode(t.Item1, t.Item2, true), argName, argValue));
////    }

////    public static void StartIsHigherThanEnd(int start, int end)
////    {
////        t = Exc.GetStackTrace2();
////        ThrowIsNotNull(Exceptions.StartIsHigherThanEnd(FullNameOfExecutedCode(t.Item1, t.Item2, true), start, end));
////    }

////    public static void IsNullOrEmpty(string argName, string argValue)
////    {
////        t = Exc.GetStackTrace2();
////        ThrowIsNotNull(Exceptions.IsNullOrEmpty(FullNameOfExecutedCode(t.Item1, t.Item2, true), argName, argValue));
////    }

////    public static void ArgumentOutOfRangeException(string paramName, string message = null)
////    {
////        ThrowIsNotNull(Exceptions.ArgumentOutOfRangeException(FullNameOfExecutedCode(t.Item1, t.Item2, true), paramName, message));
////    }

////    public static void IsNull(string variableName, object variable = null)
////    {
////        ThrowIsNotNull(Exceptions.IsNull(FullNameOfExecutedCode(t.Item1, t.Item2, true), variableName, variable));
////    }

////#pragma warning disable
////    /// <summary>
////    /// CA2211	Non-constant fields should not be visible
////    /// IDE0044	Make field readonly
////    ///
////    /// Must be public due to GlobalAsaxHelper
////    /// </summary>
////    public static Action<string, string> writeServerError;
////    static Action<object> _showExceptionWindow = null;
////    public static Action<object> showExceptionWindow
////    {
////        get
////        {
////            return _showExceptionWindow;
////        }
////        set
////        {
////#if DEBUG
////            _showExceptionWindow = null;
////#else
////            _showExceptionWindow = value;
////#endif
////        }
////    }
////#pragma warning enable

////    /// <summary>
////    /// First can be Method base, then A2 can be anything
////    /// </summary>
////    /// <param name="type"></param>
////    /// <param name="methodName"></param>
////    public static string FullNameOfExecutedCode(object type, string methodName, bool fromThrowEx = false)
////    {
////        if (methodName == null)
////        {
////            int depth = 2;
////            if (fromThrowEx)
////            {
////                depth++;
////            }
////            methodName = Exc.CallingMethod(depth);
////        }
////        string typeFullName = string.Empty;
////        if (type is Type)
////        {
////            var type2 = ((Type)type);
////            typeFullName = type2.FullName;
////        }
////        else if (type is MethodBase)
////        {
////            MethodBase method = (MethodBase)type;
////            typeFullName = method.ReflectedType.FullName;
////            methodName = method.Name;
////        }
////        else if (type is string)
////        {
////            typeFullName = type.ToString();
////        }
////        else
////        {
////            Type t = type.GetType();
////            typeFullName = t.FullName;
////        }
////        return string.Concat(typeFullName, dot, methodName);
////    }


////    #endregion
////}
////}
