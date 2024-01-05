namespace SunamoConverters.ConvertersSimple;


public class BlobConverter : ISimpleConverter<string, byte[]>
{
    public string ConvertTo(byte[] ba)
    {
        if (ba == null || ba.Length == 0)
        {
            return "";
        }
        const string HexFormat = "{0:X2}";
        StringBuilder sb = new StringBuilder();
        foreach (byte b in ba)
        {
            sb.Append(SH.Format2(HexFormat, b.ToString()));
        }
        return "X'" + sb.ToString() + "'";
    }

    static Type type = typeof(BlobConverter);
    public byte[] ConvertFrom(string hexEncoded)
    {
        if (hexEncoded == null || hexEncoded.Length == 0)
        {
            return null;
        }
        try
        {
            hexEncoded = hexEncoded.Replace("X'", "").TrimEnd(AllCharsSE.bs); ;

            int l = Convert.ToInt32(hexEncoded.Length / 2);
            byte[] b = new byte[l];
            for (int i = 0; i <= l - 1; i++)
            {
                b[i] = Convert.ToByte(hexEncoded.Substring(i * 2, 2), 16);
            }
            return b;
        }
        catch (Exception ex)
        {
            ThrowEx.DummyNotThrow(ex);
            if (AppLangHelper.currentUICulture.TwoLetterISOLanguageName == "cs")
            {
                ThrowEx.Custom("Zadan\u00FD \u0159et\u011Bzec se nezd\u00E1 b\u00FDt \u0161estn\u00E1ctkov\u011B k\u00F3dov\u00E1n\u00FD:");
                return null;
            }
            else
            {
                ThrowEx.Custom(sess.i18n(XlfKeys.TheProvidedStringDoesNotAppearToBeHexEncoded) + ":" + hexEncoded);
                return null;
            }
        }
    }
}
