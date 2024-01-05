namespace SunamoAttributes;

public class DataMemberAttribute : Attribute
{
    public string Name;

    public DataMemberAttribute(string Name)
    {
        this.Name = Name;
    }
}
