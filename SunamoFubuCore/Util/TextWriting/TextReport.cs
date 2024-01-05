namespace SunamoFubuCore.Util.TextWriting;



public class TextReport
{
    private readonly Stack<ColumnSet> _columnSets = new Stack<ColumnSet>();
    private readonly IList<DividerLine> _dividers = new List<DividerLine>();
    private readonly IList<Line> _lines = new List<Line>();

    public void AddDivider(char character)
    {
        var line = new DividerLine(character);
        _lines.Add(line);
        _dividers.Add(line);
    }

    public void StartColumns(int count)
    {
        _columnSets.Push(new ColumnSet(count));
    }

    public void EndColumns()
    {
        _columnSets.Pop();
    }

    public void StartColumns(params IColumn[] columns)
    {
        _columnSets.Push(new ColumnSet(columns));
    }

    public void AddColumnData(params string[] contents)
    {
        var line = _columnSets.Peek().Add(contents);
        _lines.Add(line);
    }

    public void AddText(string text)
    {
        var line = new PlainLine(text);
        _lines.Add(line);
    }

    public void Write(TextWriter writer)
    {
        var maxWidth = _lines.Max(x => x.Width);
        Write(writer, maxWidth);
    }

    public void Write(TextWriter writer, int maxWidth)
    {
        _dividers.Each(x => x.Width = maxWidth);
        writer.WriteLine();
        _lines.Each(x => x.Write(writer));
    }

    public void WriteToConsole()
    {
        Write(CL.Out, ConsoleWriter.ConsoleBufferWidth);
    }
}
