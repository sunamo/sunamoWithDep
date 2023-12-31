namespace SunamoFubuCore.Binding;

[Description("Uses Environment.ExpandEnvironmentVariables(text) if the property is marked with [ExpandEnvironmentVariables]")]
public class ExpandEnvironmentVariablesFamily : StatelessConverter
{
    public override bool Matches(PropertyInfo property)
    {
        return property.HasAttribute<ExpandEnvironmentVariablesAttribute>();
    }

    public override object Convert(IPropertyContext context)
    {
        var bindingValue = context.RawValueFromRequest;
        var strVal = bindingValue.RawValue as string;

        return strVal.IsNotEmpty()
                   ? Environment.ExpandEnvironmentVariables(strVal)
                   : strVal;
    }

}
