using System.Collections.Generic;
using Xunit;

namespace AOC2021Day05.Tests;

public class GridFacts
{
    [Fact]
    public void ShouldCorrectlyAnswerExampleDataPart1()
    {
        const int ExpectedCount = 5;
        const int HitThreshold = 2;

        var lines = GetExampleData();

        var grid = new Grid();

        foreach (var line in lines)
        {
            if (line.IsVerticalOrHorizontal())
            {
                grid.AddLine(line);
            }
        }

        Assert.Equal(ExpectedCount, grid.CountNumberOfPointsWithAtleastThisNumberOfHits(HitThreshold));
    }

    [Fact]
    public void ShouldCorrectlyAnswerExampleDataPart2()
    {
        const int ExpectedCount = 12;
        const int HitThreshold = 2;

        var lines = GetExampleData();

        var grid = new Grid();

        foreach (var line in lines)
        {
            if (line.IsVerticalOrHorizontal() || line.HasAGradientOfOneOrMinusOne())
            {
                grid.AddLine(line);
            }
        }

        Assert.Equal(ExpectedCount, grid.CountNumberOfPointsWithAtleastThisNumberOfHits(HitThreshold));
    }

    private static IList<Line> GetExampleData()
    {
        // 0,9-> 5,9
        // 8,0-> 0,8
        // 9,4-> 3,4
        // 2,2-> 2,1
        // 7,0-> 7,4
        // 6,4-> 2,0
        // 0,9-> 2,9
        // 3,4-> 1,4
        // 0,0-> 8,8
        // 5,5-> 8,2

        return new Line[]
        {
                BuildLine(0, 9, 5, 9),
                BuildLine(8,0,0,8),
                BuildLine(9,4,3,4),
                BuildLine(2,2,2,1),
                BuildLine(7,0,7,4),
                BuildLine(6,4,2,0),
                BuildLine( 0,9,2,9),
                BuildLine(3,4,1,4),
                BuildLine(0,0,8,8),
                BuildLine(5,5,8,2)
        };
    }

    private static Line BuildLine(int startX, int startY, int endX, int endY)
    {
        return new Line(new Coordinate(startX, startY), new Coordinate(endX, endY));
    }
}