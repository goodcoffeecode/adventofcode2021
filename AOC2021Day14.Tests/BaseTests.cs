using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2021Day14.Tests;

public abstract class BaseTests
{
    protected abstract int Iterations { get; }

    protected long Process(Tuple<string, Dictionary<string, char>> data)
    {
        var polymer = new Polymer(data.Item1, data.Item2);

        for (var i = 0; i < Iterations; i++)
        {
            polymer.Step();
        }

        var mostCommon = polymer.GetMostCommonElement();
        var leastCommon = polymer.GetLeastCommonElement();

        return mostCommon.Item2 - leastCommon.Item2;
    }

    protected long FastProcess(Tuple<string, Dictionary<string, char>> data)
    {
        var polymer = new Polymer(data.Item1, data.Item2);

        var pairs = new Dictionary<string, long>();
        var elementCounts = new Dictionary<char, long>();

        for (var i = 1; i < data.Item1.Length; i++)
        {
            var pair = $"{data.Item1[i - 1]}{data.Item1[i]}";
            pairs[pair] = pairs.ContainsKey(pair) ? pairs[pair] + 1 : 1;
        }

        foreach (var elem in data.Item1)
        {
            elementCounts[elem] = elementCounts.ContainsKey(elem) ? elementCounts[elem] + 1 : 1;
        }

        for (var i = 0; i < Iterations; i++)
        {
            pairs = polymer.FastStep(pairs, elementCounts);
        }

        var most = elementCounts.Values.Max();
        var least = elementCounts.Values.Min();

        return most - least;
    }
}