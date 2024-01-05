namespace SunamoShared.Loaders;

public class LocalizationLanguagesLoader
{
    static LocalizationLanguages result = null;

    /// <summary>
    /// Zatím mi není známo že by metoda se nemohla volat kdykoliv odkudkoliv takže ji tak budu volat.
    /// </summary>
    /// <returns></returns>
    public static LocalizationLanguages Load()
    {
        if (result == null)
        {
            //EmbeddedResourcesH er = new EmbeddedResourcesH(typeof(EmbeddedResourcesH).Assembly, "sunamo");
            //result = new LocalizationLanguages{Cs = er.GetString("/MultilingualResources/sunamo.cs-CZ.xlf"), En = ""};

            result = new LocalizationLanguages()
            {
                Cs = TF.ReadAllTextSync(@"E:\vs\Projects\sunamo\sunamo\MultilingualResources\sunamo.cs-CZ.min.xlf"),
                En = TF.ReadAllTextSync(@"E:\vs\Projects\sunamo\sunamo\MultilingualResources\sunamo.en-US.min.xlf")
            };
        }

        TranslateDictionary.localizationLanguages = result;

        return result;
    }
}
