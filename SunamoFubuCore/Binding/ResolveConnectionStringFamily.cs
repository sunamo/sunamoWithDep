namespace SunamoFubuCore.Binding;

[Description("Converts text by ConfigurationManager.ConnectionStrings[text] ")]
public class ResolveConnectionStringFamily : StatelessConverter
{
    public override bool Matches(PropertyInfo property)
    {
        return property.HasAttribute<ConnectionStringAttribute>();
    }

    public static Func<string, ConnectionStringSettings> GetConnectionStringSettings = key => ConfigurationManager.ConnectionStrings[key];

    private static string getConnectionString(string name)
    {
        var connectionStringSettings = GetConnectionStringSettings(name);
        return connectionStringSettings != null
            ? connectionStringSettings.ConnectionString
            : name;
    }

    public override object Convert(IPropertyContext context)
    {
        var stringValue = context.RawValueFromRequest.RawValue as string;

        return stringValue.IsNotEmpty()
                   ? getConnectionString(stringValue)
                   : stringValue;
    }
}
