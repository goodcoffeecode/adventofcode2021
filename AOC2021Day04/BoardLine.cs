namespace AOC2021Day04;

/// <summary>
/// Class that can be used for both Columns and Rows.
/// </summary>
internal class BoardLine
{
    private readonly IList<BingoCell> _bingoCells;

    internal BoardLine(int[] numbers)
    {
        _bingoCells = new List<BingoCell>();

        foreach (var n in numbers)
        {
            _bingoCells.Add(new BingoCell(n));
        }
    }

    internal void CheckNumber(int number)
    {
        foreach (var cell in _bingoCells)
        {
            cell.CheckNumber(number);
        }
    }

    internal bool IsWinningLine()
    {
        var unselectedNumbers = _bingoCells.Where(c => !c.IsSelected);

        return !unselectedNumbers.Any();
    }

    internal int SumAllUnselectedNumbers() => _bingoCells.Where(c => !c.IsSelected).Sum(c => c.Number);
}