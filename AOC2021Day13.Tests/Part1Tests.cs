using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AOC2021Day13.Tests
{
    public class Part1Tests
    {
        [Fact]
        public async Task SampleDataWith1FoldShouldGiveTheCorrectResults()
        {
            const int Expected = 17;

            var data = await InputData.GetDataAsync("..\\..\\..\\sampleInput.txt");
            var points = data.Item1;
            var folds = data.Item2;

            var paper = new Paper(points);

            paper.Fold(folds.First());

            var actual = paper.GetPointCount();

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public async Task SampleDataWith2FoldsShouldGiveTheCorrectResults()
        {
            const int Expected = 16;

            var data = await InputData.GetDataAsync("..\\..\\..\\sampleInput.txt");
            var points = data.Item1;
            var folds = data.Item2;

            var paper = new Paper(points);

            foreach (var fold in folds)
            {
                paper.Fold(fold);
            }

            var actual = paper.GetPointCount();

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public async Task RealDataShouldGiveTheCorrectResults()
        {
            const int Expected = 785;

            var data = await InputData.GetDataAsync("..\\..\\..\\realInput.txt");
            var points = data.Item1;
            var folds = data.Item2;

            var paper = new Paper(points);

            paper.Fold(folds.First());

            var actual = paper.GetPointCount();

            Assert.Equal(Expected, actual);
        }
    }
}