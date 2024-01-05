namespace SunamoShared.win;


/// <summary>
/// Takže jsem ji přejmenoval pouze na 2
/// </summary>
public class PHWin2 : IPHWin
{
    public static PHWin2 ci = new PHWin2();
    public static IPHWin p = null;

    public void Code(string e)
    {
        p.Code(e);
    }
}
