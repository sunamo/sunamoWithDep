namespace SunamoFubuCore;



public static class TypeExtensions
{
    private static readonly IList<Type> _integerTypes = new List<Type>
{
typeof(byte),
typeof(short),
typeof(int),
typeof(long),
typeof(sbyte),
typeof(ushort),
typeof(uint),
typeof(ulong),
typeof(byte?),
typeof(short?),
typeof(int?),
typeof(long?),
typeof(sbyte?),
typeof(ushort?),
typeof(uint?),
typeof(ulong?)
};

    /// <summary>
    ///     Does a hard cast of the object to T.  *Will* throw InvalidCastException
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target"></param>
    /// <returns></returns>
    public static T As<T>(this object target)
    {
        return (T)target;
    }

    public static bool IsNullableOfT(this Type theType)
    {
        if (theType == null) return false;

        return theType.IsGenericType && theType.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
    }

    public static bool IsNullableOf(this Type theType, Type otherType)
    {
        return theType.IsNullableOfT() && theType.GetGenericArguments()[0].Equals(otherType);
    }

    public static bool IsTypeOrNullableOf<T>(this Type theType)
    {
        var otherType = typeof(T);
        return theType == otherType ||
        theType.IsNullableOfT() && theType.GetGenericArguments()[0].Equals(otherType);
    }

    public static bool CanBeCastTo<T>(this Type type)
    {
        if (type == null) return false;
        var destinationType = typeof(T);

        return CanBeCastTo(type, destinationType);
    }

    public static bool CanBeCastTo(this Type type, Type destinationType)
    {
        if (type == null) return false;
        if (type == destinationType) return true;

        return destinationType.IsAssignableFrom(type);
    }

    public static bool IsInNamespace(this Type type, string nameSpace)
    {
        if (type == null) return false;

        return type.Namespace.StartsWith(nameSpace);
    }

    public static bool IsOpenGeneric(this Type type)
    {
        if (type == null) return false;

        return type.IsGenericTypeDefinition || type.ContainsGenericParameters;
    }

    public static bool IsGenericEnumerable(this Type type)
    {
        if (type == null) return false;

        var genericArgs = type.GetGenericArguments();
        return genericArgs.Length == 1 && typeof(IEnumerable<>).MakeGenericType(genericArgs).IsAssignableFrom(type);
    }

    public static bool IsConcreteTypeOf<T>(this Type pluggedType)
    {
        if (pluggedType == null) return false;

        return pluggedType.IsConcrete() && typeof(T).IsAssignableFrom(pluggedType);
    }

    public static bool ImplementsInterfaceTemplate(this Type pluggedType, Type templateType)
    {
        if (!pluggedType.IsConcrete()) return false;

        foreach (var interfaceType in pluggedType.GetInterfaces())
            if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == templateType)
                return true;

        return false;
    }

    public static bool IsConcreteWithDefaultCtor(this Type type)
    {
        return type.IsConcrete() && type.GetConstructor(new Type[0]) != null;
    }

    public static Type FindInterfaceThatCloses(this Type type, Type openType)
    {
        if (type == typeof(object)) return null;

        if (type.IsInterface && type.IsGenericType && type.GetGenericTypeDefinition() == openType) return type;


        foreach (var interfaceType in type.GetInterfaces())
            if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == openType)
                return interfaceType;

        if (!type.IsConcrete()) return null;


        return type.BaseType == typeof(object)
        ? null
        : type.BaseType.FindInterfaceThatCloses(openType);
    }

    public static Type FindParameterTypeTo(this Type type, Type openType)
    {
        var interfaceType = type.FindInterfaceThatCloses(openType);
        return interfaceType == null ? null : interfaceType.GetGenericArguments().FirstOrDefault();
    }

    public static bool IsNullable(this Type type)
    {
        return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
    }

    public static bool Closes(this Type type, Type openType)
    {
        if (type == null) return false;

        if (type.IsGenericType && type.GetGenericTypeDefinition() == openType) return true;

        foreach (var @interface in type.GetInterfaces())
            if (@interface.Closes(openType))
                return true;

        var baseType = type.BaseType;
        if (baseType == null) return false;

        var closes = baseType.IsGenericType && baseType.GetGenericTypeDefinition() == openType;
        if (closes) return true;

        return type.BaseType == null ? false : type.BaseType.Closes(openType);
    }

    public static Type GetInnerTypeFromNullable(this Type nullableType)
    {
        return nullableType.GetGenericArguments()[0];
    }


    public static string GetName(this Type type)
    {
        if (type.IsGenericType)
        {
            var parameters = Array.ConvertAll(type.GetGenericArguments(), t => t.GetName());
            var parameterList = string.Join(", ", parameters);
            return "{0}<{1}>".ToFormat(type.Name, parameterList);
        }

        return type.Name;
    }

    public static string GetFullName(this Type type)
    {
        if (type.IsGenericType)
        {
            var parameters = Array.ConvertAll(type.GetGenericArguments(), t => t.GetName());
            var parameterList = string.Join(", ", parameters);
            return "{0}<{1}>".ToFormat(type.Name, parameterList);
        }

        return type.FullName;
    }


    public static bool IsString(this Type type)
    {
        return type.Equals(typeof(string));
    }

    public static bool IsPrimitive(this Type type)
    {
        return type.IsPrimitive && !type.IsString() && type != typeof(IntPtr);
    }

    public static bool IsSimple(this Type type)
    {
        return type.IsPrimitive || type.IsString() || type.IsEnum;
    }

    public static bool IsConcrete(this Type type)
    {
        if (type == null) return false;

        return !type.IsAbstract && !type.IsInterface;
    }

    public static bool IsNotConcrete(this Type type)
    {
        return !type.IsConcrete();
    }

    /// <summary>
    ///     Returns true if the type is a DateTime or nullable DateTime
    /// </summary>
    /// <param name="typeToCheck"></param>
    /// <returns></returns>
    public static bool IsDateTime(this Type typeToCheck)
    {
        return typeToCheck == typeof(DateTime) || typeToCheck == typeof(DateTime?);
    }

    public static bool IsBoolean(this Type typeToCheck)
    {
        return typeToCheck == typeof(bool) || typeToCheck == typeof(bool?);
    }

    /// <summary>
    ///     Displays type names using CSharp syntax style. Supports funky generic types.
    /// </summary>
    /// <param name="type">Type to be pretty printed</param>
    /// <returns></returns>
    public static string PrettyPrint(this Type type)
    {
        return type.PrettyPrint(t => t.Name);
    }

    /// <summary>
    ///     Displays type names using CSharp syntax style. Supports funky generic types.
    /// </summary>
    /// <param name="type">Type to be pretty printed</param>
    /// <param name="selector">
    ///     Function determining the name of the type to be displayed. Useful if you want a fully qualified
    ///     name.
    /// </param>
    /// <returns></returns>
    public static string PrettyPrint(this Type type, Func<Type, string> selector)
    {
        var typeName = selector(type) ?? string.Empty;
        if (!type.IsGenericType) return typeName;

        var genericParamSelector = type.IsGenericTypeDefinition ? t => t.Name : selector;
        var genericTypeList = string.Join(",", type.GetGenericArguments().Select(genericParamSelector).ToArray());
        var tickLocation = typeName.IndexOf('`');
        if (tickLocation >= 0) typeName = typeName.Substring(0, tickLocation);
        return string.Format("{0}<{1}>", typeName, genericTypeList);
    }

    /// <summary>
    ///     Returns a boolean value indicating whether or not the type is:
    ///     int, long, decimal, short, float, or double
    /// </summary>
    /// <param name="type"></param>
    /// <returns>Bool indicating whether the type is numeric</returns>
    public static bool IsNumeric(this Type type)
    {
        return type.IsFloatingPoint() || type.IsIntegerBased();
    }


    /// <summary>
    ///     Returns a boolean value indicating whether or not the type is:
    ///     int, long or short
    /// </summary>
    /// <param name="type"></param>
    /// <returns>Bool indicating whether the type is integer based</returns>
    public static bool IsIntegerBased(this Type type)
    {
        return _integerTypes.Contains(type);
    }

    /// <summary>
    ///     Returns a boolean value indicating whether or not the type is:
    ///     decimal, float or double
    /// </summary>
    /// <param name="type"></param>
    /// <returns>Bool indicating whether the type is floating point</returns>
    public static bool IsFloatingPoint(this Type type)
    {
        return type == typeof(decimal) || type == typeof(float) || type == typeof(double);
    }


    public static T CloseAndBuildAs<T>(this Type openType, params Type[] parameterTypes)
    {
        var closedType = openType.MakeGenericType(parameterTypes);
        return (T)Activator.CreateInstance(closedType);
    }

    public static T CloseAndBuildAs<T>(this Type openType, object ctorArgument, params Type[] parameterTypes)
    {
        var closedType = openType.MakeGenericType(parameterTypes);
        return (T)Activator.CreateInstance(closedType, ctorArgument);
    }

    public static bool PropertyMatches(this PropertyInfo prop1, PropertyInfo prop2)
    {
        return prop1.DeclaringType == prop2.DeclaringType && prop1.Name == prop2.Name;
    }

    public static T Create<T>(this Type type)
    {
        return (T)type.Create();
    }

    public static object Create(this Type type)
    {
        return Activator.CreateInstance(type);
    }


    public static Type IsAnEnumerationOf(this Type type)
    {
        if (!type.Closes(typeof(IEnumerable<>))) throw new Exception("Duh, its gotta be enumerable");

        if (type.IsArray) return type.GetElementType();

        if (type.IsGenericType) return type.GetGenericArguments()[0];


        throw new Exception("I don't know how to figure out what this is a collection of. Can you tell me? {0}"
        .ToFormat(type));
    }
}
