namespace AOC2021Day07;

internal class BruteForceSolver
{
    private readonly int[] _data;

    internal BruteForceSolver(int[] data)
    {
        ArgumentNullException.ThrowIfNull(data);

        _data = data;
    }

    internal record struct Result(int Position, int Fuel);

    internal Result SolveLinearly() => Solve(Shifter.ShiftDataLinearlyTo);

    internal Result SolveIncreasingly() => Solve(Shifter.ShiftDataIncreasinglyTo);

    private Result Solve(Func<int[],int,int> shifter)
    {
        var min = _data.Min();
        var max = _data.Max();

        var bestResult = new Result(-1, int.MaxValue);

        for (int pos = min; pos < max; pos++)
        {
            var fuel = shifter(_data, pos);

            if (fuel < bestResult.Fuel)
            {
                bestResult = new Result(pos, fuel);
            }
        }

        return bestResult;
    }
}