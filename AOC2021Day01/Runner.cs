using AOC2021Common;

namespace AOC2021Day01;

internal class Runner
{
    private readonly IInputDataReader _reader;
    private readonly SingleDayIncreaseCounter _singleDayIncreaseCounter;
    private readonly ThreeDayIncreaseCounter _threeDayIncreaseCounter;

    public Runner(IInputDataReader reader, SingleDayIncreaseCounter singleDayIncreaseCounter, ThreeDayIncreaseCounter threeDayIncreaseCounter)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(singleDayIncreaseCounter);
        ArgumentNullException.ThrowIfNull(threeDayIncreaseCounter);

        _reader = reader;
        _singleDayIncreaseCounter = singleDayIncreaseCounter;
        _threeDayIncreaseCounter = threeDayIncreaseCounter;
    }

    internal async Task RunAsync()
    {
        var inputData = await _reader.ReadAsInt32ListAsync();

        Console.WriteLine("Day 01 Part 1...");
        Console.WriteLine($"\tThere are {_singleDayIncreaseCounter.Count(inputData)} single day increases in depth.");
        Console.WriteLine("Day 01 Part 2...");
        Console.WriteLine($"\tThere are {_threeDayIncreaseCounter.Count(inputData)} three day increases in depth.");
    }
}
