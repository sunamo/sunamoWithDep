namespace SunamoShared.Streams;
public class TextMemoryStream
{
    public StringBuilder line = new StringBuilder();
    string fn = null;
    string t = null;

    public TextMemoryStream(string t)
    {
        this.t = t;
    }

    public
#if ASYNC
    async Task
#else
    void  
#endif
        Init()
    {
        fn = t;

        string line2 = string.Empty;
        if (FS.ExistsFile(fn))
        {
            line2 =
#if ASYNC
    await
#endif
 TF.ReadAllText(t, Encoding.UTF8);
        }

        line.Append(line2);
    }

    public
#if ASYNC
    async Task
#else
    void  
#endif
 Save()
    {

#if ASYNC
        await
#endif
     TF.WriteAllText(fn, line.ToString());
    }

    //public string LineStartingWith(string date)
    //{
    //    foreach (var item in lines)
    //    {
    //        if (item.StartsWith(date))
    //        {
    //            return item;
    //        }
    //    }
    //    return null;
    //}
}
