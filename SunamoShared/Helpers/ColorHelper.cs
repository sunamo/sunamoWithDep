namespace SunamoShared.Helpers;




public partial class ColorHelper
{
    public static Color GetColorFromBytes(byte r, byte g, byte b)
    {
        //System.Drawing.Color c = new System.Drawing.Color();
        return Color.FromArgb(r, g, b);
    }

    public static string RandomColorHex(bool light)
    {
        throw new Exception("StringHexColorConverter not in net core");
        //int r = RandomHelper.RandomColorPart(light);
        //int g = RandomHelper.RandomColorPart(light);
        //int b = RandomHelper.RandomColorPart(light);
        //return StringHexColorConverter.ConvertToWoAlpha(r, g, b);
    }

    public static object FromRgb(byte current_R, byte current_G, byte current_B)
    {
        return Color.FromArgb(current_R, current_G, current_B);
    }

    public static bool IsColorSimilar(Color a, Color b, int threshold = 50)
    {
        int r = a.R - b.R;
        int g = a.G - b.G;
        int b2 = a.B - b.B;
        return r * r + g * g + b2 * b2 <= threshold * threshold;
    }

    public static bool IsColorSimilar(PixelColor a, PixelColor b, int threshold = 50)
    {
        int r = a.Red - b.Red;
        int g = a.Green - b.Green;
        int b2 = a.Blue - b.Blue;
        return r * r + g * g + b2 * b2 <= threshold * threshold;
    }

    public static bool IsColorSame(PixelColor first, PixelColor pxsi)
    {
        return first.Red == pxsi.Red && first.Green == pxsi.Green && first.Blue == pxsi.Blue;
    }


}
