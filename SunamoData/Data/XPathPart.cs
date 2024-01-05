namespace SunamoData.Data;

public class XPathPart
{
    public string tag = null;
    public string attName = null;
    public string attValue = "";


    public XPathPart(string part)
    {
        int dexStartSquareBracket = part.IndexOf(AllCharsSE.rsqb);
        int dexEndSquareBracket = part.IndexOf(AllCharsSE.lsqb);
        if (dexStartSquareBracket != -1 && dexEndSquareBracket != -1)
        {
            tag = part.Substring(0, dexStartSquareBracket);
            string attr = SH.Substring(part, dexStartSquareBracket + 1, dexEndSquareBracket - 1, null);
            if (attr != "")
            {
                if (attr[0] == '@')
                {
                    var nameValue = SHSE.SplitChar(attr.Substring(1), new char[] { AllCharsSE.qm, AllCharsSE.bs, '=' });
                    if (nameValue.Count == 2)
                    {
                        if (nameValue[0] != "")
                        {
                            attName = nameValue[0];
                            attValue = nameValue[1];
                        }
                    }
                }
            }
        }
        else if (dexStartSquareBracket == -1 && dexEndSquareBracket == -1)
        {
            tag = part;
        }
        else if (dexStartSquareBracket == -1 || dexEndSquareBracket == -1)
        {
            ThrowEx.Custom("Neukon\u010Den\u00E1 z\u00E1vorka v metod\u011B XPathPart.ctor");
        }
    }

    static Type type = typeof(XPathPart);
}
