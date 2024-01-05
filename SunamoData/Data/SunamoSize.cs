namespace SunamoData.Data;

public class SunamoSize //: IParser
{
    public double Width { get; set; }
    public double Height { get; set; }

    public SunamoSize()
    {
    }

    public SunamoSize(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public bool IsNegativeOrZero()
    {
        bool w = Width <= 0;
        bool h = Height <= 0;
        return w || h;
    }

    public void Parse(string input)
    {
        var d = ParserTwoValues.ParseDouble(AllStringsSE.comma, SH.RemoveAfterFirstFunc(input, char.IsLetter, new char[] { AllCharsSE.comma }));
        Width = d[0];

        Height = d[1];
    }

    public override string ToString()
    {
        return ParserTwoValues.ToString(AllStringsSE.comma, Width.ToString(), Height.ToString());
    }
}
