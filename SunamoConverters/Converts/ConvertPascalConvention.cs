namespace SunamoConverters.Converts;

// Vůbec nechápu k čemu jsem tuto třídu programoval, je to duplicitní kód
// Pokud nepotřebuji čísla, na jejich nahrazení zde jsou jiné metody

//public class ConvertPascalConvention //: IConvertConvention
//{
//    /// <summary>
//    /// A2 IUN
//    /// </summary>
//    /// <param name="p"></param>
//    public static string FromConvention(string p, bool allLettersExceptFirstLower = true)
//    {
//        var r = Regex.Replace(p, "[a-z][A-Z]", m => $"{m.Value[0]} {char.ToLower(m.Value[1])}").ToLower();
//        if (char.IsLower( p[0]))
//        {
//            return SH.FirstCharLower(r);
//        }
//        return SH.FirstCharUpper(r);
//    }

//    /// <summary>
//    /// Wont include numbers
//    /// hello world = helloWorld
//    /// Hello world = HelloWorld
//    /// helloWorld = helloWorld
//    /// </summary>
//    /// <param name="p"></param>
//    public static string ToConvention(string p)
//    {
//        StringBuilder sb = new StringBuilder();
//        bool dalsiVelke = false;
//        foreach (char item in p)
//        {
//            if (dalsiVelke)
//            {
//                if (char.IsUpper(item))
//                {
//                    dalsiVelke = false;
//                    sb.Append(item);
//                    continue;
//                }
//                else if (char.IsLower(item))
//                {
//                    dalsiVelke = false;
//                    sb.Append(char.ToUpper(item));
//                    continue;
//                }
//                else
//                {
//                    continue;
//                }
//            }
//            if (char.IsUpper(item))
//            {
//                sb.Append(item);
//            }
//            else if (char.IsLower(item))
//            {
//                sb.Append(item);
//            }
//            else
//            {
//                dalsiVelke = true;
//            }
//        }
//        return SH.FirstCharUpper( sb.ToString());
//    }

//    public static List<string> FromConvention(List<string> list, bool allLettersExceptFirstLower)
//    {
//        CA.Trim(list);
//        for (int i = 0; i < list.Count; i++)
//        {
//            list[i] = FromConvention(list[i], allLettersExceptFirstLower);
//        }
//        return list;
//    }

//    public static bool IsPascal(string r)
//    {
//        var s = ToConvention(r);
//        return r == s;
//    }
//}
