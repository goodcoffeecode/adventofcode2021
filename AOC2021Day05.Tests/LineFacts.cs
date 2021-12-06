using Xunit;

namespace AOC2021Day05.Tests;

public class LineFacts
{
    public class TheIsVerticalOrHorizontalMethod
    {
        [Theory]
        [InlineData(1, 2, 3, 4)]
        [InlineData(4, 3, 2, 1)]
        [InlineData(1, 1, 4, 4)]
        public void ShouldBeFalseForDiagonalLines(int startX, int startY, int endX, int endY)
        {
            var start = new Coordinate(startX, startY);
            var end = new Coordinate(endX, endY);

            var line = new Line(start, end);

            Assert.False(line.IsVerticalOrHorizontal());
        }

        [Theory]
        [InlineData(3, 6, 7)]
        [InlineData(-3, -6, -7)]
        public void ShouldBeTrueForHorizontalLines(int y, int startX, int endX)
        {
            var start = new Coordinate(startX, y);
            var end = new Coordinate(endX, y);

            var line = new Line(start, end);

            Assert.True(line.IsVerticalOrHorizontal());
        }

        [Theory]
        [InlineData(5, -4, 12)]
        [InlineData(-5, 4, 12)]
        public void ShouldBeTrueForVerticalLines(int x, int startY, int endY)
        {
            var start = new Coordinate(x, startY);
            var end = new Coordinate(x, endY);

            var line = new Line(start, end);

            Assert.True(line.IsVerticalOrHorizontal());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(12, 8)]
        [InlineData(-4, 27)]
        public void ShouldBeTrueForPoints(int x, int y)
        {
            var start = new Coordinate(x, y);
            var end = new Coordinate(x, y);

            var line = new Line(start, end);

            Assert.True(line.IsVerticalOrHorizontal());
        }
    }

    public class TheGetAllIntergerCoordinatesMethod
    {
        [Theory]
        [InlineData(1, 2, 1, 4, 3)]
        //[InlineData(0, 0, 24, 0, 25)]
        public void ShouldCalculateTheCorrectNumberOfCoordinates(int startX, int startY, int endX, int endY, int expectedCoordinateCount)
        {
            var start = new Coordinate(startX, startY);
            var end = new Coordinate(endX, endY);

            var line = new Line(start, end);

            var actual = line.GetAllIntergerCoordinates();

            // 1, 2
            // 1, 3
            // 1, 4

            Assert.Equal(expectedCoordinateCount, actual.Count);
        }
    }

    public class TheGetGradientMethod
    {
        [Theory]
        [InlineData(0, 0, 5, 5, 1.0)]       // 45 degree angle
        [InlineData(0, 0, -5, -5, 1.0)]     // 45 degree angle
        [InlineData(0, 0, -5, 5, -1.0)]     // Negative 45 degree angle
        [InlineData(1, 2, 1, -42, 90.0)]    // Vertical line
        [InlineData(1, 5, 90, 5, 0.0)]      // Horizontal line
        [InlineData(24, 1, 24, 130, 90.0)]  // Vertical line
        public void ShouldReturnTheCorrectResult(int startX, int startY, int endX, int endY, double expectedGradient)
        {
            var start = new Coordinate(startX, startY);
            var end = new Coordinate(endX, endY);

            var line = new Line(start, end);

            Assert.Equal(expectedGradient, line.GetGradient());
        }
    }

    public class TheHasAGradientOfOneOrMinusOneMethod
    {
        [Theory]
        [InlineData(0, 0, 5, 5, true)]       // 45 degree angle
        [InlineData(0, 0, -5, -5, true)]     // 45 degree angle
        [InlineData(0, 0, -5, 5, true)]     // Negative 45 degree angle
        [InlineData(0, 0, -5, 6, false)]     // Not quite 45 degrees
        [InlineData(1, 2, 1, -42, false)]    // Vertical line
        [InlineData(1, 5, 90, 5, false)]      // Horizontal line
        [InlineData(24, 1, 24, 130, false)]  // Vertical line
        public void ShouldReturnTheCorrectResult(int startX, int startY, int endX, int endY, bool expected)
        {
            var start = new Coordinate(startX, startY);
            var end = new Coordinate(endX, endY);

            var line = new Line(start, end);

            var grad = line.GetGradient();

            Assert.Equal(expected, line.HasAGradientOfOneOrMinusOne());
        }
    }
}