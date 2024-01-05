namespace SunamoData.Data;

/// <summary>
///
/// </summary>
public class StringInt : Parsing<string, int>
{
    /// <summary>
    /// Serializuje na string a int A1
    /// </summary>
    /// <param name="obsah"></param>
    public override void ParsujM(string obsah)
    {
        if (obsah.Contains(SF.separatorString))
        {
            var fd = SF.GetAllElementsLine(obsah, null);
            t1 = fd[0];
            t2 = int.Parse(fd[1]);
        }
    }
}
