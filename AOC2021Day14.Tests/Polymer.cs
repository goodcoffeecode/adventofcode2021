using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021Day14.Tests;

internal class Polymer
{
    internal string Value { get; private set; }

    private readonly Dictionary<string, char> _rules;

    internal Polymer(string value, Dictionary<string, char> rules)
    {
        Value = value;
        _rules = rules;
    }

    internal void Step()
    {
        var pairs = DecomposeIntoPairs();

        for (var i = 0; i < pairs.Count; i++)
        {
            if (_rules.TryGetValue(pairs[i], out var charToInsert))
            {
                if (i == pairs.Count - 1)
                {
                    pairs[i] = $"{pairs[i][0]}{charToInsert}{pairs[i][1]}";
                }
                else
                {
                    pairs[i] = $"{pairs[i][0]}{charToInsert}";
                }
            }
        }

        Value = Recompile(pairs);
    }

    internal Dictionary<string, long> FastStep(Dictionary<string, long> currPairs, Dictionary<char, long> elementCounts)
    {
        var newPairs = new Dictionary<string, long>();

        foreach (var pair in currPairs)
        {
            var newElem = _rules[pair.Key];
            elementCounts[newElem] = elementCounts.ContainsKey(newElem) ?
                elementCounts[newElem] + pair.Value :
                pair.Value;

            // Create the two pairs and put them in the resulting dictionary with the new values
            var pair1 = $"{pair.Key[0]}{_rules[pair.Key]}";
            var pair2 = $"{_rules[pair.Key]}{pair.Key[1]}";
            newPairs[pair1] = newPairs.ContainsKey(pair1) ? newPairs[pair1] + pair.Value : pair.Value;
            newPairs[pair2] = newPairs.ContainsKey(pair2) ? newPairs[pair2] + pair.Value : pair.Value;
        }

        return newPairs;
    }

    internal List<string> DecomposeIntoPairs()
    {
        var pairs = new List<string>();

        for (var i = 0; i < Value.Length - 1; i++)
        {
            pairs.Add(Value.Substring(i, 2));
        }

        return pairs;
    }

    private static string Recompile(IList<string> decomposition)
    {
        var sb = new StringBuilder();

        foreach (var d in decomposition)
        {
            sb.Append(d);
        }

        return sb.ToString();
    }

    internal Tuple<char, long> GetMostCommonElement()
    {
        var uniques = Value.Distinct();

        var c = '.';
        long max = 0;

        foreach (var unique in uniques)
        {
            var count = Value.LongCount(p => p == unique);

            if (count > max)
            {
                c = unique;
                max = count;
            }
        }

        return new Tuple<char, long>(c, max);
    }

    internal Tuple<char, long> GetLeastCommonElement()
    {
        var uniques = Value.Distinct();

        var c = '.';
        long min = Int64.MaxValue;

        foreach (var unique in uniques)
        {
            var count = Value.LongCount(p => p == unique);

            if (count < min)
            {
                c = unique;
                min = count;
            }
        }

        return new Tuple<char, long>(c, min);
    }
}