using Xunit;

namespace AOC2021Day08.Tests;

public class Part2Tests
{
    [Fact]
    public void OneLineSampleDataShouldGiveTheCorrectResult()
    {
        const int Expected = 5353;
        const string Data = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf";

        var lineDecoder = new LineDecoder(Data);

        var actual = lineDecoder.Decode();

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void SampleDataShouldGiveTheCorrectResult()
    {
        const int Expected = 61229;

        var actual = 0;

        foreach (var line in InputData.GetSampleData())
        {
            var lineDecoder = new LineDecoder(line);

            actual += lineDecoder.Decode();
        }

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void RealDataShouldGiveTheCorrectResult()
    {
        const int Expected = 987553;

        var actual = 0;

        foreach (var line in InputData.GetRealData())
        {
            var lineDecoder = new LineDecoder(line);

            actual += lineDecoder.Decode();
        }

        Assert.Equal(Expected, actual);
    }
}