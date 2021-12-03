namespace AOC2021Day01;

internal class SingleDayIncreaseCounter
{
    internal int Count(IList<int> inputs)
    {
        var countOfIncreases = 0;

        for (int i = 1; i < inputs.Count; i++)
        {
            if (inputs[i] > inputs[i - 1])
            {
                countOfIncreases++;
            }
        }

        return countOfIncreases;
    }
}