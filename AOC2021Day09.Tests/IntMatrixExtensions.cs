using System.Collections.Generic;

namespace AOC2021Day09.Tests;

public static class IntMatrixExtensions
{
    public static List<Point> FindLocalMinima(this int[,] matrix)
    {
        var localMinima = new List<Point>();

        for (int col = 0; col < matrix.ColCount(); col++)
        {
            for (int row = 0; row < matrix.RowCount(); row++)
            {
                // Are any of my neighbours bigger than me?
                var me = matrix[row, col];

                var isIt = true;

                // Up
                if (row > 0)
                {
                    if (matrix[row - 1, col] <= me)
                    {
                        isIt = false;
                    }
                }
                // Down
                if (row < matrix.RowCount() - 1)
                {
                    if (matrix[row + 1, col] <= me)
                    {
                        isIt = false;
                    }
                }
                // Left
                if (col > 0)
                {
                    if (matrix[row, col - 1] <= me)
                    {
                        isIt = false;
                    }
                }
                // Right
                if (col < matrix.ColCount() - 1)
                {
                    if (matrix[row, col + 1] <= me)
                    {
                        isIt = false;
                    }
                }

                if (isIt)
                {
                    localMinima.Add(new Point(row, col, me));
                }
            }
        }

        return localMinima;
    }
}