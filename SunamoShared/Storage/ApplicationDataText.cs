namespace SunamoShared.Storage;

/// <summary>
/// Working with files in format Copy:
/// Shared
/// 
/// Dont copy to:
/// typings
/// 
/// Instead of Name: can use anything - for example [Header]
/// </summary>
public class ApplicationDataText
{
    private static Type type = typeof(ApplicationDataText);

    /// <summary>
    /// If file contains grouped lines by A2, return these groups
    /// </summary>
    /// <param name="file"></param>
    public static
#if ASYNC
async Task<Dictionary<string, List<string>>>
#else
  Dictionary<string, List<string>>
#endif
Parse(string file, List<string> sections)
    {
        // In key are section names from A2
        // In value its values as lines below it
        Dictionary<string, List<string>> v = new Dictionary<string, List<string>>();

        List<string> lines =
#if ASYNC
await
#endif
TF.ReadAllLines(file);
        CA.Trim(lines);
        List<string> listString = new List<string>();

        string actualSection = null;

        // Process all lines
        foreach (var item in lines)
        {
            string actualSectionBefore = actualSection;
            if (CA.IsSomethingTheSame(item, sections, ref actualSection))
            {
                CA.RemoveStringsEmpty(listString);
                if (actualSectionBefore != null)
                {
                    v.Add(actualSectionBefore, listString);
                }

                listString = new List<string>();

                continue;
            }

            // Remove strings delete CA.RemoveStringsEmpty
            listString.Add(item);
        }
        CA.RemoveStringsEmpty(listString);
        v.Add(actualSection, listString);

        ThrowEx.DifferentCountInLists("sections", sections.Count, "v", v.Count);
        return v;
    }
}
