using AOC2021Common;
using System;
using System.Linq;
using System.Text;

namespace AOC2021Day08.Tests;

internal class LineDecoder
{
    private static readonly char[] StandardChars = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };

    private readonly string _data;

    internal LineDecoder(string data)
    {
        _data = data;
    }

    internal int Decode()
    {
        char[] copiedChars = new char[StandardChars.Length];

        StandardChars.CopyTo(copiedChars, 0);

        int[] answer = null;

        var corf = WhatCouldCorFBe();
        var a = WhatIsA();

        // I could continue to reduce the number of addressable permutations, but it's good enough!
        foreach (var guess in copiedChars.GetPermutations()
            .Where(g => g[a] == 'a' &&
            ((g[corf[0]] == 'c' && g[corf[1]] == 'f') ||
            (g[corf[0]] == 'f' && g[corf[1]] == 'c'))))
        {
            if (IsGuessValid(guess))
            {
                var firstGuess = Substitute(guess);

                var line = ChopUpInputLine(firstGuess);

                var result = RecognitionEngine(line);

                if (!result.Any(r => r == -1))
                {
                    answer = result;
                    break;
                }
            }
        }

        if (answer == null)
        {
            throw new Exception($"Could not decode '{_data} ' :(");
        }

        return SumTheFinalFourNumber(answer);
    }

    private int[] WhatCouldCorFBe()
    {
        var inputNumbers = ChopUpInputLine(_data);

        var inputOne = inputNumbers.First(n => n.Length == 2);

        return new int[] { Array.IndexOf(StandardChars, inputOne[0]), Array.IndexOf(StandardChars, inputOne[1]) };
    }

    private int WhatIsA()
    {
        var inputNumbers = ChopUpInputLine(_data);

        var inputOne = inputNumbers.First(n => n.Length == 2);
        var inputSeven = inputNumbers.First(n => n.Length == 3);

        for (int i = 0; i < inputSeven.Length; i++)
        {
            if (inputSeven[i] != inputOne[0] && inputSeven[i] != inputOne[1])
            {
                return Array.IndexOf(StandardChars, inputSeven[i]);
            }
        }

        throw new Exception("Could not discover 'a'");
    }

    private static bool IsGuessValid(char[] guess)
    {
        foreach (var c in StandardChars)
        {
            if (!guess.Contains(c))
            {
                return false;
            }
        }

        return true;
    }

    private string Substitute(char[] substitutions)
    {
        if (StandardChars.Length != substitutions.Length)
        {
            throw new ArgumentOutOfRangeException();
        }

        var sb = new StringBuilder();

        foreach (var c in _data)
        {
            if (c == ' ' || c == '|')
            {
                sb.Append(c);
                continue;
            }

            var pos = Array.IndexOf(StandardChars, c);

            sb.Append(substitutions[pos]);
        }

        return sb.ToString();
    }

    private static string[] ChopUpInputLine(string line) => line.Replace("| ", "").Split(' ');

    private static int[] RecognitionEngine(string[] inputNumbers)
    {
        var outputNumbers = new int[inputNumbers.Length];

        Array.Fill(outputNumbers, -1);

        for (int i = 0; i < inputNumbers.Length; i++)
        {
            if (DisplayValidator.IsZero(inputNumbers[i]))
            {
                outputNumbers[i] = 0;
            }
            else if (DisplayValidator.IsOne(inputNumbers[i]))
            {
                outputNumbers[i] = 1;
            }
            else if (DisplayValidator.IsTwo(inputNumbers[i]))
            {
                outputNumbers[i] = 2;
            }
            else if (DisplayValidator.IsThree(inputNumbers[i]))
            {
                outputNumbers[i] = 3;
            }
            else if (DisplayValidator.IsFour(inputNumbers[i]))
            {
                outputNumbers[i] = 4;
            }
            else if (DisplayValidator.IsFive(inputNumbers[i]))
            {
                outputNumbers[i] = 5;
            }
            else if (DisplayValidator.IsSix(inputNumbers[i]))
            {
                outputNumbers[i] = 6;
            }
            else if (DisplayValidator.IsSeven(inputNumbers[i]))
            {
                outputNumbers[i] = 7;
            }
            else if (DisplayValidator.IsEight(inputNumbers[i]))
            {
                outputNumbers[i] = 8;
            }
            else if (DisplayValidator.IsNine(inputNumbers[i]))
            {
                outputNumbers[i] = 9;
            }
        }

        return outputNumbers;
    }

    private static int SumTheFinalFourNumber(int[] numbers)
    {
        var sb = new StringBuilder();

        // Sum the final 4?
        for (int i = numbers.Length - 4; i < numbers.Length; i++)
        {
            sb.Append(numbers[i]);
        }

        return int.Parse(sb.ToString());
    }
}