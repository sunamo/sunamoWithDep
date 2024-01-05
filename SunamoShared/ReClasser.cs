namespace SunamoShared;

public static class ReClasser
{
    /// <summary>
    ///     Must be here coz is used in JsonSystemTextJson etc.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="fixMe"></param>
    /// <returns></returns>
    public static dynamic FixMeUp(this object fixMe)
    {
        var t = fixMe.GetType();
        var returnClass = new ExpandoObject() as IDictionary<string, object>;
        var props = t.GetProperties();
        foreach (var pr in props)
        {
            var val = pr.GetValue(fixMe);
            if (val is string && string.IsNullOrWhiteSpace(val.ToString()))
            {
            }
            else if (val == null)
            {
            }
            else
            {
                returnClass.Add(pr.Name, val);
            }
        }

        return returnClass;
    }
}
