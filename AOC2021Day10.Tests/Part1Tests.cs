using System.Collections.Generic;
using Xunit;

namespace AOC2021Day10.Tests;

public class Part1Tests
{
    private readonly Dictionary<char, int> _scores = new();

    public Part1Tests()
    {
        _scores.Add(')', 3);
        _scores.Add(']', 57);
        _scores.Add('}', 1197);
        _scores.Add('>', 25137);
    }

    [Fact]
    public void SampleDataShouldGiveTheCorrectResult()
    {
        const int Expected = 26397;

        var data = InputData.GetSampleData();

        var corruptCharacters = GetAllCorruptCharacters(data);

        var score = GetScore(corruptCharacters);

        Assert.Equal(Expected, score);
    }

    [Fact]
    public void RealDataShouldGiveTheCorrectResult()
    {
        const int Expected = 388713;

        var data = InputData.GetRealData();

        var corruptCharacters = GetAllCorruptCharacters(data);

        var score = GetScore(corruptCharacters);

        Assert.Equal(Expected, score);
    }

    private List<char> GetAllCorruptCharacters(IList<string> data)
    {
        var corruptCharacters = new List<char>();

        foreach (var line in data)
        {
            var c = LineChecker.GetFirstCorruptCharacter(line);

            if (c != null)
            {
                corruptCharacters.Add(c.Value);
            }
        }

        return corruptCharacters;
    }

    private int GetScore(IList<char> corruptCharacters)
    {
        var score = 0;

        foreach (var c in corruptCharacters)
        {
            score += _scores[c];
        }

        return score;
    }
}
