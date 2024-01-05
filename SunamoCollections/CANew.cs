namespace SunamoCollections;

/// <summary>
/// Do doby než bude refactoring
/// Mám celkem dost velký bordel v metodách v CA
/// Takže bude třeba udělat fasádu jako jsem dříve udělal v DTHelper
/// 
/// </summary>
public class CANew
{
    public static bool ContainsAnyFromArray(string input, string[] arr)
    {
        foreach (var item in arr)
        {
            if (input.Contains(item))
            {
                return true;
            }
        }

        return false;
    }

}
