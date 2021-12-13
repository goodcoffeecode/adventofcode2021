using System.Collections.Generic;
using static AOC2021Common.MatrixUtils;

namespace AOC2021Day09.Tests;

public static class IntMatrixExtensions
{
    public static List<Point> FindLocalMinima(this int[,] matrix)
    {
        var localMinima = new List<Point>();

        for (int col = 0; col < matrix.GetColCount(); col++)
        {
            for (int row = 0; row < matrix.GetRowCount(); row++)
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
                if (row < matrix.GetRowCount() - 1)
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
                if (col < matrix.GetColCount() - 1)
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