using AOC2021Common;
using System;
using System.Collections.Generic;
using System.Linq;
using static AOC2021Common.MatrixUtils;

namespace AOC2021Day11.Tests;

internal class OctopusField
{
    private readonly OctupusEqualityComparer _comparer = new();
    private readonly int[,] _matrix;

    private List<Point> _cellsThatFlashedThisCycle = new();

    internal OctopusField(int[,] matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix);

        _matrix = matrix;
    }

    internal int Tick()
    {
        var flashCount = 0;

        IncrementAllCells();

        _cellsThatFlashedThisCycle = new List<Point>();

        var cellsReadyToFlash = GetAllCellsAboveNine();

        while (cellsReadyToFlash.Any())
        {
            flashCount += Flash(cellsReadyToFlash);

            _cellsThatFlashedThisCycle.AddRange(cellsReadyToFlash);

            cellsReadyToFlash = GetAllCellsAboveNine();
        }

        ResetFlashedCells();

        return flashCount;
    }

    private void ResetFlashedCells()
    {
        foreach (var cell in _cellsThatFlashedThisCycle.Distinct(_comparer))
        {
            _matrix[cell.Row, cell.Col] = 0;
        }
    }

    private int Flash(IEnumerable<Point> cellsReadyToFlash)
    {
        var flashCount = 0;

        foreach (var cell in cellsReadyToFlash)
        {
            // Only do this if the cell hasn't already flashed...
            if (!_cellsThatFlashedThisCycle.Contains(cell, _comparer))
            {
                var surroundingPoints = _matrix.GetSurroundingPoints(cell);

                foreach (var point in surroundingPoints)
                {
                    _matrix[point.Row, point.Col]++;
                }

                _matrix[cell.Row, cell.Col] = 0;

                flashCount++;
            }
        }

        return flashCount;
    }

    private void IncrementAllCells()
    {
        for (var row = 0; row < _matrix.GetRowCount(); row++)
        {
            for (var col = 0; col < _matrix.GetColCount(); col++)
            {
                _matrix[row, col] = _matrix[row, col] + 1;
            }
        }
    }

    private List<Point> GetAllCellsAboveNine()
    {
        var cells = new List<Point>();

        for (var row = 0; row < _matrix.GetRowCount(); row++)
        {
            for (var col = 0; col < _matrix.GetColCount(); col++)
            {
                if (_matrix[row, col] > 9)
                {
                    cells.Add(new Point(row, col, _matrix[row, col]));
                }
            }
        }

        return cells;
    }
}
