namespace AOC2021Day05;

internal record class Line(Coordinate Start, Coordinate End)
{
    public bool IsVerticalOrHorizontal() => (Start.X == End.X || Start.Y == End.Y);

    public bool HasAGradientOfOneOrMinusOne()
    {
        var grad = GetGradient();

        return (grad == 1.0 || grad == -1.0);
    }

    public double GetGradient()
    {
        var diffX = End.X - Start.X;
        var diffY = (double)End.Y - Start.Y;

        if (diffX == 0)
        {
            return 90.0;
        }

        return diffY / diffX;
    }

    public IList<Coordinate> GetAllIntergerCoordinates()
    {
        var x = GetIntegerSteps(Start.X, End.X);
        var y = GetIntegerSteps(Start.Y, End.Y);

        var coords = new List<Coordinate>();

        for (int i = 0; i < Math.Max(x.Count, y.Count); i++)
        {
            coords.Add(new Coordinate(x[Math.Min(i, x.Count - 1)], y[Math.Min(i, y.Count - 1)]));
        }

        return coords;
    }

    private static List<int> GetIntegerSteps(int a, int b)
    {
        var vals = new List<int>();

        if (a == b)
        {
            vals.Add(a);
        }
        else if (b > a)
        {
            for (int i = a; i <= b; i++)
            {
                vals.Add(i);
            }
        }
        else if (a > b)
        {
            for (int i = a; i >= b; i--)
            {
                vals.Add(i);
            }
        }

        return vals;
    }
}