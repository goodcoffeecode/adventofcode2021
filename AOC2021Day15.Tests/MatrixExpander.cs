using AOC2021Common;

namespace AOC2021Day15.Tests;

internal static class MatrixExpander
{
    internal static int[,] ExpandGrid(int[,] originalGrid, int times = 5)
    {
        var height = originalGrid.GetRowCount();
        var width = originalGrid.GetColCount();

        var grid = new int[height * times, width * times];

        grid.Fill(originalGrid, 0, 0);

        for (var row = 0; row < grid.GetRowCount(); row++)
        {
            for (var col = 0; col < grid.GetColCount(); col++)
            {
                if (grid[row, col] == 0)
                {
                    if (col - width >= 0)
                    {
                        grid[row, col] = Increment(grid[row, col - width]);
                    }
                    else
                    {
                        grid[row, col] = Increment(grid[row - height, col]);
                    }
                }
            }
        }

        return grid;
    }

    private static int Increment(int val) => val >= 9 ? 1 : val + 1;
}