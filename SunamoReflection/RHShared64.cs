//using SunamoReflection.Enums;

using SunamoReflection.Args;
using SunamoReflection.Enums;

namespace SunamoReflection;
public partial class RH
{
    static Type type = typeof(ThrowEx);

    public static string FullPathCodeEntity(Type t)
    {
        return t.Namespace + AllStringsSE.dot + t.Name;
    }

    public static Assembly AssemblyWithName(string name)
    {
        var ass = AppDomain.CurrentDomain.GetAssemblies();
        var result = ass.Where(d => d.GetName().Name == name);
        if (result.Count() == 0)
        {
            result = ass.Where(d => d.FullName == name);
        }
        if (result.Count() == 0)
        {
            result = ass.Where(d => d.FullName.Contains(name));
        }
        return result.FirstOrDefault();
    }

    private static List<PropertyInfo> GetProps(object carSAuto)
    {
        Type carSAutoType = GetType(carSAuto);

        var result = carSAutoType.GetProperties().ToList();
        return result;
    }

    private static Type GetType(object carSAuto)
    {
        Type carSAutoType = null;
        var t1 = carSAuto.GetType();

        if (IsType(t1))
        {
            carSAutoType = carSAuto as Type;
        }
        else
        {
            carSAutoType = carSAuto.GetType();
        }

        return carSAutoType;
    }

    /// <summary>
    /// A1 can be Type of instance
    /// All fields must be public
    /// </summary>
    /// <param name="carSAutoType"></param>
    public static List<FieldInfo> GetFields(object carSAuto)
    {
        Type carSAutoType = null;
        var t1 = carSAuto.GetType();

        if (IsType(t1))
        {
            carSAutoType = carSAuto as Type;
        }
        else
        {
            carSAutoType = carSAuto.GetType();
        }
        var result = carSAutoType.GetFields().ToList();
        return result;
    }

    private static bool IsType(Type t1)
    {
        var t2 = typeof(Type);
        return t1.FullName == "System.RuntimeType" || t1 == t2;
    }

    public static Dictionary<string, string> GetValuesOfConsts(Type t, params string[] onlyNames)
    {
        var props = RH.GetConsts(t);
        Dictionary<string, string> values = new Dictionary<string, string>(props.Count);

        foreach (var item in props)
        {
            if (onlyNames.Length > 0)
            {
                if (!onlyNames.Contains(item.Name))
                {
                    continue;
                }
            }

            var o = GetValueOfField(item.Name, t, null, false);
            values.Add(item.Name, o.ToString());
        }

        return values;
    }


    public static List<string> GetValuesOfConsts(Type type)
    {
        var c = GetConsts(type);
        List<string> vr = new List<string>();
        foreach (var item in c)
        {
            vr.Add(SH.NullToStringOrDefault(item.GetValue(null)));
        }
        CA.Trim(vr);
        return vr;
    }

    public static object GetValueOfProperty(string name, Type type, object instance, bool ignoreCase)
    {
        PropertyInfo[] pis = type.GetProperties();
        return GetValue(name, type, instance, pis, ignoreCase, null);
    }

    public static object GetValueOfPropertyOrField(object o, string name)
    {
        var type = o.GetType();

        var value = GetValueOfProperty(name, type, o, false);

        if (value == null)
        {
            value = GetValueOfField(name, type, o, false);
        }

        return value;
    }

    public static string DumpListAsString(DumpAsStringArgs a, bool removeNull = false)
    {
        StringBuilder sb = new StringBuilder();
        var f = CAG.ToList<object>((IList)a.o);

        if (removeNull)
        {
            f.RemoveAll(d => d == null);
        }

        if (f.Count > 0)
        {
            sb.AppendLine(NameOfFieldsFromDump(f.First(), a));

            foreach (var item in f)
            {
                a.o = item;
                sb.AppendLine(DumpAsString(a));
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// DumpAsString2 se mi ztratilo
    /// nemůžu ho najít v žádném repu
    /// </summary>
    /// <param name="name"></param>
    /// <param name="o"></param>
    /// <returns></returns>
    public static string DumpListAsString(string name, IList o)
    {
        StringBuilder sb = new StringBuilder();

        int i = 0;
        foreach (var item in o)
        {
            throw new NotImplementedException();
            //sb.AppendLine(DumpAsString2(name + "#" + i, item));
            //i++;
        }

        return sb.ToString();
    }

    public static string DumpListAsStringOneLine(string operation, IList o, DumpAsStringHeaderArgs a)
    {
        if (o.Count > 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Consts._3Asterisks);
            sb.AppendLine(operation + AllStringsSE.space + AllStringsSE.lb + o.Count + AllStringsSE.rb + AllStringsSE.colon);

            sb.AppendLine(NameOfFieldsFromDump(o.Count != 0 ? null : o[0], a));

            int i = 0;
            foreach (var item in o)
            {
                sb.AppendLine(DumpAsString(new DumpAsStringArgs { d = SunamoReflection.Enums.DumpProvider.Reflection, deli = AllStringsSE.swd, o = item, onlyValues = true, onlyNames = a.onlyNames }));
                i++;
            }

            sb.AppendLine(Consts._3Asterisks);
            return sb.ToString();
        }
        return string.Empty;
    }

    /////// <summary>
    /////// Delimited by NL
    /////// </summary>
    /////// <param name="v"></param>
    /////// <param name="device"></param>
    /////// <returns></returns>
    //public static string DumpAsString2(string v, object device)
    //{
    //    return SunamoExceptions.RH.DumpAsString(v, device);
    //    //DumpAsString(new DumpAsStringArgs { name = v, o = device, d = DumpProvider.Yaml });
    //}

    /// <summary>
    /// swda Delimiter
    /// Mainly for fast comparing objects
    ///
    /// Zde můžu zadat jen onlyNames kvůli DumpAsStringHeaderArgs
    /// Pokud chci více customizovat výstup, musím užít DumpAsString - DumpAsStringArgs
    /// </summary>
    /// <param name="v"></param>
    /// <param name="tableRowPageNew"></param>
    /// <returns></returns>
    public static string DumpAsString3(object tableRowPageNew, DumpAsStringHeaderArgs a = null)
    {
        if (a == null)
        {
            a = DumpAsStringHeaderArgs.Default;
        }
        var dasa = new DumpAsStringArgs { o = tableRowPageNew, deli = AllStringsSE.swd, onlyValues = true, onlyNames = a.onlyNames };
        return DumpAsString(dasa);
    }

    public static List<string> GetValuesOfField(object o, params string[] onlyNames)
    {
        return GetValuesOfField(o, onlyNames);
    }

    public static List<string> GetValuesOfField(object o, IList<string> onlyNames, bool onlyValues)
    {
        var t = o.GetType();
        var props = t.GetFields();
        List<string> values = new List<string>(props.Length);

        foreach (var item in props)
        {
            if (onlyNames.Count > 0)
            {
                if (!onlyNames.Contains(item.Name))
                {
                    continue;
                }
            }

            //values.Add(item.Name + AllStrings.cs2 + SH.ListToString(GetValueOfField(item.Name, t, o, false)));

            AddValue(values, item.Name, SH.ListToString(GetValueOfField(item.Name, t, o, false), null), onlyValues);
        }

        return values;
    }

    public static List<string> GetValuesOfProperty2(object obj, List<string> onlyNames, bool onlyValues, bool takeVariablesIfThereIsNoProps = true)
    {
        var onlyNames2 = onlyNames.ToList();
        List<string> values = new List<string>();

        string name = null;
        var props = GetProps(obj); //TypeDescriptor.GetProperties(obj);

        bool isAllNeg = true;
        foreach (var item in onlyNames)
        {
            if (!item.StartsWith(AllStringsSE.excl))
            {
                isAllNeg = false;
            }
        }

        if (props.Count == 0)
        {
            var d = GetFields(obj);
            foreach (var descriptor in d)
            {
                GetValue(descriptor, isAllNeg, onlyNames, onlyNames2, obj, values, onlyValues);
            }
        }
        else
        {
            foreach (var descriptor in props)
            {
                GetValue(descriptor, isAllNeg, onlyNames, onlyNames2, obj, values, onlyValues);
            }
        }

        return values;
    }

    public static void GetValue(MemberInfo descriptor, bool isAllNeg, List<string> onlyNames, List<string> onlyNames2, object obj, List<string> values, bool onlyValues)
    {
        bool add = true;
        var name = descriptor.Name;

        if (onlyNames.Contains(AllStringsSE.excl + name))
        {
            return;
        }

        if (onlyNames2.Count > 0)
        {
            if (isAllNeg)
            {
                if (onlyNames2.Contains(AllStringsSE.excl + name))
                {
                    add = false;
                }
            }
            else
            {
                if (!onlyNames2.Contains(name))
                {
                    add = false;
                }
            }
        }

        if (add)
        {
            var value = GetValue(obj, descriptor);
            AddValue(values, name, value, onlyValues);
        }
    }



    public static object GetValueOfField(string name, Type type, object instance, bool ignoreCase)
    {
        FieldInfo[] pis = type.GetFields();

        return GetValue(name, type, instance, pis, ignoreCase, null);
    }

    private static object GetValue(object instance, MemberInfo[] property, object v)
    {
        return GetValue(instance, property);
    }

    private static object GetValue(object instance, params MemberInfo[] property)
    {
        var val = property[0];

        if (val is PropertyInfo)
        {
            var pi = (PropertyInfo)val;
            return pi.GetValue(instance);
        }
        else if (val is FieldInfo)
        {
            var pi = (FieldInfo)val;
            return pi.GetValue(instance);
        }

        return null;
    }


    public static object GetValue(string name, Type type, object instance, IList pis, bool ignoreCase, object v)
    {
        return GetOrSetValue(name, type, instance, pis, ignoreCase, GetValue, v);
    }



    public static object GetOrSetValue(string name, Type type, object instance, IList pis, bool ignoreCase, Func<object, MemberInfo[], object, object> getOrSet, object v)
    {
        if (ignoreCase)
        {
            name = name.ToLower();
            foreach (MemberInfo item in pis)
            {
                if (item.Name.ToLower() == name)
                {
                    var property = type.GetMember(name);
                    if (property != null)
                    {
                        return getOrSet(instance, property, v);
                        //return GetValue(instance, property);
                    }
                }
            }
        }
        else
        {
            foreach (MemberInfo item in pis)
            {
                if (item.Name == name)
                {
                    var property = type.GetMember(name);
                    if (property != null)
                    {
                        return getOrSet(instance, property, v);
                        //return GetValue(instance, property);
                    }
                }
            }
        }
        return null;
    }




    private static void AddValue(List<string> values, string name, object value, bool onlyValue)
    {
        var v = SH.ListToString(value, null);
        if (onlyValue)
        {
            values.Add(v);
        }
        else
        {
            values.Add($"{name}: {v}");
        }

    }

    ///// <summary>
    ///// Check whether A1 is or is derived from A2
    ///// </summary>
    ///// <param name="type1"></param>
    ///// <param name="type2"></param>
    //public static bool IsOrIsDeriveFromBaseClass(Type children, Type parent, bool a1CanBeString = true)
    //{
    //    return se.RH.IsOrIsDeriveFromBaseClass(children, parent, a1CanBeString);
    //}

    public static string DumpAsObjectDumperNet(object o)
    {
        return ObjectDumperNetHelper.Dump(o);
    }

    /// <summary>
    /// A1 have to be selected
    /// </summary>
    /// <param name="name"></param>
    /// <param name="o"></param>
    public static string DumpAsString(DumpAsStringArgs a)
    {
        // When I was serializing ISymbol, execution takes unlimited time here
        //return o.DumpToString(name);
        string dump = null;
        if (a.o.GetType() == Types.tString)
        {
            dump = a.o.ToString();
        }
        else
        {
            switch (a.d)
            {
                case DumpProvider.Xml:
                    dump = DumpAsXml(a.o);
                    break;
                case DumpProvider.ObjectDumperNet:
                    return DumpAsObjectDumperNet(a.o);
                    break;
                case DumpProvider.Yaml:
                case DumpProvider.Json:
                case DumpProvider.Reflection:
                    dump = string.Join(a.onlyValues ? a.deli : Environment.NewLine, GetValuesOfProperty2(a.o, a.onlyNames, a.onlyValues));
                    break;
                default:
                    ThrowEx.NotImplementedCase(a.d);
                    break;
            }
        }
        if (string.IsNullOrWhiteSpace(a.name))
        {
            return dump;
        }
        return a.name + Environment.NewLine + dump;

    }

    public static string DumpAsReflection(object o)
    {
        return DumpAsString(new DumpAsStringArgs { d = DumpProvider.Reflection, o = o });
    }

    private static string NameOfFieldsFromDump(object obj, DumpAsStringHeaderArgs a)
    {
        var properties = TypeDescriptor.GetProperties(obj);
        List<string> ls = new List<string>();

        string name = null;

        foreach (YamlDotNet.Serialization.PropertyDescriptor descriptor in properties)
        {
            name = descriptor.Name;
            if (a.onlyNames.Contains(AllStringsSE.excl + name))
            {
                continue;
            }
            ls.Add(name);
        }

        return string.Join(AllStringsSE.swd, ls);
    }

    public static string DumpAsString3Dictionary3<T, T2, U>(string operation, Dictionary<T, Dictionary<T2, List<U>>> grouped)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(operation);

        foreach (var item in grouped)
        {
            sb.AppendLine("1) " + item.Key.ToString());

            foreach (var item3 in item.Value)
            {
                sb.AppendLine("2) " + item3.Key.ToString());

                foreach (var v in item3.Value)
                {
                    sb.AppendLine(v.ToString());
                }
                sb.AppendLine();
            }
        }

        var vr = sb.ToString();
        return vr;
    }

    public static string DumpAsString3Dictionary2<T, T1>(string operation, Dictionary<T, List<T1>> grouped)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(operation);

        foreach (var item in grouped)
        {
            sb.AppendLine("1) " + item.Key.ToString());

            foreach (var v in item.Value)
            {
                sb.AppendLine(v.ToString());
            }
            sb.AppendLine();
        }

        var vr = sb.ToString();
        return vr;
    }
}
