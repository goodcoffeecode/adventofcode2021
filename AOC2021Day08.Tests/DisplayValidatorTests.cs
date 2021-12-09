using Xunit;

namespace AOC2021Day08.Tests;

public class DisplayValidatorTests
{
    [Theory]
    [InlineData("a", false)]
    [InlineData("abcefg", true)]
    [InlineData("abcefa", false)]
    public void IdentitiesZeroCorrectly(string s, bool expected)
    {
        Assert.Equal(expected, DisplayValidator.IsZero(s));
    }

    [Theory]
    [InlineData("a", false)]
    [InlineData("cf", true)]
    [InlineData("ff", false)]
    [InlineData("cc", false)]
    public void IdentitiesOneCorrectly(string s, bool expected)
    {
        Assert.Equal(expected, DisplayValidator.IsOne(s));
    }

    [Theory]
    [InlineData("a", false)]
    [InlineData("acdeg", true)]
    [InlineData("gcdea", true)]
    [InlineData("acdea", false)]
    [InlineData("acceg", false)]
    public void IdentitiesTwoCorrectly(string s, bool expected)
    {
        Assert.Equal(expected, DisplayValidator.IsTwo(s));
    }


    [Theory]
    [InlineData("a", false)]
    [InlineData("acdfg", true)]
    [InlineData("gcdfa", true)]
    [InlineData("acdfa", false)]
    [InlineData("gcdfg", false)]
    public void IdentitiesThreeCorrectly(string s, bool expected)
    {
        Assert.Equal(expected, DisplayValidator.IsThree(s));
    }

    [Theory]
    [InlineData("a", false)]
    [InlineData("bcdf", true)]
    [InlineData("fcdb", true)]
    [InlineData("bcdb", false)]
    [InlineData("fcdf", false)]
    public void IdentitiesFourCorrectly(string s, bool expected)
    {
        Assert.Equal(expected, DisplayValidator.IsFour(s));
    }

    [Theory]
    [InlineData("a", false)]
    [InlineData("abdfg", true)]
    [InlineData("gbdfa", true)]
    [InlineData("abdfa", false)]
    [InlineData("gbdfg", false)]
    public void IdentitiesFiveCorrectly(string s, bool expected)
    {
        Assert.Equal(expected, DisplayValidator.IsFive(s));
    }

    [Theory]
    [InlineData("a", false)]
    [InlineData("abdefg", true)]
    [InlineData("gbdefa", true)]
    [InlineData("abdefa", false)]
    [InlineData("gbdefg", false)]
    public void IdentitiesSixCorrectly(string s, bool expected)
    {
        Assert.Equal(expected, DisplayValidator.IsSix(s));
    }

    [Theory]
    [InlineData("a", false)]
    [InlineData("acf", true)]
    [InlineData("fca", true)]
    [InlineData("aca", false)]
    [InlineData("fcf", false)]
    public void IdentitiesSevenCorrectly(string s, bool expected)
    {
        Assert.Equal(expected, DisplayValidator.IsSeven(s));
    }

    [Theory]
    [InlineData("a", false)]
    [InlineData("abcdefg", true)]
    [InlineData("gbcdefa", true)]
    [InlineData("abcdefa", false)]
    [InlineData("gbcdefg", false)]
    public void IdentitiesEightCorrectly(string s, bool expected)
    {
        Assert.Equal(expected, DisplayValidator.IsEight(s));
    }

    [Theory]
    [InlineData("a", false)]
    [InlineData("abcdfg", true)]
    [InlineData("gbcdfa", true)]
    [InlineData("abcdfa", false)]
    [InlineData("gbcdfg", false)]
    public void IdentitiesNineCorrectly(string s, bool expected)
    {
        Assert.Equal(expected, DisplayValidator.IsNine(s));
    }
}
