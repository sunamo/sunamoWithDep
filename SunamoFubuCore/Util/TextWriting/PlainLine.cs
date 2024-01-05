namespace SunamoFubuCore.Util.TextWriting;

public class PlainLine : Line
{
    private readonly string _text;

    public PlainLine(string text)
    {
        _text = text;
    }

    public void WriteToConsole()
    {
        Write(CL.Out);
    }

    public void Write(TextWriter writer)
    {
        writer.WriteLine(_text);
    }

    public int Width => _text.Length;
}
