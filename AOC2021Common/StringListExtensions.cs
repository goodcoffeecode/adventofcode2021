namespace AOC2021Common;

public static class StringListExtensions
{
    public static int[][] ParseAndConvertToJaggedIntArray(this IList<string> stringArray, char sep)
    {
        var rows = stringArray.Count;

        var values = new int[rows][];

        for (int i = 0; i < stringArray.Count; i++)
        {
            var row = StripDoublesAndTrim(stringArray[i], sep);

            values[i] = row.Split(sep).Select(x => int.Parse(x)).ToArray();
        }

        return values;
    }

    private static string StripDoublesAndTrim(string s, char sep) => s.Trim().Replace($"{sep}{sep}", $"{sep}");
}