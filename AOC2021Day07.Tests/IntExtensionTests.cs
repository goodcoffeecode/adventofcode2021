using Xunit;

namespace AOC2021Day07.Tests;

public class IntExtensionTests
{
    public class TheSumOfMethod
    {
        [Theory]
        [InlineData(2, 3)]
        [InlineData(3, 6)]
        [InlineData(100, 5050)] // Good ol' Gauss :)
        public void ShouldGiveCorrectResults(int n, int expected)
        {
            Assert.Equal(expected, n.SumOf());
        }
    }
}
