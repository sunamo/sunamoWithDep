namespace SunamoRandom;


public static partial class RandomHelper
{
    /// <summary>
    /// It is very random. The seed is always different because the seed is also random generated.
    /// </summary>
    private static Random s_rnd = new Random(Guid.NewGuid().GetHashCode());
}
