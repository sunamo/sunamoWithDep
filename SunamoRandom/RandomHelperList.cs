namespace SunamoRandom;




public class RandomHelperList
{
    public static List<int> GenerateNumbers(int length, int count)
    {
        List<int> result = new(count);

        for (int i = 0; i < count; i++)
        {
            result.Add(RandomHelper.RandomInt(NH.MinForLength(length), NH.MaxForLength(length)));
        }

        return result;
    }
}
