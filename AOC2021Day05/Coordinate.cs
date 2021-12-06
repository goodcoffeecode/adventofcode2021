namespace AOC2021Day05;

internal record class Coordinate(int X, int Y)
{
    public override string ToString() => $"({X}, {Y})";
}