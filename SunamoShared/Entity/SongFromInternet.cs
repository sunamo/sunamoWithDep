namespace SunamoShared.Entity;


public class SongFromInternet : IEquatable<SongFromInternet>
{
    List<string> nazev = new List<string>();
    List<string> title = new List<string>();
    List<string> remix = new List<string>();
    List<string> nazevWoDiacritic = new List<string>();
    List<string> titleWoDiacritic = new List<string>();
    List<string> remixWoDiacritic = new List<string>();
    public string ytCode = null;
    public int idInDb = int.MaxValue;

    string _artistS = null;
    string _titleS = null;
    string _remixS = null;

    public string ArtistC
    {
        get
        {
            return _artistS;
        }
        set { _artistS = value; }
    }

    public string TitleC
    {
        get
        {
            return _titleS;
        }
        set { _titleS = value; }
    }

    public string RemixC
    {
        get
        {
            return _remixS;
        }
        set { _remixS = value; }
    }

    public void Artist(string item)
    {
        nazev.Clear();
        nazevWoDiacritic.Clear();

        nazev.AddRange(SplitNazevTitle(item));
        nazevWoDiacritic = CA.WithoutDiacritic(nazev);

        _artistS = ArtistInConvention();
    }

    #region ctor
    public SongFromInternet()
    {

    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="song"></param>
    /// <param name="ytCode"></param>
    public SongFromInternet(string song, string ytCode = null)
    {
        string n, t, r;
        ManageArtistDashTitle.GetArtistTitleRemix(song, out n, out t, out r);

        Init(n, t, r);

        this.ytCode = ytCode;

    }

    public SongFromInternet(SongFromInternet item2)
    {
        // TODO: Complete member initialization
        nazev = new List<string>(item2.nazev);
        title = new List<string>(item2.title);
        remix = new List<string>(item2.remix);
        SetInConvention();
    }

    public SongFromInternet Init(Tuple<string, string, string> t)
    {
        return Init(t.Item1, t.Item2, t.Item3);
    }

    public SongFromInternet Init(string n, string t, string r)
    {
        Artist(n);

        var splittedNazevTitle = SplitNazevTitle(t);
        var splittedRemix = SplitRemix(r);

        title.AddRange(splittedNazevTitle);
        remix.AddRange(splittedRemix);

        titleWoDiacritic = CA.WithoutDiacritic(CA.ToListStringIList(title));
        remixWoDiacritic = CA.WithoutDiacritic(CA.ToListStringIList(remix));

        SetInConvention();

        return this;
    }
    #endregion



    /// <summary>
    /// Pro správné porovnání musí být všechny řetězce jak v A1 tak v A2 lowercase
    /// </summary>
    public static bool IsSimilar(string[] titleArray, string name)
    {
        return IsSimilar(new List<string>(titleArray), name);
    }

    /// <summary>
    /// Pro správné porovnání musí být všechny řetězce jak v A1 tak v A2 lowercase
    /// </summary>
    /// <param name="titleArray"></param>
    /// <param name="name"></param>
    public static bool IsSimilar(List<string> titleArray, string name)
    {
        // titleArray - originally entered
        // name,nameArray - from spotify
        int psn, prn;
        var nameArray = SHSplit.SplitBySpaceAndPunctuationCharsAndWhiteSpaces(name);
        SongFromInternet.VratPocetStejnychARozdilnych(titleArray, nameArray, out psn, out prn);
        if (CalculateSimilarity(psn, prn, titleArray, new List<string>(nameArray)) > 0.49f)
        {
            return true;
        }
        return false;
    }

    private void SetInConvention()
    {
        _artistS = ArtistInConvention();
        _titleS = TitleInConvention();
        _remixS = RemixInConvention();
    }



    /// <summary>
    /// Replace without feat etc
    /// </summary>
    public string RemixOnlyContent()
    {
        var r = Remix();
        r = CA.ReplaceAll(r, AllLists.featLower, string.Empty);
        r = CA.ReplaceAll(r, AllLists.featUpper, string.Empty);
        return r;
    }

    /// <summary>
    /// Porovnává s ohledem na diakritiku
    /// </summary>
    /// <param name="p"></param>
    public float CalculateSimilarity(string p)
    {
        SongFromInternet s = new SongFromInternet(p);
        return CalculateSimilarity(s, false);
    }

    public float CalculateSimilarity(SongFromInternet s, bool woDiacritic)
    {
        float n, t, r;
        if (woDiacritic)
        {
            int psn, prn, pst, prt, psr, prr;
            VratPocetStejnychARozdilnych(s.nazevWoDiacritic, nazevWoDiacritic, out psn, out prn);
            VratPocetStejnychARozdilnych(s.titleWoDiacritic, titleWoDiacritic, out pst, out prt);
            VratPocetStejnychARozdilnych(s.remixWoDiacritic, remixWoDiacritic, out psr, out prr);

            n = CalculateSimilarity(psn, prn, s.nazev, nazevWoDiacritic);
            t = CalculateSimilarity(pst, prt, s.title, titleWoDiacritic);
            r = CalculateSimilarity(psr, prr, s.remix, remixWoDiacritic);
        }
        else
        {
            int psn, prn, pst, prt, psr, prr;
            VratPocetStejnychARozdilnych(s.nazev, nazev, out psn, out prn);
            VratPocetStejnychARozdilnych(s.title, title, out pst, out prt);
            VratPocetStejnychARozdilnych(s.remix, remix, out psr, out prr);

            n = CalculateSimilarity(psn, prn, s.nazev, nazev);
            t = CalculateSimilarity(pst, prt, s.title, title);
            r = CalculateSimilarity(psr, prr, s.remix, remix);
        }

        float vr = (n + t) / 2;
        if (vr == 1)
        {
            vr = (n + t + r) / 3;
        }

        return vr;
    }





    /// <summary>
    /// A1 pSn = count of Same
    /// A2 pRn = count of Rozdílný/different (sum of keep from both collection)
    /// </summary>
    /// <param name="psn"></param>
    /// <param name="prn"></param>
    /// <param name="novy"></param>
    /// <param name="puvodni"></param>
    public static float CalculateSimilarity(int psn, int prn, List<string> novy, List<string> puvodni)
    {
        if (psn == prn && psn == 0)
        {
            return 1.0f;
        }
        if (psn > prn)
        {
            //prn == 1 ||
            if (prn == 0)
            {
                int uy = 0;
                for (int i = 0; i < novy.Count; i++)
                {
                    if (puvodni.Contains(novy[i]))
                    {
                        uy++;
                    }
                }
                if (uy == novy.Count) // - 1
                {
                    return 1.0f;
                }
                //return 1.0f;
                return 1f / 3f * 2f;
            }
            if (prn != 0)
            {
                if (prn != 1)
                {

                    return psn / prn;
                }
                if (psn > 3)
                {
                    float vr = (psn - prn) / 2f;
                    while (vr > 1f)
                    {
                        vr /= 2f;
                    }
                    return vr;
                }
                else
                {
                    float vr = (psn - psn / (psn - 1f)) / 2;
                    int uy = 0;
                    for (int i = 0; i < novy.Count; i++)
                    {
                        if (puvodni.Contains(novy[i]))
                        {
                            uy++;
                        }
                    }
                    if (uy > 0)
                    {
                        vr = uy / (float)prn / 2f;
                    }
                    if (vr > 0.99f)
                    {
                        vr = vr / 2f;
                    }
                    return vr;
                }
                //return 0.5f;
            }


            return 0f;
        }
        if (psn + 1 > prn && psn < 3)
        {
            return 0.5f;
        }

        return 0f;

    }

    /// <summary>
    /// A2 - compare both after diac trim
    /// A3 - minimal for return true
    /// </summary>
    /// <param name="s"></param>
    /// <param name="woDiacritic"></param>
    /// <param name="minimal"></param>
    /// <returns></returns>
    public float CalculateSimilarityAll(SongFromInternet s, bool woDiacritic, float minimal)
    {
        var _this = this;

        var result = CalculateSimilarity(s, woDiacritic);
        float result2 = 0;
        bool _continue = true;
        if (minimal <= result)
        {
            _continue = false;
        }

        List<string> feats = null;
        if (_continue)
        {
            var song = s.TitleC;
            feats = s.AlternateArtists();
            foreach (var item in feats)
            {
                s = new SongFromInternet(item + AllStringsSE.dash + song);
                result2 = CalculateSimilarity(s, true);

                if (breakInCalculateSimilarity)
                {
                    Debugger.Break();
                }

                if (result2 > result)
                {
                    result = result2;
                }
                if (minimal <= result)
                {
                    break;
                }
            }
        }

        if (breakInCalculateSimilarity)
        {
            Debugger.Break();
        }

        return result;

    }

    public static bool breakInCalculateSimilarity = false;
    public string Artist()
    {
        return SHJoin.JoinSpace(nazev);
    }

    public string ArtistInConvention()
    {
        return ConvertEveryWordLargeCharConvention.ToConvention(Artist());
    }

    public string Title()
    {
        return SHJoin.JoinSpace(title);
    }

    public string TitleInConvention()
    {
        return ConvertEveryWordLargeCharConvention.ToConvention(Title());
    }

    public string Remix()
    {
        return SHJoin.JoinSpace(remix);
    }

    public string RemixInConvention()
    {
        return ConvertEveryWordLargeCharConvention.ToConvention(Remix());
    }

    public string TitleAndRemixInConvention()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(TitleInConvention());
        if (remix.Count != 0)
        {
            sb.Append(AllStringsSE.lsqb + RemixInConvention() + AllStringsSE.rsqb);
        }
        return sb.ToString();
    }

    /// <summary>
    /// A1,2 are list to compare
    /// A3 pSn = count of Same
    /// A4 pRn = count of Rozdílný/different (sum of keep from both collection)
    /// </summary>
    /// <param name="list"></param>
    /// <param name="list_2"></param>
    /// <param name="psn"></param>
    /// <param name="prn"></param>
    public static void VratPocetStejnychARozdilnych(List<string> list, List<string> list_2, out int psn, out int prn)
    {
        // Create copies of A1,2
        List<string> l1 = new List<string>(list.ToArray());
        List<string> l2 = new List<string>(list_2.ToArray());
        psn = 0;

        // Process all in l1
        for (int i = l1.Count - 1; i >= 0; i--)
        {
            int dex = l2.IndexOf(l1[i]);
            if (dex != -1)
            {
                // if l1 is in l2, remove from both
                l1.RemoveAt(i);
                l2.RemoveAt(dex);

                psn++;
            }
        }

        prn = l1.Count + l2.Count;
    }

    public override string ToString()
    {
        StringBuilder vr = new StringBuilder();
        vr.Append(Artist() + AllStringsSE.dash + Title());
        if (remix.Count != 0)
        {
            vr.Append(" [" + Remix() + AllStringsSE.rsqb);
        }
        return vr.ToString();
    }

    public string ToConventionString()
    {
        StringBuilder vr = new StringBuilder();
        vr.Append(ArtistInConvention() + AllStringsSE.dash + TitleInConvention());
        if (remix.Count != 0)
        {
            vr.Append(" [" + RemixInConvention() + AllStringsSE.rsqb);
        }
        return vr.ToString();
    }

    private IList<string> SplitRemix(string u)
    {
        // comma - artists like Hm... or The Academy Is..
        List<string> gg = SHSplit.Split(u, AllStringsSE.amp, AllStringsSE.space, AllStringsSE.comma, AllStringsSE.dash, AllStringsSE.lsqb, AllStringsSE.rsqb, AllStringsSE.lb, AllStringsSE.rb);
        //gg.ForEach(g => g.ToLower());
        for (int i = 0; i < gg.Count; i++)
        {
            gg[i] = gg[i].ToLower();
        }
        return gg;
    }

    private IList<string> SplitNazevTitle(string u)
    {
        List<string> gg = SHSplit.Split(u, AllStringsSE.amp, AllStringsSE.space, AllStringsSE.comma, AllStringsSE.dash);
        //gg.ForEach(g => g.ToLower());
        for (int i = 0; i < gg.Count; i++)
        {
            gg[i] = gg[i].ToLower();
        }
        return gg;
    }

    public List<string> AlternateArtists()
    {
        var remix = Remix();
        remix = SHReplace.ReplaceAll(remix, "Ft", "ft",
            sess.i18n(XlfKeys.Feat), "feat");
        remix = remix.Trim(AllCharsSE.dot);
        remix = remix.Trim();

        var art = SHSplit.Split(remix, "&", " and ");
        return art;
    }

    public int Compare(object x, object y)
    {
        var xx = (SongFromInternet)x;
        var xy = (SongFromInternet)y;

        const float min = 0.5f;

        var f = xy.CalculateSimilarityAll(xx, false, min);
        if (min <= f)
        {
            return 1;
        }
        return 0;
    }

    public override bool Equals(object obj)
    {
        return Equals((SongFromInternet)obj);
    }

    public bool Equals(SongFromInternet other)
    {
        return BTS.IntToBool(Compare(this, other));
    }

    private readonly StringComparer comparer = StringComparer.OrdinalIgnoreCase;

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }
}
