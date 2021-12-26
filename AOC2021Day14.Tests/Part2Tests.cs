using Xunit;

namespace AOC2021Day14.Tests
{
    /// <summary>
    /// First problem I've really struggled with :(. Had to seek some pointers. Was using the correct Dictionary approach,
    /// but couldn't get my head around the overlapping pairs and when to count and how not to double count characters.
    /// </summary>
    public class Part2Tests : BaseTests
    {
        protected override int Iterations => 40;

        [Fact]
        public void SampleDataShouldReturnCorrectResult()
        {
            const long Expected = 2188189693529;

            var data = InputData.GetSampleData();

            var actual = FastProcess(data);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void RealDataShouldReturnCorrectResult()
        {
            const long Expected = 2432786807053;

            var data = InputData.GetRealData();

            var actual = FastProcess(data);

            Assert.Equal(Expected, actual);
        }
    }
}