namespace SunamoFubuCsProjFile._NotMine.Templating.Runtime;



public class CopyFileToSolution : ITemplateStep
{
    private readonly string _relativePath;
    private readonly string _source;

    public CopyFileToSolution(string relativePath, string source)
    {
        _relativePath = relativePath.Replace("\\", "/");
        _source = source;
    }

    public
        void
        Alter(TemplatePlan plan)
    {
        var expectedFile = plan.Root.AppendPath(_relativePath);
        var contents =
                plan.FileSystem.ReadStringFromFile(_source)
#if ASYNC
                    .Result
#endif
            ;
        var transformedContents = plan.ApplySubstitutions(contents);

        plan.FileSystem.WriteStringToFile(expectedFile, transformedContents);
    }

    protected bool Equals(CopyFileToSolution other)
    {
        return string.Equals(_relativePath, other._relativePath) &&
               string.Equals(_source.CanonicalPath(), other._source.CanonicalPath());
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((CopyFileToSolution)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (_relativePath != null ? _relativePath.GetHashCode() : 0) * 397 ^
                   (_source != null ? _source.GetHashCode() : 0);
        }
    }

    public override string ToString()
    {
        return string.Format("Copy {1} to {0}", _relativePath, _source);
    }
}
