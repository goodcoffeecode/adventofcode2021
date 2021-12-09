using System.Collections.Generic;

namespace AOC2021Day08.Tests;

public static class ListExtensions
{
    public static IEnumerable<char[]> GetPermutations(this char[] list)
    {
        var x = list.Length - 1;

        foreach (var perm in GetPermutations(list, 0, x))
        {
            yield return perm;
        }
    }

    private static IEnumerable<char[]> GetPermutations(char[] list, int k, int m)
    {
        if (k == m)
        {
            yield return list;
        }
        else
        {
            for (var i = k; i <= m; i++)
            {
                Swap(ref list[k], ref list[i]);

                foreach (var perm in GetPermutations(list, k + 1, m))
                {
                    yield return perm;
                }

                Swap(ref list[k], ref list[i]);
            }
        }
    }

    private static void Swap(ref char a, ref char b)
    {
        if (a == b) return;

        var temp = a;
        a = b;
        b = temp;
    }
}