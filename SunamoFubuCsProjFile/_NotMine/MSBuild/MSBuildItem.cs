namespace SunamoFubuCsProjFile._NotMine.MSBuild;

public class MSBuildItem : MSBuildObject
{
    public MSBuildItem(XmlElement elem)
        : base(elem)
    {
    }

    public string Include
    {
        get => Element.GetAttribute(ItemGroupAttrsConsts.Include);
        set => Element.SetAttribute(ItemGroupAttrsConsts.Include, value);
    }

    public string Name => Element.Name;

    public bool HasMetadata(string name)
    {
        return Element[name, MSBuildProject.Schema] != null;
    }

    public void SetMetadata(string name, string value)
    {
        SetMetadata(name, value, true);
    }

    public void SetMetadata(string name, string value, bool isLiteral)
    {
        var elem = Element[name, MSBuildProject.Schema];
        if (elem == null)
        {
            elem = AddChildElement(name);
            Element.AppendChild(elem);
        }

        elem.InnerXml = value;
    }

    public void UnsetMetadata(string name)
    {
        var elem = Element[name, MSBuildProject.Schema];
        if (elem != null)
        {
            Element.RemoveChild(elem);
            if (!Element.HasChildNodes)
                Element.IsEmpty = true;
        }
    }

    public string GetMetadata(string name)
    {
        var elem = Element[name, MSBuildProject.Schema];
        if (elem != null)
            return elem.InnerXml;
        return null;
    }

    public bool GetMetadataIsFalse(string name)
    {
        return string.Compare(GetMetadata(name), "False", StringComparison.OrdinalIgnoreCase) == 0;
    }

    public void MergeFrom(MSBuildItem other)
    {
        foreach (XmlNode node in Element.ChildNodes)
            if (node is XmlElement)
                SetMetadata(node.LocalName, node.InnerXml);
    }

    public void Remove()
    {
        if (Element.ParentNode != null)
        {
            if (Element.ParentNode.ChildNodes.Count == 1 &&
                Element.ParentNode.ParentNode != null) // last element in node
                Element.ParentNode.ParentNode.RemoveChild(Element.ParentNode);
            else
                Element.ParentNode.RemoveChild(Element);
        }
    }
}
