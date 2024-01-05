namespace SunamoData.Data;

public class ConventionParseResult<T, U, Z>
{
    public Dictionary<T, Dictionary<U, List<Z>>> success = new Dictionary<T, Dictionary<U, List<Z>>>();
    public List<Z> fail = new List<Z>();
}
