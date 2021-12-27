using System.Text;

namespace AOC2021Common;

public static class MatrixUtils
{
    public record struct Point(int Row, int Col, int Value)
    {
        public override string ToString() => $"(Row:{Row}, Col:{Col}, Value:{Value})";

        public string Location { get => BuildLocation(Row, Col); }

        public static string BuildLocation(int row, int col) => $"{row},{col}";
    }

    public static class PointFactory
    {
        private static Dictionary<string, Point> _points = new();

        public static Point Create(int row, int col, int value)
        {
            var key = $"{Point.BuildLocation(row, col)},{value}";

            if (_points.TryGetValue(key, out Point ret))
            {
                return ret;
            }
            else
            {
                var point = new Point(row, col, value);

                _points.Add(key, point);

                return point;
            }
        }
    }

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

    public static void ConsoleOutput(this int[,] matrix)
    {
        for (var row = 0; row < matrix.GetRowCount(); row++)
        {
            var sb = new StringBuilder("\t");

            for (var col = 0; col < matrix.GetColCount(); col++)
            {
                sb.Append($"{matrix[row, col]}\t");
            }

            Console.WriteLine(sb.ToString());
        }

        Console.WriteLine("");
    }

    public static void Fill(this int[,] matrix, int[,] newMatrix, int startRow, int startCol)
    {
        for (int row = startRow; row < startRow + newMatrix.GetRowCount(); row++)
        {
            for (int col = startCol; col < startCol + newMatrix.GetColCount(); col++)
            {
                matrix[row, col] = newMatrix[row - startRow, col - startCol];
            }
        }
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

    public static List<Point> GetCardinalPoints(this int[,] matrix, Point p)
    {
        var points = new List<Point?>
        {
            matrix.GetAbove(p),
            matrix.GetBelow(p),
            matrix.GetLeft(p),
            matrix.GetRight(p)
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

        return PointFactory.Create(row, col, matrix[row, col]);
    }

    public static Point? GetBelow(this int[,] matrix, Point p)
    {
        if (p.Row > matrix.GetRowCount() - 2)
        {
            return null;
        }

        var row = p.Row + 1;
        var col = p.Col;

        return PointFactory.Create(row, col, matrix[row, col]);
    }

    public static Point? GetLeft(this int[,] matrix, Point p)
    {
        if (p.Col <= 0)
        {
            return null;
        }

        var row = p.Row;
        var col = p.Col - 1;

        return PointFactory.Create(row, col, matrix[row, col]);
    }

    public static Point? GetRight(this int[,] matrix, Point p)
    {
        if (p.Col > matrix.GetColCount() - 2)
        {
            return null;
        }

        var row = p.Row;
        var col = p.Col + 1;

        return PointFactory.Create(row, col, matrix[row, col]);
    }

    public static Point? GetTopLeft(this int[,] matrix, Point p)
    {
        if (p.Row <= 0 || p.Col <= 0)
        {
            return null;
        }

        var row = p.Row - 1;
        var col = p.Col - 1;

        return PointFactory.Create(row, col, matrix[row, col]);
    }

    public static Point? GetTopRight(this int[,] matrix, Point p)
    {
        if (p.Row <= 0 || p.Col > matrix.GetColCount() - 2)
        {
            return null;
        }

        var row = p.Row - 1;
        var col = p.Col + 1;

        return PointFactory.Create(row, col, matrix[row, col]);
    }

    public static Point? GetBottomLeft(this int[,] matrix, Point p)
    {
        if (p.Row > matrix.GetRowCount() - 2 || p.Col <= 0)
        {
            return null;
        }

        var row = p.Row + 1;
        var col = p.Col - 1;

        return PointFactory.Create(row, col, matrix[row, col]);
    }

    public static Point? GetBottomRight(this int[,] matrix, Point p)
    {
        if (p.Row > matrix.GetRowCount() - 2 || p.Col > matrix.GetColCount() - 2)
        {
            return null;
        }

        var row = p.Row + 1;
        var col = p.Col + 1;

        return PointFactory.Create(row, col, matrix[row, col]);
    }
}