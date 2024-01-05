namespace SunamoCompare._SunamoComparer;




public class AllHtmlAttrsValues
{
    static bool initialized = false;
    public static List<string> list = new List<string>();

    public static void Init()
    {
        if (!initialized)
        {
            initialized = true;
            var d = RH.GetConsts(typeof(HtmlAttrValue), null);

            foreach (var item in d)
            {
                list.Add(item.GetValue(null).ToString());
            }

            list.Sort(new SunamoComparerICompare.StringLength.Desc(SunamoComparer.StringLength.Instance));
        }
    }
}
