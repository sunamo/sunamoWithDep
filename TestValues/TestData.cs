public class TestData
{
    public static readonly List<int> _123 = new List<int>(new int[] { 1, 2, 3 });
    public static readonly List<int> _321 = new List<int>(new int[] { 3, 2, 1 });

    public const string a = "a";
    public const string ab = "ab";
    public const string abc = "abc";
    public const string b = "b";
    public const string c = "c";
    public const string d = "d";
    public const string a2 = "a2";
    public const string wildcard = "*.cs";

    public static readonly List<string> notSortedBySize = CA.ToList<string>(ab, abc, a);

    /// <summary>
    /// a,b
    /// </summary>
    public static readonly List<string> listAB1;
    public static readonly List<string> listAB2;
    public static readonly List<string> listABC;
    public static readonly List<string> listABCD;
    public static readonly List<string> listABCCC;
    public static readonly List<string> listAC;
    public static readonly List<string> listA;
    public static readonly List<string> listB;
    public static readonly List<string> listC;
    public static readonly List<int> list04;
    public static readonly List<int> list59;
    public static readonly string flatJson = "{\"IdUser\":1,\"Sc\":\"au1skm2qhjbwhmu4z0qwcpiv\"}";
    public static readonly string flatJsonSc = "au1skm2qhjbwhmu4z0qwcpiv";

    static TestData()
    {
        listAB1 = new List<string>(CA.ToListString2(a, b));
        listAB2 = new List<string>(CA.ToListString2(a, b));
        listABC = new List<string>(CA.ToListString2(a, b, c));
        listABCD = new List<string>(CA.ToListString2(a, b, c, d));
        listABCCC = new List<string>(CA.ToListString2(a, b, c, c, c));
        listAC = new List<string>(CA.ToListString2(a, c));
        listA = new List<string>(CA.ToListString2(a));
        listB = new List<string>(CA.ToListString2(b));
        listC = new List<string>(CA.ToListString2(c));

        list04 = CA.ToList<int>(0, 1, 2, 3, 4);
        list59 = CA.ToList<int>(5, 6, 7, 8, 9);

        _0To95By10 = new List<List<int>>(new List<int>[] { NH.GenerateIntervalInt(0, 9), NH.GenerateIntervalInt(10, 19), NH.GenerateIntervalInt(20, 29), NH.GenerateIntervalInt(30, 39), NH.GenerateIntervalInt(40, 49), NH.GenerateIntervalInt(50, 59), NH.GenerateIntervalInt(60, 69), NH.GenerateIntervalInt(70, 79), NH.GenerateIntervalInt(80, 89), NH.GenerateIntervalInt(90, 95) });
    }

    public const int one = 1;
    public const int two = 2;
    public const int three = 3;

    public static readonly List<int> list12 = CA.ToInt(CA.ToList<int>(1, 2));
    public static readonly List<int> list34 = CA.ToInt(CA.ToList<int>(3, 4));
    public static readonly List<int> list1 = CA.ToInt(CA.ToList<int>(1));
    public static readonly List<int> list2 = CA.ToInt(CA.ToList<int>(2));
    public static readonly List<string> list100Items = LinearHelper.GetStringListFromTo(0, 99);
    public static readonly List<string> list10Items = LinearHelper.GetStringListFromTo(0, 9);
    public static readonly List<int> _0To100 = NH.GenerateIntervalInt(0, 100);
    public static readonly List<List<int>> _0To95By10 = null;
    public static readonly List<int> _1To100 = NH.GenerateIntervalInt(1, 100);
    public static readonly List<int> _0To95 = NH.GenerateIntervalInt(0, 95);
}
