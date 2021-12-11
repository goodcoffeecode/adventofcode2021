using System.Collections.Generic;

namespace AOC2021Day10.Tests;

internal static class LineChecker
{
    internal static char? GetFirstCorruptCharacter(string line)
    {
        var stack = new Stack<char>();

        foreach (var c in line)
        {
            switch (c)
            {
                case '(':
                case '[':
                case '{':
                case '<':
                    stack.Push(c);
                    break;
                case ')':
                    if (stack.Pop() != '(')
                    {
                        return c;
                    }
                    break;
                case ']':
                    if (stack.Pop() != '[')
                    {
                        return c;
                    }
                    break;
                case '}':
                    if (stack.Pop() != '{')
                    {
                        return c;
                    }
                    break;
                case '>':
                    if (stack.Pop() != '<')
                    {
                        return c;
                    }
                    break;
                default:
                    break;
            }
        }

        return null;
    }

    internal static List<char> GetMissingCharactersForIncompleteLine(string line)
    {
        var missingChars = new List<char>();

        var stack = BuildStack(line);

        do
        {
            switch (stack.Pop())
            {
                case '(':
                    missingChars.Add(')');
                    break;
                case '[':
                    missingChars.Add(']');
                    break;
                case '{':
                    missingChars.Add('}');
                    break;
                case '<':
                    missingChars.Add('>');
                    break;
                default:
                    break;
            }
        } while (stack.Count > 0);

        return missingChars;
    }

    private static Stack<char> BuildStack(string line)
    {
        var stack = new Stack<char>();

        foreach (var c in line)
        {
            switch (c)
            {
                case '(':
                case '[':
                case '{':
                case '<':
                    stack.Push(c);
                    break;
                case ')':
                    stack.Pop();
                    break;
                case ']':
                case '}':
                case '>':
                    stack.Pop();
                    break;
                default:
                    break;
            }
        }

        return stack;
    }
}