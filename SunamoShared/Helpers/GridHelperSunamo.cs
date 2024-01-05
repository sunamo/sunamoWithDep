namespace SunamoShared.Helpers;
public class GridHelperSunamo
{
    /// <summary>
    /// After can be use with XamlGeneratorDesktop.Write*Definitions 
    /// </summary>
    /// <param name="columns"></param>
    /// <returns></returns>
    public static List<string> ForAllTheSame(int columns)
    {
        List<string> result = new List<string>(columns);
        var d = 100d / columns;
        for (int i = 0; i < columns; i++)
        {
            result.Add(d + AllStrings.asterisk);
        }

        return result;
    }
}
