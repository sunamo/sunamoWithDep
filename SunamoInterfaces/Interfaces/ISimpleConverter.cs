namespace SunamoInterfaces.Interfaces;

public interface ISimpleConverter<TypeInClassName, U>
{
    TypeInClassName ConvertTo(U u);
    U ConvertFrom(TypeInClassName t);
}

public interface ISimpleConverter : ISimpleConverter<string, string>
{
}
