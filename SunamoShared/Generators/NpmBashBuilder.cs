namespace SunamoShared.Generators;



public class NpmBashBuilder : INpmBashBuilder
{
    public TextBuilder sb = null;

    public NpmBashBuilder()
    {
        sb = new TextBuilder();
        sb.prependEveryNoWhite = AllStringsSE.space;
    }

    public NpmBashBuilder(TextBuilder sb)
    {
        this.sb = sb;
        //this.sb.sb = sb.sb;
    }

    void Npm(string remainCommand)
    {
        sb.Append("npm " + remainCommand);
        sb.AppendLine();
    }

    public void I(string args = null)
    {
        Npm("i " + args);

    }
}
