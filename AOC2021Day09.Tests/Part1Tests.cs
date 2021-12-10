using System.Linq;
using Xunit;

namespace AOC2021Day09.Tests;

public class Part1Tests
{
    [Fact]
    public void SampleDataShouldGiveTheCorrectResult()
    {
        const int Expected = 15;

        var data = MatrixUtils.ConvertToMatrix(InputData.GetRawSampleData());

        var localMinima = data.FindLocalMinima();

        Assert.Equal(Expected, localMinima.Sum(m => m.Value + 1));
    }

    [Fact]
    public void RealDataShouldGiveTheCorrectResult()
    {
        const int Expected = 560;

        var data = MatrixUtils.ConvertToMatrix(InputData.GetRawRealData());

        var localMinima = data.FindLocalMinima();

        Assert.Equal(Expected, localMinima.Sum(m => m.Value + 1));
    }
}