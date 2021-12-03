namespace AOC2021Day03.Tests;

public class Part1CalculatorFacts
{
    private readonly Part1Calculator _sut = new Part1Calculator();

    [Fact]
    public async Task ExampleDataShouldReturnTheCorrectResult()
    {
        const int Expected = 198;

        var inputs = await GetExampleDataAsync();

        var actual = _sut.Calculate(inputs);

        Assert.Equal(Expected, actual.Power);
    }

    private async static Task<bool[][]> GetExampleDataAsync()
    {
        var strings = new string[]
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        var stringListReader = new Mock<IStringListReader>();

        stringListReader.Setup(m => m.ReadAsStringListAsync()).ReturnsAsync(strings.ToList());

        var bitArrayReader = new JaggedBitArrayReader(stringListReader.Object);

        return await bitArrayReader.ReadAsJaggedBitArrayAsync();
    }
}