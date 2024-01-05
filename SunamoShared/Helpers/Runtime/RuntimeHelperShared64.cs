namespace SunamoShared.Helpers.Runtime;

public partial class RuntimeHelper
{
    public static T CastToGeneric<T>(object o)
    {
        return (T)o;
    }





    public static void EmptyDummyMethod()
    {
    }

    public static void EmptyDummyMethod(string s, params string[] o)
    {
    }

    public static void EmptyDummyMethodLogMessage(TypeOfMessage t, string s, params string[] o)
    {
    }
}
