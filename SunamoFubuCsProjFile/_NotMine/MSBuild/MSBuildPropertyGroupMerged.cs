namespace SunamoFubuCsProjFile._NotMine.MSBuild;

public class MSBuildPropertyGroupMerged : MSBuildPropertySet
{
    private readonly List<MSBuildPropertyGroup> groups = new();

    public int GroupCount => groups.Count;

    public MSBuildProperty GetProperty(string name)
    {
        // Find property in reverse order, since the last set
        // value is the good one
        for (var n = groups.Count - 1; n >= 0; n--)
        {
            var g = groups[n];
            var p = g.GetProperty(name);
            if (p != null)
                return p;
        }

        return null;
    }

    public MSBuildProperty SetPropertyValue(string name, string value, bool preserveExistingCase)
    {
        var p = GetProperty(name);
        if (p != null)
        {
            if (!preserveExistingCase || !string.Equals(value, p.Value, StringComparison.OrdinalIgnoreCase))
                p.Value = value;
            return p;
        }

        return groups[0].SetPropertyValue(name, value, preserveExistingCase);
    }

    public string GetPropertyValue(string name)
    {
        var prop = GetProperty(name);
        return prop != null ? prop.Value : null;
    }

    public bool RemoveProperty(string name)
    {
        var found = false;
        foreach (var g in groups)
            if (g.RemoveProperty(name))
            {
                Prune(g);
                found = true;
            }

        return found;
    }

    public void RemoveAllProperties()
    {
        foreach (var g in groups)
        {
            g.RemoveAllProperties();
            Prune(g);
        }
    }

    public void UnMerge(MSBuildPropertySet baseGrp, ISet<string> propertiesToExclude)
    {
        foreach (var g in groups) g.UnMerge(baseGrp, propertiesToExclude);
    }

    public IEnumerable<MSBuildProperty> Properties
    {
        get
        {
            foreach (var g in groups)
                foreach (var p in g.Properties)
                    yield return p;
        }
    }

    public void Add(MSBuildPropertyGroup g)
    {
        groups.Add(g);
    }

    private void Prune(MSBuildPropertyGroup g)
    {
        if (g != groups[0] && !g.Properties.Any())
            // Remove this group since it's now empty
            g.Parent.RemoveGroup(g);
    }
}
