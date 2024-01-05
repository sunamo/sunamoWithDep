namespace SunamoConverters.Converts;

public class ConvertEveryWordLargeCharConvention //: IConvertConvention
{
    static Type type = typeof(ConvertEveryWordLargeCharConvention);

    /// <summary>
    /// NI
    /// </summary>
    /// <param name="p"></param>
    public static string FromConvention(string p)
    {
        ThrowEx.NotImplementedMethod();
        return null;
    }

    /// <summary>
    /// hello world => Hello World
    /// Hello world => Hello World
    /// helloWorld => Hello World
    /// hello+world => Hello World
    /// hello+World => Hello World
    /// hello 12 world => Hello 12 World
    /// hello 21world => Hello 21 World
    /// Hello21world => Hello21 World
    /// </summary>
    /// <param name="p"></param>
    public static string ToConvention(string p)
    {
        p = p.ToLower();
        StringBuilder sb = new StringBuilder();
        bool dalsiVelke = true;
        foreach (char item in p)
        {
            if (dalsiVelke)
            {
                if (char.IsUpper(item))
                {
                    dalsiVelke = false;
                    sb.Append(AllCharsSE.space);
                    sb.Append(item);
                    continue;
                }
                else if (char.IsLower(item))
                {
                    dalsiVelke = false;
                    if (sb.Length != 0)
                    {
                        if (!IsSpecialChar(sb[sb.Length - 1]))
                        {
                            sb.Append(AllCharsSE.space);
                        }
                    }
                    sb.Append(char.ToUpper(item));
                    continue;
                }
                else if (IsSpecialChar(item))
                {
                    sb.Append(item);
                    continue;
                }
                else if (char.IsDigit(item))
                {
                    sb.Append(item);
                    continue;
                }
                else
                {
                    sb.Append(AllCharsSE.space);
                    continue;
                }
            }
            if (char.IsUpper(item))
            {
                if (!char.IsUpper(sb[sb.Length - 1]))
                {
                    sb.Append(AllCharsSE.space);
                }
                sb.Append(item);
            }
            else if (char.IsLower(item))
            {
                sb.Append(item);
            }
            else if (char.IsDigit(item))
            {
                dalsiVelke = true;
                sb.Append(item);
                continue;
            }
            else if (IsSpecialChar(item))
            {
                sb.Append(item);
                continue;
            }
            else
            {
                sb.Append(AllCharsSE.space);
                dalsiVelke = true;
            }
        }
        string vr = sb.ToString().Trim();

        vr = SHReplace.ReplaceAll(vr, AllStringsSE.space, AllStringsSE.doubleSpace);
        return vr;
    }

    private static bool IsSpecialChar(char item)
    {
        return CA.IsEqualToAnyElement<char>(item, AllCharsSE.bs, AllCharsSE.lb, AllCharsSE.rb, AllCharsSE.rsqb, AllCharsSE.lsqb, AllCharsSE.dot, AllCharsSE.apostrophe);
    }
}
