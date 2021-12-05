namespace AOC2021Day04;

internal class BingoGame
{
    private readonly IList<BingoBoard> _boards;

    public BingoGame()
    {
        _boards = new List<BingoBoard>();
    }

    internal void AddBoard(int[][] data)
    {
        var board = new BingoBoard(data, _boards.Count);

        _boards.Add(board);
    }

    private void RemoveBoard(BingoBoard? board)
    {
        if (board != null)
        {
            _boards.Remove(board);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="draws"></param>
    /// <returns>The winning board, or null if no winners.</returns>
    internal BingoBoard? PlayToWin(int[] draws)
    {
        for (int i = 0; i < draws.Length; i++)
        {
            CheckNumber(draws[i]);

            var winningBoard = GetWinningBoards();

            if (winningBoard.Any())
            {
                return winningBoard.First();
            }
        }

        return null;
    }

    internal IEnumerable<BingoBoard> PlayContinuosly(int[] draws)
    {
        for (int i = 0; i < draws.Length; i++)
        {
            CheckNumber(draws[i]);

            var winningBoards = GetWinningBoards();

            if (winningBoards.Any())
            {
                foreach (var winningBoard in winningBoards)
                {
                    yield return winningBoard;

                    RemoveBoard(winningBoard);
                }
            }
        }
    }

    internal void CheckNumber(int number)
    {
        foreach (var board in _boards)
        {
            board.CheckNumber(number);
        }
    }

    internal List<BingoBoard> GetWinningBoards()
    {
        return _boards.Where(b => b.IsWinningBoard()).ToList();
    }
}