using System.Text;

namespace AOC2021Day03;

public static class BitListExtensions
{
    public static string ConvertToString(this IList<bool> data)
    {
        var sb = new StringBuilder();

        foreach (var bit in data)
        {
            sb.Append(bit ? '1' : '0');
        }

        return sb.ToString();
    }

    public static int ConvertToInt32(this IList<bool> data)
    {
        var powersOfTwo = GeneratePowersOfTwoBitArray(data.Count);

        var ret = 0;

        for (var i = 0; i < data.Count; i++)
        {
            ret += data[i] ? powersOfTwo[i] : 0;
        }

        return ret;
    }

    private static int[] GeneratePowersOfTwoBitArray(int length)
    {
        var current = 1;
        var ret = new int[length];

        for (int i = length - 1; i >= 0; i--)
        {
            ret[i] = current;

            current *= 2;
        }

        return ret;
    }
}