using Xunit;

namespace AOC2021Day09.Tests
{
    public class Part2Tests
    {
        [Fact]
        public void SampleDataShouldGiveTheCorrectResult()
        {
            const int Expected = 1134;

            // First, let's get the localMinima?
            var data = MatrixUtils.ConvertToMatrix(InputData.GetRawSampleData());

            var localMinima = data.FindLocalMinima();

            // Now we need to iteratively flow out from each local minima until we've found all the rising points
            var finder = new BasinFinder(data);

            var actual = finder.CountTopThreeBasins(localMinima);

            Assert.Equal(Expected, actual);
        }


        [Fact]
        public void RealDataShouldGiveTheCorrectResult()
        {
            const int Expected = 959136;

            // First, let's get the localMinima?
            var data = MatrixUtils.ConvertToMatrix(InputData.GetRawRealData());

            var localMinima = data.FindLocalMinima();

            // Now we need to iteratively flow out from each local minima until we've found all the rising points
            var finder = new BasinFinder(data);

            var actual = finder.CountTopThreeBasins(localMinima);

            Assert.Equal(Expected, actual);
        }
    }
}