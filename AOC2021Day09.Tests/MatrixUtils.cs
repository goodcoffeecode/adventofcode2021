namespace AOC2021Day09.Tests;

public static class MatrixUtils
{
    internal static int[,] ConvertToMatrix(string[] data)
    {
        var ret = new int[data.Length, data[0].Length];

        for (var row = 0; row < data.Length; row++)
        {
            for (var col = 0; col < data[0].Length; col++)
            {
                ret[row, col] = int.Parse(data[row][col].ToString());
            }
        }

        return ret;
    }

    public static int RowCount(this int[,] matrix) => matrix.GetLength(0);

    public static int ColCount(this int[,] matrix) => matrix.GetLength(1);

    public static Point? GetAbove(this int[,] matrix, Point p)
    {
        if (p.Row <= 0)
        {
            return null;
        }

        var row = p.Row - 1;
        var col = p.Col;

        return new Point(row, col, matrix[row, col]);
    }

    public static Point? GetBelow(this int[,] matrix, Point p)
    {
        if (p.Row > matrix.RowCount() - 2)
        {
            return null;
        }

        var row = p.Row + 1;
        var col = p.Col;

        return new Point(row, col, matrix[row, col]);
    }

    public static Point? GetLeft(this int[,] matrix, Point p)
    {
        if (p.Col <= 0)
        {
            return null;
        }

        var row = p.Row;
        var col = p.Col - 1;

        return new Point(row, col, matrix[row, col]);
    }

    public static Point? GetRight(this int[,] matrix, Point p)
    {
        if (p.Col > matrix.ColCount() - 2)
        {
            return null;
        }

        var row = p.Row;
        var col = p.Col + 1;

        return new Point(row, col, matrix[row, col]);
    }
}