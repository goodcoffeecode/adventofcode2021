using AOC2021Common;
using Xunit;

namespace AOC2021Day11.Tests;

public partial class Part1Tests
{

    [Fact]
    public void SimpleDataShouldGiveCorrectResult()
    {
        const int Expected = 9;
        const int TotalDays = 3;

        var data = InputData.GetSimpleData();

        int[,] matrix = MatrixUtils.ConvertToMatrix(data);

        var actual = 0;

        var octopusField = new OctopusField(matrix);

        for (int i = 0; i < TotalDays; i++)
        {
            actual += octopusField.Tick();
        }

        Assert.Equal(Expected, actual);
    }


    [Fact]
    public void SampleDataShouldGiveCorrectResult()
    {
        const int Expected = 1656;
        const int TotalDays = 100;

        var data = InputData.GetSampleData();

        int[,] matrix = MatrixUtils.ConvertToMatrix(data);

        var actual = 0;

        var octopusField = new OctopusField(matrix);

        for (int i = 0; i < TotalDays; i++)
        {
            actual += octopusField.Tick();
        }

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void RealDataShouldGiveCorrectResult()
    {
        const int Expected = 1667;
        const int TotalDays = 100;

        var data = InputData.GetRealData();

        int[,] matrix = MatrixUtils.ConvertToMatrix(data);

        var actual = 0;

        var octopusField = new OctopusField(matrix);

        for (int i = 0; i < TotalDays; i++)
        {
            actual += octopusField.Tick();
        }

        Assert.Equal(Expected, actual);
    }
}