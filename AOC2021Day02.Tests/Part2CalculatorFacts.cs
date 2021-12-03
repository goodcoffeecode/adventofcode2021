using Xunit;

namespace AOC2021Day02.Tests
{
    public class Part2CalculatorFacts
    {
        private readonly Part2Calculator _sut = new();

        [Fact]
        public void ExampleDataShouldReturnTheCorrectResult()
        {
            const int Expected = 900;

            var exampleData = new[]
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };

            var actual = _sut.Calculate(exampleData);

            Assert.Equal(Expected, actual.Vector);
        }
    }
}