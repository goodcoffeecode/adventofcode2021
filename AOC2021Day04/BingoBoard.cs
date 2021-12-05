namespace AOC2021Day04;

internal class BingoBoard
{
    private readonly IList<BoardLine> _columns;
    private readonly IList<BoardLine> _rows;
    private int _lastNumberChecked = 0;

    /// <summary>
    /// Gets the zero-based index of this Board within the Game.
    /// </summary>
    public int Index { get; init; }

    internal BingoBoard(int[][] data, int index)
    {
        _columns = new List<BoardLine>();
        _rows = new List<BoardLine>();
        Index = index;

        for (int i = 0; i < data.Length; i++)
        {
            _rows.Add(new BoardLine(data[i]));
        }

        for (int i = 0; i < data[0].Length; i++)
        {
            var col = new List<int>();

            for (int j = 0; j < data.GetLength(0); j++)
            {
                col.Add(data[j][i]);
            }

            _columns.Add(new BoardLine(col.ToArray()));
        }
    }

    internal void CheckNumber(int number)
    {
        foreach (var col in _columns)
        {
            col.CheckNumber(number);
        }

        foreach (var row in _rows)
        {
            row.CheckNumber(number);
        }

        _lastNumberChecked = number;
    }

    internal bool IsWinningBoard()
    {
        if (_columns.Any(c => c.IsWinningLine()))
        {
            return true;
        }

        if (_rows.Any(c => c.IsWinningLine()))
        {
            return true;
        }

        return false;
    }

    internal int CalculateScore() => SumAllUnselectedNumbers() * _lastNumberChecked;

    internal int SumAllUnselectedNumbers() => _rows.Sum(r => r.SumAllUnselectedNumbers());

    public override string ToString() => $"# {Index} with a score of {CalculateScore()}.";
}