using Xunit;

namespace AOC2021Day01.Tests;

public class ThreeDayIncreaseCounterFacts
{
    private readonly ThreeDayIncreaseCounter _sut = new(new SingleDayIncreaseCounter());

    [Fact]
    public void ExampleDataShouldReturnTheCorrectResult()
    {
        const int ExpectedCount = 5;

        var exampleInputs = new[] {
            199,
            200,
            208,
            210,
            200,
            207,
            240,
            269,
            260,
            263
        };
        
        var actual = _sut.Count(exampleInputs);

        Assert.Equal(ExpectedCount, actual);
    }
}