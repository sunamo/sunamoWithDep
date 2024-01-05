namespace SunamoI18N;


public partial class CzechHelper
{
    const string utf8hex = @"C3 81
C3 84
C4 8C
C4 8E
C3 89
C4 9A
C3 8D
C4 B9
C4 BD
C5 87
C3 93
C3 94
C3 96
C5 94
C5 98
C5 A0
C5 A4
C3 9A
C5 AE
C3 9C
C3 9D
C5 BD
C3 A1
C3 A4
C4 8D
C4 8F
C3 A9
C4 9B
C3 AD
C4 BA
C4 BE
C5 88
C3 B3
C3 B4
C3 B6
C5 95
C5 99
C5 A1
C5 A5
C3 BA
C5 AF
C3 BC
C3 BD
C5 BE";

    const string czechLetters = @"Á
Ä
Č
Ď
É
Ě
Í
Ĺ
Ľ
Ň
Ó
Ô
Ö
Ŕ
Ř
Š
Ť
Ú
Ů
Ü
Ý
Ž
á
ä
č
ď
é
ě
í
ĺ
ľ
ň
ó
ô
ö
ŕ
ř
š
ť
ú
ů
ü
ý
ž";

    static Dictionary<string, string> fromUtf8hex = new Dictionary<string, string>();

    public CzechHelper()
    {

    }

    public static string ReplaceInHtmlFrom_UTF_8_Hex(string input)
    {
        return ReplaceInHtmlFrom(CzechEncodings.UTF_8, true, input);
    }

    public static string ReplaceInHtmlFrom(CzechEncodings s, bool hex, string input)
    {
        if (s == CzechEncodings.UTF_8 && hex)
        {
            if (fromUtf8hex.Count == 0)
            {
                CzechHelper.Init(CzechEncodings.UTF_8, true);
            }

            foreach (var item in fromUtf8hex)
            {
                input = input.Replace(item.Key, item.Value);
            }
        }

        input = SH.KeepAfterFirst(input, "<!DOCTYPE html>", true);
        input = SH.RemoveAfterFirst(input, "</html");

        input = input.Replace("3D\"", "=\"");

        //input = input.Replace("=3D", "=");
        input = input.Replace(Consts.nl, "");
        input = input.Replace("\r", "");
        input = input.Replace("\n", "");
        input = input.Replace("</= ", "</");
        input = input.Replace("</ ", "</");
        input = input.Replace("data=-", "data=");
        input = input.Replace(":=", ":");
        input = input.Replace("==", "=");

        // tohle můžu až na konci
        input = input.Replace("=", ";3D");
        input = input.Replace("=", "");
        input = input.Replace(";3D", "=");

        input = SHReplace.ReplaceAllDnArgs(input, "=\"", ";\"");
        input = SHReplace.ReplaceAllDnArgs(input, "=", "");
        // zde je chyba. nahrazuje to správně ale =\" se mi vloží i na konce hodnoty atributů.
        input = SHReplace.ReplaceAllDnArgs(input, ";\"", "=\"");

        return input;
    }


    public static void Init(CzechEncodings s, bool hex)
    {
        if (s == CzechEncodings.UTF_8 && hex)
        {
            var utf8hexL = SHGetLines.GetLines(utf8hex);
            var czechLettersL = SHGetLines.GetLines(czechLetters);

            ThrowEx.DifferentCountInLists<string>("utf8hexL", utf8hexL, "czechLettersL", czechLettersL);

            CA.Prepend(" ", utf8hexL);

            CA.Replace(utf8hexL, " ", "=");

            for (int i = 0; i < czechLettersL.Count; i++)
            {
                fromUtf8hex.Add(utf8hexL[i], czechLettersL[i]);
            }
        }
    }
}
