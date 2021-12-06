using AOC2021Common;

namespace AOC2021Day05;

internal class Runner
{
    private readonly IStringYieldingReader _stringYieldingReader;
    private readonly Grid _grid;

    public Runner(IStringYieldingReader stringYieldingReader, Grid grid)
    {
        ArgumentNullException.ThrowIfNull(stringYieldingReader);
        ArgumentNullException.ThrowIfNull(grid);

        _stringYieldingReader = stringYieldingReader;
        _grid = grid;
    }

    internal async Task RunAsync()
    {
        await foreach (var s in _stringYieldingReader.YieldStringsAsync())
        {
            var line = Parse(s);

            if (line.IsVerticalOrHorizontal() || line.HasAGradientOfOneOrMinusOne())
            {
                _grid.AddLine(line);
            }
        }

        const int HitThreshold = 2;

        Console.WriteLine($"There are {_grid.CountNumberOfPointsWithAtleastThisNumberOfHits(HitThreshold)} grids we should avoid!");
    }

    private static Line Parse(string s)
    {
        // e.g. 348,742 -> 620,742

        var split = s.Split(' ');

        var startSplit = split[0].Split(',');
        var endSplit = split[2].Split(',');

        var start = new Coordinate(int.Parse(startSplit[0]), int.Parse(startSplit[1]));
        var end = new Coordinate(int.Parse(endSplit[0]), int.Parse(endSplit[1]));

        return new Line(start, end);
    }
}