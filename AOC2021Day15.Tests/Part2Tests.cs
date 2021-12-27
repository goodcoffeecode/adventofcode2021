using Xunit;

namespace AOC2021Day15.Tests;

public class Part2Tests
{
    [Fact]
    public void SimpleDataShouldReturnTheCorrectResult()
    {
        const int Expected = 100;

        var matrix = MatrixExpander.ExpandGrid(InputData.GetSimpleData());

        var cave = GetCave(matrix);

        var actual = cave.FindShortestPath();

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void SampleDataShouldReturnTheCorrectResult()
    {
        const int Expected = 315;

        var matrix = MatrixExpander.ExpandGrid(InputData.GetSampleData());

        var cave = GetCave(matrix);

        var actual = cave.FindShortestPath();

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void RealDataShouldReturnTheCorrectResult()
    {
        const int Expected = 2904;       // Apparently, 2918 is too high!

        var matrix = MatrixExpander.ExpandGrid(InputData.GetRealData());

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