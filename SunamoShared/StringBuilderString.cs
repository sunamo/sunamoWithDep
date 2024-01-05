namespace SunamoShared;
public class StringBuilderString
{
    StringBuilder sb = null;
    string s = null;
    bool isString = false;

    public StringBuilderString(string argValue2)
    {
        s = argValue2;
        isString = true;
    }

    public StringBuilderString(StringBuilder argValue2)
    {
        sb = argValue2;
    }

    public int Length { get; set; }

    public char this[int i]
    {
        get
        {
            if (isString)
            {
                return s[i];
            }
            else
            {
                return sb[i];
            }
        }
        set
        {
            if (isString)
            {
                ThrowEx.NotSupported();
                //s[i] = value;
            }
            else
            {
                sb[i] = value;
            }
        }
    }

    public bool IsNullOrWhiteSpace()
    {
        if (isString)
        {
            return string.IsNullOrWhiteSpace(s);
        }
        return sb != null && sb.ToString().Trim() != string.Empty;
    }
}
