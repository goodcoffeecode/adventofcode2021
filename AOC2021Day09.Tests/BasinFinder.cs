using System.Collections.Generic;
using System.Linq;
using static AOC2021Common.MatrixUtils;

namespace AOC2021Day09.Tests
{
    internal class BasinFinder
    {
        private readonly int[,] _matrix;

        internal BasinFinder(int[,] matrix)
        {
            _matrix = matrix;
        }

        internal int CountTopThreeBasins(List<Point> localMinima)
        {
            var basinSizes = new List<int>();

            foreach (var point in localMinima)
            {
                var uniquePointsInBasin = FindBasinPoints(point);

                basinSizes.Add(uniquePointsInBasin.Count);
            }

            // Now sum the top 3...
            var top3 = basinSizes.OrderByDescending(b => b).Take(3).ToList();

            return top3[0] * top3[1] * top3[2];
        }

        private List<Point> FindBasinPoints(Point p)
        {
            // First, count ourselves...
            var pointsInBasin = new List<Point> { p };

            pointsInBasin.AddRange(GetPoints(p, _matrix.GetAbove(p)));
            pointsInBasin.AddRange(GetPoints(p, _matrix.GetBelow(p)));
            pointsInBasin.AddRange(GetPoints(p, _matrix.GetLeft(p)));
            pointsInBasin.AddRange(GetPoints(p, _matrix.GetRight(p)));

            return pointsInBasin.Distinct().ToList();
        }

        private List<Point> GetPoints(Point currentPoint, Point? newPoint)
        {
            if (newPoint != null && newPoint.Value.Value < 9 && newPoint.Value.Value > currentPoint.Value)
            {
                return FindBasinPoints(newPoint.Value);
            }

            return new List<Point>();
        }
    }
}