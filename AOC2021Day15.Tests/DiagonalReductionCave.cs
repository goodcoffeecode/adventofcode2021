using AOC2021Common;
using System.Text;
using static AOC2021Common.MatrixUtils;

namespace AOC2021Day15.Tests;

/// <summary>
/// This approach only works if the solution ONLY have DOWN and RIGHT movements.
/// If the optimal solution requires UPs or LEFTs, this will not find it.
/// </summary>
internal class DiagonalReductionCave : Cave
{
    private readonly int[,] _riskLevels;
    private readonly int _rowCount;
    private readonly int _colCount;

    internal DiagonalReductionCave(int[,] riskLevels)
        : base(riskLevels)
    {
        _riskLevels = riskLevels;

        _rowCount = _riskLevels.GetRowCount();
        _colCount = _riskLevels.GetColCount();
    }

    private void OutputMatrix(int currentRow, int currentCol)
    {
        Console.WriteLine($"Row: {currentRow}. Col: {currentCol}");

        for (var row = 0; row < _rowCount; row++)
        {
            var sb = new StringBuilder("\t");

            for (var col = 0; col < _colCount; col++)
            {
                sb.Append($"{_riskLevels[row, col]}\t");
            }

            Console.WriteLine(sb.ToString());
        }

        Console.WriteLine("");
    }

    internal override int FindShortestPath()
    {
        // Start from the bottom right and work left, then up...
        for (var root = _colCount - 1; root >= (_colCount * -1); root--)
        {
            var col = root;
            for (var row = _rowCount - 1; row >= 0; row--)
            {
                IncreaseCellValue(row, col);

                col++;
            }
        }

        return Math.Min(_riskLevels[0, 1], _riskLevels[1, 0]);
    }

    private bool IncreaseCellValue(int row, int col)
    {
        if (col < 0 || row < 0 || col >= _colCount || row >= _rowCount)
        {
            return false;
        }

        var p = PointFactory.Create(row, col, _riskLevels[row, col]);

        var right = _riskLevels.GetRight(p);
        var below = _riskLevels.GetBelow(p);

        if (right == null && below == null)
        {
            // Bottom right cell
            return false;
        }

        int inc;

        if (right == null)
        {
            inc = below.Value.Value;
        }
        else if (below == null)
        {
            inc = right.Value.Value;
        }
        else
        {
            inc = Math.Min(right.Value.Value, below.Value.Value);
        }

        _riskLevels[row, col] += inc;

        return true;
    }
}