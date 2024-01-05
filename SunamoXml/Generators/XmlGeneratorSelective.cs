namespace SunamoXml.Generators;

public class XmlGeneratorSelective : XmlGenerator
{
    /// <summary>
    /// A1 nemůže být null, musí to být v nejhorším případě Array.Empty
    /// </summary>
    /// <param name="p"></param>
    /// <param name="vynechat"></param>
    /// <param name="p_2"></param>
    public void WriteTagWithAttrsSelective(string p, List<string> vynechat, List<string> p_2)
    {
        sb.AppendFormat("<{0} ", p);
        for (int i = 0; i < p_2.Count / 2; i++)
        {
            string nameAtt = p_2[i * 2];
            if (!vynechat.Contains(nameAtt))
            {
                sb.AppendFormat("{0}=\"{1}\"", nameAtt, p_2[i * 2 + 1]);
            }
        }
        sb.Append(AllStringsSE.gt);
    }

    public override string ToString()
    {
        return sb.ToString();
    }
}
