using AOC2021Common;

namespace AOC2021Day03;

internal class Runner
{
    private readonly IJaggedBitArrayReader _reader;
    private readonly Part1Calculator _part1Calculator;
    private readonly Part2Calculator _part2Calculator;

    public Runner(IJaggedBitArrayReader reader,Part1Calculator part1Calculator, Part2Calculator part2Calculator)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(part1Calculator);
        ArgumentNullException.ThrowIfNull(part2Calculator);

        _reader = reader;
        _part1Calculator = part1Calculator;
        _part2Calculator = part2Calculator;
    }

    internal async Task RunAsync()
    {
        var data = await _reader.ReadAsJaggedBitArrayAsync();

        var output1 = _part1Calculator.Calculate(data);
        var output2 = _part2Calculator.Calculate(data);

        Console.WriteLine("Day 03 Part 1...");
        Console.WriteLine($"\t{output1}");
        Console.WriteLine("Day 03 Part 2...");
        Console.WriteLine($"\t{output2}");
    }
}