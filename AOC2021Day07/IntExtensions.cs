namespace AOC2021Day07;

public static class IntExtensions
{
    /// <summary>
    /// Sums the first n numbers.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int SumOf(this int n) => (n * (n + 1)) / 2;
}