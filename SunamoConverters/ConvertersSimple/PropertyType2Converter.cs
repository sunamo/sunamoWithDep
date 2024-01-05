using SunamoEnums.Enums;

namespace SunamoConverters.ConvertersSimple;


public class PropertyType2Converter : ISimpleConverter<PropertyType2, string>
{
    static Type type = typeof(PropertyType2Converter);

    public PropertyType2 ConvertTo(string u)
    {
        ThrowEx.NotImplementedMethod();
        return PropertyType2.Bool;
    }

    /// <summary>
    /// Dont implement all, see usage in other code
    /// </summary>
    /// <param name="t"></param>
    public string ConvertFrom(PropertyType2 t)
    {
        switch (t)
        {
            case PropertyType2.ULong:
                return "System.UInt64";
            case PropertyType2.UInt:
                return "System.UInt32";
            case PropertyType2.UShort:
                return "System.UInt16";
            case PropertyType2.Byte:
                return "System.Byte";
            case PropertyType2.String:
                return "System.String";
            case PropertyType2.Double:
                return "System.Double";
            case PropertyType2.Float:
                return "System.Single";
            case PropertyType2.DateTime:
                return "System.DateTime";
            case PropertyType2.Bool:
                return "System.Boolean";
            default:
                return "";
        }
    }
}
