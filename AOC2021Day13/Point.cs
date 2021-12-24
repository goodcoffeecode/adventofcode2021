namespace AOC2021Day13;

internal class Point
{
    internal int X { get; private set; }
    internal int Y { get; private set; }

    internal Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    internal void FoldFromBottomToTop(int y)
    {
        if (Y == y)
        {
            throw new ArgumentException($"This point is on the fold: {this}");
        }

        if (Y > y)
        {
            var diff = Y - y;

            Y -= 2 * diff;

            if (Y < 0)
            {
                throw new ArgumentOutOfRangeException($"Y cannot be less than zero, but it's {Y}");
            }
        }
    }

    internal void FoldFromRightToLeft(int x)
    {
        if (X == x)
        {
            throw new ArgumentException($"This point is on the fold: {this}");
        }

        if (X > x)
        {
            var diff = X - x;

            X -= 2 * diff;

            if (X < 0)
            {
                throw new ArgumentOutOfRangeException($"X cannot be less than zero, but it's {X}");
            }
        }
    }

    public override string ToString() => $"({X}, {Y})";
}