namespace SunamoColors;

public class SunamoColor
{


    public byte A { get; set; }
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public SunamoColor()
    {

    }

    public SunamoColor(byte a, byte r, byte g, byte b)
    {
        A = a;
        R = r;
        G = g;
        B = b;
    }

    public override string ToString()
    {
        // System.Windows.Media.Color = #00000000
        // System.Drawing.Color = Color [A=0, R=0, G=0, B=0]

        //
        throw new Exception("StringHexColorConverter jsem musel přesunout protože je na wf a můžu jen wpf");
        //return StringHexColorConverter.ConvertTo(this);
    }
}
