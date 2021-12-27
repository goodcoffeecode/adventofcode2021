using AOC2021Common;
using System;
using System.Collections.Generic;
using Xunit;

namespace AOC2021Day11.Tests;

public class Part2Tests
{
    [Fact]
    public void SampleDataShouldGiveTheCorrectResult()
    {
        const int Expected = 195;
        const int MaxAttempts = 1000;

        var actual = GetFirstTimeAllOctopusesFlash(InputData.GetSampleData, MaxAttempts);

        Assert.Equal(Expected, actual + 1);
    }

    [Fact]
    public void RealDataShouldGiveTheCorrectResult()
    {
        const int Expected = 488;
        const int MaxAttempts = 1000;

        var actual = GetFirstTimeAllOctopusesFlash(InputData.GetRealData, MaxAttempts);

        Assert.Equal(Expected, actual + 1);
    }

    private static int GetFirstTimeAllOctopusesFlash(Func<List<string>> getData, int maxAttempts)
    {
        var data = getData();

        var matrix = MatrixUtils.ConvertToMatrix(data);

        var totalCells = matrix.GetRowCount() * matrix.GetColCount();

        var octopusField = new OctopusField(matrix);

        var actual = -1;

        for (int i = 0; i < maxAttempts; i++)
        {
            if (octopusField.Tick() == totalCells)
            {
                actual = i;
                break;
            }
        }

        return actual;
    }
}