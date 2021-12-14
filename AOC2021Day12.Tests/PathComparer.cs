using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AOC2021Day12.Tests;

internal class PathComparer : IEqualityComparer<Path>
{
    public bool Equals(Path? x, Path? y)
    {
        if (x == null && y == null)
        {
            return true;
        }
        if (x == null || y == null)
        {
            return false;
        }

        return GetHashCode(x) == GetHashCode(y);
    }

    public int GetHashCode([DisallowNull] Path obj) => obj.ToString().GetHashCode();
}