using System.Diagnostics.CodeAnalysis;

namespace AOC2021Day13;

internal class PointEqualityComparer : IEqualityComparer<Point>
{
    public bool Equals(Point? x, Point? y)
    {
        if (x == null && y == null)
            return true;

        if (x == null || y == null)
            return false;

        return GetHashCode(x) == GetHashCode(y);
    }

    public int GetHashCode([DisallowNull] Point p)
    {
        //return ((p.X * 7) + (p.Y * 13)).GetHashCode();

        return p.ToString().GetHashCode();
    }
}