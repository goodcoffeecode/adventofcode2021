using System.Collections.Generic;
using Xunit;

namespace AOC2021Day12.Tests;

public class Part1Tests
{
    [Fact]
    public void SimpleDataShouldGiveCorrectResult()
    {
        const int Expected = 10;

        var data = InputData.GetSimpleData();

        var actual = CountPaths(data);

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void SlightlyLargerDataShouldGiveCorrectResult()
    {
        const int Expected = 19;

        var data = InputData.GetSlightlyLargerData();

        var actual = CountPaths(data);

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void EvenLargerDataShouldGiveCorrectResult()
    {
        const int Expected = 226;

        var data = InputData.GetEvenLargerData();

        var actual = CountPaths(data);

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void RealDataShouldGiveCorrectResult()
    {
        const int Expected = 5212;

        var data = InputData.GetRealData();

        var actual = CountPaths(data);

        Assert.Equal(Expected, actual);
    }

    protected static int CountPaths(IList<string> data)
    {
        var cave = new CaveUtil(data, new Part1DestinationValidator());

        var bot = new GraphBot(cave.GetNodes());

        return bot.Walk().Count;
    }
}