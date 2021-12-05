using AOC2021Common;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AOC2021Day04.Tests;

public class BingoGameFacts
{
    private const char Sep = ' ';

    [Fact]
    public void ExampleDataShouldFindTheCorrectFirstWinningBoard()
    {
        const int ExpectedWinningBoardIndex = 2;
        const int ExpectedWinningScore = 4512;

        var game = new BingoGame();

        var gameData = GetGameData();

        foreach (var boardData in gameData)
        {
            var intData = boardData.ParseAndConvertToJaggedIntArray(Sep);

            game.AddBoard(intData);
        }

        var drawNumbers = GetDrawNumbers();

        var winningBoard = game.PlayToWin(drawNumbers.ToArray());

        Assert.NotNull(winningBoard);
        Assert.Equal(ExpectedWinningBoardIndex, winningBoard.Index);
        Assert.Equal(ExpectedWinningScore, winningBoard.CalculateScore());
    }

    [Fact]
    public void ExmapleDataShouldFindTheCorrectLastWinningBoard()
    {
        const int ExpectedWinningBoardIndex = 1;
        const int ExpectedWinningScore = 1924;

        var game = new BingoGame();

        var gameData = GetGameData();

        foreach (var boardData in gameData)
        {
            var intData = boardData.ParseAndConvertToJaggedIntArray(Sep);

            game.AddBoard(intData);
        }

        var drawNumbers = GetDrawNumbers();

        BingoBoard latestWinningBoard = null;

        foreach (var winningBoard in game.PlayContinuosly(drawNumbers.ToArray()))
        {
            latestWinningBoard = winningBoard;
        }

        Assert.NotNull(latestWinningBoard);
        Assert.Equal(ExpectedWinningBoardIndex, latestWinningBoard.Index);
        Assert.Equal(ExpectedWinningScore, latestWinningBoard.CalculateScore());
    }

    private static IList<IList<string>> GetGameData()
    {
        var board1 = new string[]
        {
                "22 13 17 11  0",
                 "8  2 23  4 24",
                "21  9 14 16  7",
                "6 10  3 18  5",
                "1 12 20 15 19"
        };

        var board2 = new string[]
        {
                "3 15  0  2 22",
                "9 18 13 17  5",
                "19  8  7 25 23",
                "20 11 10 24  4",
                "14 21 16 12  6"
        };

        var board3 = new string[]
        {
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                "2  0 12  3  7"
         };

        return new List<IList<string>>()
            {
                board1,
                board2,
                board3
            };
    }

    private static IList<int> GetDrawNumbers()
    {
        const string numbersString = "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1";

        return numbersString.Split(',').Select(n => int.Parse(n)).ToList();
    }
}
