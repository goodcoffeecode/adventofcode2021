using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using static AOC2021Common.MatrixUtils;

namespace AOC2021Day11.Tests;

internal class OctupusEqualityComparer : IEqualityComparer<Point>
{
    public bool Equals(Point x, Point y)
    {
        return GetHashCode(x) == GetHashCode(y);
    }

    public int GetHashCode([DisallowNull] Point obj)
    {
        return (obj.Col * 13) + (obj.Row * 29);
    }
}