namespace SunamoShared.Helpers;
//using sunamo.Enums;
//using SunamoExceptions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

///// < summary >
///// nakonec zkontrolovat výskyty a odstranit všechny vs\
///// </summary>
//public class BasePathsHelper
//{
//    static Dictionary<string, bool> exists = new Dictionary<string, bool>();
//    public static string actualPlatform = null;
//    public static Platforms platform = Platforms.Mb;
//    /// <summary>
//    /// e:\vs\Projects\
//    /// </summary>
//    public static string vs = null;

//    static string bpMb => DefaultPaths.bpMb;
//    static string bpQ => DefaultPaths.bpQ;
//    static string bpVps => DefaultPaths.bpVps;

//    static string bpBb => DefaultPaths.bpBb;

//    static BasePathsHelper()
//    {
//        Init();
//    }

//    public static Func<string, bool> IsJunctionPoint = null;

//    public static void Init()
//    {
//        if (vs == null)
//        {
//            Add(bpMb);
//            Add(bpQ);
//            Add(bpVps);

//            /*
//zde jsem měl nějkaou strašně divnou chybu .NETu
//            musel jsem dát breakpoint až do static BasePathsHelper(), kdybych ho dal jen to této metody tam se mi to tu nezastaví i když to tu prochází
//            přes F10,11 jsem došel až na řádek ThrowEx.Custom
//            do ní už mě F11 nepustilo, místo toho mi debugger zase skočil o řádek výše na Where(d => d.Value)
//            a pak už jen StackOverflowException

//            naštěstí zde je oprava snadná, stačí smazat složku e:\vs\ jež je pouze link
//            */
//            var where = exists.Where(d => d.Value).Select(d => d.Key);

//            var exQ = exists[bpQ];
//            var exMb = exists[bpMb];

//            if (exQ && exMb)
//            {
//                var cf = !FS.IsCountOfFilesMoreThan(bpMb, "*", 200);
//                //var np = FS.CreateDirectory(bpMb, DirectoryCreateCollisionOption.AddSerie, SerieStyle.Underscore, false);
//                exists[bpMb] = false;
//                where = exists.Where(d => d.Value).Select(d => d.Key);
//            }

//            if (where.Count() > 1)
//            {
//                // TODO: Udělat tu aby se mi při mb a q a v E:\ to byl jen junction nebo neúplná složka to smazalo/přejmenovalo
//                //if(FS.ExistsDirectory(bpMb) && FS.ExistsDirectory(bpQ))
//                //{
//                //    if (JunctionPoint.)
//                //    {

//                //    }
//                //})));
//                //}

//                ThrowEx.Custom("Can't identify platform on which app run, more folders found: " + string.Join(Comma(where.ToArray()));
//            }
//            else
//            {
//                actualPlatform = where.First();
//                if (actualPlatform != bpMb && actualPlatform != bpQ)
//                {
//                    if (actualPlatform == bpVps)
//                    {
//                        platform = Platforms.Vps;
//                    }
//                    else
//                    {
//                        ThrowEx.NotImplementedCase(platform);
//                    }
//                    vs = actualPlatform;
//                }
//                else
//                {
//                    if (actualPlatform == bpQ)
//                    {
//                        platform = Platforms.Q;
//                    }
//                    vs = actualPlatform + "Projects\\";
//                }
//            }
//        }
//    }

//    public static bool IsIgnored(string p)
//    {
//        if (p.StartsWith(bpBb))
//        {
//            return true;
//        }
//        return false;
//    }

//    public static string ConvertToActualPlatform(string s)
//    {
//        if (s.StartsWith(actualPlatform))
//        {
//            return s;
//        }

//        if (s.StartsWith(bpMb))
//        {
//            return s.Replace(bpMb, actualPlatform);
//        }
//        else if (s.StartsWith(bpQ))
//        {
//            return s.Replace(bpMb, actualPlatform);
//        }
//        else if (s.StartsWith(bpVps))
//        {
//            return s.Replace(bpVps, actualPlatform);
//        }
//        else
//        {
//            ThrowEx.NotImplementedCase(s);
//        }
//        return null;
//    }

//    private static void Add(string bpMb)
//    {
//        exists.Add(bpMb, FS.ExistsDirectoryWorker(bpMb));
//    }
//}
