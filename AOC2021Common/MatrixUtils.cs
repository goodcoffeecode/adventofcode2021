namespace AOC2021Common;

public static class MatrixUtils
{
    public record struct Point(int Row, int Col, int Value);

    public static int[,] ConvertToMatrix(IList<string> data)
    {
        var ret = new int[data.Count, data[0].Length];

        for (var row = 0; row < data.Count; row++)
        {
            for (var col = 0; col < data[0].Length; col++)
            {
                ret[row, col] = int.Parse(data[row][col].ToString());
            }
        }

        return ret;
    }

    public static int GetRowCount(this int[,] matrix) => matrix.GetLength(0);

    public static int GetColCount(this int[,] matrix) => matrix.GetLength(1);

    public static List<Point> GetSurroundingPoints(this int[,] matrix, Point p)
    {
        var points = new List<Point?>
        {
            matrix.GetAbove(p),
            matrix.GetBelow(p),
            matrix.GetLeft(p),
            matrix.GetRight(p),
            matrix.GetTopLeft(p),
            matrix.GetTopRight(p),
            matrix.GetBottomLeft(p),
            matrix.GetBottomRight(p)
        };

        return points.Where(p => p != null).Select(p => p.Value).ToList();
    }

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
        if (p.Row > matrix.GetRowCount() - 2)
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
        if (p.Col > matrix.GetColCount() - 2)
        {
            return null;
        }

        var row = p.Row;
        var col = p.Col + 1;

        return new Point(row, col, matrix[row, col]);
    }

    public static Point? GetTopLeft(this int[,] matrix, Point p)
    {
        if (p.Row <= 0 || p.Col <= 0)
        {
            return null;
        }

        var row = p.Row - 1;
        var col = p.Col - 1;

        return new Point(row, col, matrix[row, col]);
    }

    public static Point? GetTopRight(this int[,] matrix, Point p)
    {
        if (p.Row <= 0 || p.Col > matrix.GetColCount() - 2)
        {
            return null;
        }

        var row = p.Row - 1;
        var col = p.Col + 1;

        return new Point(row, col, matrix[row, col]);
    }

    public static Point? GetBottomLeft(this int[,] matrix, Point p)
    {
        if (p.Row > matrix.GetRowCount() - 2 || p.Col <= 0)
        {
            return null;
        }

        var row = p.Row + 1;
        var col = p.Col - 1;

        return new Point(row, col, matrix[row, col]);
    }

    public static Point? GetBottomRight(this int[,] matrix, Point p)
    {
        if (p.Row > matrix.GetRowCount() - 2 || p.Col > matrix.GetColCount() - 2)
        {
            return null;
        }

        var row = p.Row + 1;
        var col = p.Col + 1;

        return new Point(row, col, matrix[row, col]);
    }
}