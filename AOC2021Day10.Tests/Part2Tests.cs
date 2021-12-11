using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AOC2021Day10.Tests;

public class Part2Tests
{
    private readonly Dictionary<char, int> _scoringLookup = new();

    public Part2Tests()
    {
        _scoringLookup.Add(')', 1);
        _scoringLookup.Add(']', 2);
        _scoringLookup.Add('}', 3);
        _scoringLookup.Add('>', 4);
    }

    [Fact]
    public void SampleDataShouldGiveTheCorrectNumberOfIncompleteLines()
    {
        const int Expected = 5;

        var data = InputData.GetSampleData();

        var incompleteData = GetIncompleteLines(data);

        Assert.Equal(Expected, incompleteData.Count);
    }

    [Fact]
    public void SampleDataShouldGiveTheCorrectScore()
    {
        const int Expected = 288957;

        var actual = CalculateScore(InputData.GetSampleData());

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void RealDataShouldGiveTheCorrectScore()
    {
        const long Expected = 3539961434;

        var actual = CalculateScore(InputData.GetRealData());

        Assert.Equal(Expected, actual);
    }

    private long CalculateScore(IList<string> data)
    {
        var incompleteData = GetIncompleteLines(data);

        var scores = GetAllScores(incompleteData);

        return GetMiddleScore(scores);
    }

    private List<long> GetAllScores(IList<string> incompleteData)
    {
        var scores = new List<long>();

        foreach (var line in incompleteData)
        {
            scores.Add(ScoreCompletionCharacters(LineChecker.GetMissingCharactersForIncompleteLine(line)));
        }

        return scores;
    }

    private long ScoreCompletionCharacters(IList<char> chars)
    {
        long score = 0;

        foreach (var c in chars)
        {
            score *= 5;
            score += _scoringLookup[c];
        }

        return score;
    }

    private static long GetMiddleScore(IList<long> scores)
    {
        var midPoint = (scores.Count - 1) / 2;

        return scores.OrderBy(s => s).ToArray()[midPoint];
    }

    private static List<string> GetIncompleteLines(IList<string> data)
    {
        var incompleteData = new List<string>();

        foreach (var line in data)
        {
            if (LineChecker.GetFirstCorruptCharacter(line) == null)
            {
                incompleteData.Add(line);
            }
        }

        return incompleteData;
    }
}
