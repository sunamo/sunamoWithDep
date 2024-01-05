namespace SunamoInterfaces.Interfaces;

public interface IXmlParser
{
    void Parse(System.Xml.XmlNode node);

    string ToXml();
}
