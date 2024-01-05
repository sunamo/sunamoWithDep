namespace SunamoShared.Helpers;


class SerializerHelper<T>
    where T : ISerializable
{ }

/// <summary>
/// SerializerHelper vyžaduje T a musel bych ho napsat do třídy aby se mi nabídli metody
/// </summary>
public static class SerializerHelperJson
{
    public static string GetPath(string fileNameWithoutExt)
    {
        return AppData.ci.GetFile(AppFolders.Other, fileNameWithoutExt + ".json");
    }

    /// <summary>
    /// Writes the given object instance to a Json file.
    /// <para>Object type must have a parameterless constructor.</para>
    /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
    /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [JsonIgnore] attribute.</para>
    /// </summary>
    /// <typeparam name="T">The type of object being written to the file.</typeparam>
    /// <param name="filePath">The file path to write the object instance to.</param>
    /// <param name="objectToWrite">The object instance to write to the file.</param>
    /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
    public static
#if ASYNC
    async Task
#else
    void  
#endif
 WriteToJsonFile<T>(
        string fileNameWithoutExt,
        T objectToWrite,
        WriteToJsonFileData a = null

    )
        where T : new()
    {
        if (a == null)
        {
            a = new WriteToJsonFileData();
        }

        var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite, a.formatting);
        var path = GetPath(fileNameWithoutExt);
#if ASYNC
        await
#endif
            TF.WriteAllText(path, contentsToWriteToFile, a.append);

        if (a.phWinCode != null)
        {
            a.phWinCode.Invoke(path);
        }
    }

    /// <summary>
    /// Reads an object instance from an Json file.
    /// <para>Object type must have a parameterless constructor.</para>
    /// </summary>
    /// <typeparam name="T">The type of object to read from the file.</typeparam>
    /// <param name="filePath">The file path to read the object instance from.</param>
    /// <returns>Returns a new instance of the object read from the Json file.</returns>
    public static
#if ASYNC
    async Task<T>
#else
    T  
#endif
 ReadFromJsonFile<T>(string fileNameWithoutExt)
        where T : new()
    {
        var fileContents =
#if ASYNC
    await
#endif
TF.ReadAllText(GetPath(fileNameWithoutExt));
        var deser = JsonConvert.DeserializeObject<T>(fileContents);

        return deser;
    }
}
