using Xunit;

namespace AOC2021Day15.Tests;

public class Part1Tests
{
    [Fact]
    public void SimpleDataShouldReturnTheCorrectResult()
    {
        const int Expected = 7;

        var matrix = InputData.GetSimpleData();

        var cave = GetCave(matrix);

        var actual = cave.FindShortestPath();

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void LessSimpleDataShouldReturnTheCorrectResult()
    {
        const int Expected = 6;

        var matrix = InputData.GetLessSimpleData();

        var cave = GetCave(matrix);

        var actual = cave.FindShortestPath();

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void SampleDataShouldReturnTheCorrectResult()
    {
        const int Expected = 40;

        var matrix = InputData.GetSampleData();

        var cave = GetCave(matrix);

        var actual = cave.FindShortestPath();

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void RealDataShouldReturnTheCorrectResult()
    {
        const int Expected = 621;       // AoC insists the answer is 621, though!?

        var matrix = InputData.GetRealData();

        var cave = GetCave(matrix);

        var actual = cave.FindShortestPath();

        Assert.Equal(Expected, actual);
    }

    private static Cave GetCave(int[,] matrix)
    {
        //return new DiagonalCave(matrix);
        return new DijkstraCave(matrix);
    }
}