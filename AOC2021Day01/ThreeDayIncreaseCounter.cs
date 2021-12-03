namespace AOC2021Day01;

internal class ThreeDayIncreaseCounter
{
    //Note: I could also have done this by either extending SingleDayIncreaseCounter, or Decorating it.
    // Injecting it seemed cleaner though.

    private readonly SingleDayIncreaseCounter _counter;

    public ThreeDayIncreaseCounter(SingleDayIncreaseCounter counter)
    {
        ArgumentNullException.ThrowIfNull(counter);

        _counter = counter;
    }

    internal int Count(IList<int> inputData)
    {
        var reduction = ReduceBasedOnRollingThreeDays(inputData);

        return _counter.Count(reduction);
    }

    private static List<int> ReduceBasedOnRollingThreeDays(IList<int> inputData)
    {
        var reduction = new List<int>();

        for (int i = 0; i < inputData.Count - 2; i++)
        {
            reduction.Add(inputData[i] + inputData[i + 1] + inputData[i + 2]);
        }

        return reduction;
    }
}