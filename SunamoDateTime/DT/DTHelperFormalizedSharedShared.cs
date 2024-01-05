namespace SunamoDateTime.DT;


public partial class DTHelperFormalized
{
    #region Parse
    /// <summary>
    /// Is used in GpxTrackFile
    /// 2018-08-10T11:33:19Z
    ///
    /// </summary>
    /// <param name="p"></param>
    public static DateTime StringToDateTimeFormalizeDate(string p)
    {
        if (string.IsNullOrEmpty(p))
        {
            return DateTime.MinValue;
        }

        if (DateTime.TryParse(p, null, out var result/*, System.Globalization.DateTimeStyles.None*/))
        {
            return result;
        }

        return DateTime.MinValue;
    }
    #endregion
}
