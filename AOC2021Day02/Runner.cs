using AOC2021Common;

namespace AOC2021Day02;

internal class Runner
{
    private readonly IStringListReader _inputReader;
    private readonly Part1Calculator _part1Calculator;
    private readonly Part2Calculator _part2Calculator;

    public Runner(IStringListReader inputReader, Part1Calculator part1Calculator, Part2Calculator part2Calculator)
    {
        ArgumentNullException.ThrowIfNull(inputReader);
        ArgumentNullException.ThrowIfNull(part1Calculator);
        ArgumentNullException.ThrowIfNull(part2Calculator);

        _inputReader = inputReader;
        _part1Calculator = part1Calculator;
        _part2Calculator = part2Calculator;
    }

    internal async Task RunAsync()
    {
        var inputs = await _inputReader.ReadAsStringListAsync();

        var output1 = _part1Calculator.Calculate(inputs);

        var output2 = _part2Calculator.Calculate(inputs);

        Console.WriteLine("Day 02 Part 2...");
        Console.WriteLine($"\t{output1}");
        Console.WriteLine("Day 02 Part 2...");
        Console.WriteLine($"\t{output2}");
    }
}