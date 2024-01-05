namespace SunamoConverters.Converts;



public class ConvertSnakeConvention
{
    static string Sanitize(string t)
    {
        var s = new StringBuilder(t.Replace(AllStringsSE.space, AllStringsSE.lowbar).Replace("__", AllStringsSE.lowbar));
        for (int i = s.Length - 1; i >= 0; i--)
        {
            var ch = s[i];
            if (!char.IsLetter(ch) && !char.IsDigit(ch) && ch != '_')
            {
                s = s.Remove(i, 1);
            }
        }
        return s.ToString();
    }

    public static string ToConvention(string text)
    {
        var rz = string.Concat(text.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        return Sanitize(rz);
        if (text == null)
        {
            throw new ArgumentNullException(nameof(text));
        }
        if (text.Length < 2)
        {
            return text;
        }
        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(text[0]));
        for (int i = 1; i < text.Length; ++i)
        {
            char c = text[i];
            if (char.IsUpper(c))
            {
                sb.Append('_');
                sb.Append(char.ToLowerInvariant(c));
            }
            else
            {
                sb.Append(c);
            }
        }
        var r = sb.ToString().Replace(AllStringsSE.space, AllStringsSE.lowbar);
        return r;
    }

    public static string FromConvention(string p)
    {
        var pa = SHSplit.SplitChar(p, new Char[] { AllCharsSE.lowbar });
        CA.ToLower(pa);
        CA.FirstCharUpper(pa);
        return string.Join(AllStringsSE.space, pa);
    }
}
