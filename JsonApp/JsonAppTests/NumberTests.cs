using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class NumberTests
    {
        [Theory]
        [InlineData("0", "")]
        [InlineData("7", "")]
        [InlineData("70", "")]
        [InlineData("-26", "")]
        [InlineData("12e6", "")]
        [InlineData("12e33552", "")]
        [InlineData("12E3", "")]
        [InlineData("12e+3", "")]
        [InlineData("61e-9", "")]
        [InlineData("12.36", "")]
        [InlineData("0.000000001", "")]
        [InlineData("10.00000001", "")]
        [InlineData("12.12e33552", "")]
        [InlineData("12.34E3", "")]
        [InlineData("22e3x3", "x3")]
        [InlineData("22e323e33", "e33")]
        [InlineData("22e", "e")]
        [InlineData("22e+", "e+")]
        [InlineData("22e-", "e-")]
        [InlineData("12.", ".")]
        [InlineData("12.34.35", ".35")]
        [InlineData("12.3x", "x")]
        [InlineData("12.e33552", ".e33552")]
        [InlineData("12e.33552", "e.33552")]
        [InlineData("22e3.3", ".3")]
        [InlineData("07", "7")]
        [InlineData("-0", "")]
        public static void CheckIfWork_WithValidValues(string inputString, string remainingString)
        {
            Number num = new();
            bool actual = num.Match(inputString).Success();
            Assert.True(actual);
            Assert.Equal(remainingString, num.Match(inputString).RemainingText());
        }

        [Theory]
        [InlineData("a")]
        [InlineData(null)]
        [InlineData("")]
        public static void CheckIfWork_WithInvalidValues(string inputString)
        {
            Number num = new();
            bool actual = num.Match(inputString).Success();
            Assert.False(actual);
        }
    }
}
