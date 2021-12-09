namespace AOC2021Day08.Tests;

public static class StringsExtensions
{
    public static bool ContainsAllCharacter(this string s, params char[] chars)
    {
        for (var i = 0; i < chars.Length; i++)
        {
            if (!s.Contains(chars[i]))
            {
                return false;
            }
        }

        return true;
    }
}