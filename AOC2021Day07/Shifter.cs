namespace AOC2021Day07;

internal static class Shifter
{
    internal static int ShiftDataLinearlyTo(int[] data, int pos)
    {
        var fuel = 0;

        for (int d = 0; d < data.Length; d++)
        {
            fuel += Math.Abs(data[d] - pos);
        }

        return fuel;
    }

    internal static int ShiftDataIncreasinglyTo(int[] data, int pos)
    {
        var fuel = 0;

        for (int d = 0; d < data.Length; d++)
        {
            fuel += Math.Abs(data[d] - pos).SumOf();
        }

        return fuel;
    }
}