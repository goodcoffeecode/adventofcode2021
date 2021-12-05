using AOC2021Common;

namespace AOC2021Day04;

internal class Runner
{
    private readonly BingoGame _game;
    private readonly IStringYieldingReader _stringYieldingReader;

    public Runner(BingoGame game, IStringYieldingReader stringYieldingReader)
    {
        ArgumentNullException.ThrowIfNull(game);
        ArgumentNullException.ThrowIfNull(stringYieldingReader);

        _game = game;
        _stringYieldingReader = stringYieldingReader;
    }

    internal async Task RunAsync()
    {
        const char Sep = ' ';
        var gotDrawNumbers = false;
        int[] drawNumbers = null;

        var boardLines = new List<string>();

        await foreach (var line in _stringYieldingReader.YieldStringsAsync())
        {
            if (!gotDrawNumbers)
            {
                drawNumbers = line.Split(',').Select(n => int.Parse(n)).ToArray();
                gotDrawNumbers = true;
                continue;
            }

            if (!string.IsNullOrEmpty(line))
            {
                boardLines.Add(line);
            }
            else if (boardLines.Any())
            {
                _game.AddBoard(boardLines.ParseAndConvertToJaggedIntArray(Sep));

                boardLines = new List<string>();
            }                       
        }

        // Finally, we might have reached the end of the file with board data left in the "buffer"...
        if (boardLines.Any())
        {
            _game.AddBoard(boardLines.ParseAndConvertToJaggedIntArray(Sep));
        }

        foreach (var winner in _game.PlayContinuosly(drawNumbers))
        {
            Console.WriteLine(winner);
        }
    }
}
