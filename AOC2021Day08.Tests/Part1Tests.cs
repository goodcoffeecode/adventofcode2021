using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AOC2021Day08.Tests;

public class Part1Tests
{
    [Fact]
    public void SampleDataShouldReturnTheCorrectResult()
    {
        const int Expected = 26;
        
        var actual = Solve(InputData.GetSampleData);

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void RealDataShouldReturnTheCorrectResult()
    {
        const int Expected = 261;

        var actual = Solve(InputData.GetRealData);

        Assert.Equal(Expected, actual);
    }

    private static int Solve(Func<IList<string>> getData)
    {
        var MatchLengths = new[] { 2, 3, 4, 7 };
        var actual = 0;

        foreach (var line in getData())
        {
            var numbers = ChopUpInputLine(line);

            foreach (var n in numbers)
            {
                if (MatchLengths.Contains(n.Length))
                {
                    actual++;
                }
            }
        }

        return actual;
    }

    private static string[] ChopUpInputLine(string line)
    {
        // We only need items after the |
        var split = line.Split('|');

        return split[1].Trim().Split(' ');
    }
}
