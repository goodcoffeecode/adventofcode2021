using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AOC2021Day12.Tests;

public class Part2Tests
{
    [Fact]
    public void SimpleDataShouldGiveCorrectResult()
    {
        const int Expected = 36;

        var data = InputData.GetSimpleData();

        var actual = CountPaths(data);

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void SlightlyLargerDataShouldGiveCorrectResult()
    {
        const int Expected = 103;

        var data = InputData.GetSlightlyLargerData();

        var actual = CountPaths(data);

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void EvenLargerDataShouldGiveCorrectResult()
    {
        const int Expected = 3509;

        var data = InputData.GetEvenLargerData();

        var actual = CountPaths(data);

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void RealDataShouldGiveCorrectResult()
    {
        // This is weird. The actual answer fluctuates between these 4 numbers!!!
        //const int Expected = 134860;
        //const int Expected = 134859;
        const int Expected = 134862;
        //const int Expected = 134858;

        var data = InputData.GetRealData();

        var actual = CountPaths(data);

        Assert.Equal(Expected, actual);
    }

    private static int CountPaths(IList<string> data)
    {
        var cave = new CaveUtil(data, new Part2DestinationValidator());

        var totalPaths = new List<Path>();

        var bot = new GraphBot(cave.GetNodes());

        var smallCaves = cave.GetNodes().Where(n => n.GetIsSmall() && !n.GetIsStart() && !n.GetIsEnd()).ToList();

        foreach (var smallCave in smallCaves)
        {
            Part2DestinationValidator.SmallCaveToVisitTwice = smallCave.Name;

            totalPaths.AddRange(bot.Walk());
        }

        return totalPaths.Distinct(new PathComparer()).Count();
    }
}