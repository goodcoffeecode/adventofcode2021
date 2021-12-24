namespace AOC2021Day13;

internal class Paper
{
    private readonly PointEqualityComparer _pointEqualityComparer = new PointEqualityComparer();
    private IEnumerable<Point> _points;

    internal Paper(IEnumerable<Point> points)
    {
        ArgumentNullException.ThrowIfNull(points);

        _points = points;
    }

    internal void Fold(Fold fold)
    {
        if (fold.Axis == 'x')
        {
            FoldFromRightToLeft(fold.Pos);
        }
        else if (fold.Axis == 'y')
        {
            FoldFromBottomToTop(fold.Pos);
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    internal void FoldFromBottomToTop(int y)
    {
        foreach (var p in _points)
        {
            p.FoldFromBottomToTop(y);
        }

        Reduce();
    }

    private void Reduce() => _points = _points.Distinct(_pointEqualityComparer);

    internal void FoldFromRightToLeft(int x)
    {
        foreach (var p in _points)
        {
            p.FoldFromRightToLeft(x);
        }

        Reduce();
    }

    internal int GetPointCount() => _points.Count();

    internal int GetMaxX() => _points.Select(p => p.X).Max();

    internal int GetMaxY() => _points.Select(p => p.Y).Max();

    internal void Output()
    {
        for (var y = 0; y <= GetMaxY(); y++)
        {
            for (var x = 0; x <= GetMaxX(); x++)
            {
                var match = _points.FirstOrDefault(p => p.X == x && p.Y == y);

                if (match != null)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine("");
        }
    }
}