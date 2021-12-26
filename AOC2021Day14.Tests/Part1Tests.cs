using Xunit;

namespace AOC2021Day14.Tests
{
    public class Part1Tests : BaseTests
    {
        protected override int Iterations => 10;

        [Fact]
        public void SampleDataShouldReturnCorrectResult()
        {
            const int Expected = 1588;

            var data = InputData.GetSampleData();

            var actual = Process(data);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void RealDataShouldReturnCorrectResult()
        {
            const int Expected = 2345;

            var data = InputData.GetRealData();

            var actual = Process(data);

            Assert.Equal(Expected, actual);
        }
    }
}