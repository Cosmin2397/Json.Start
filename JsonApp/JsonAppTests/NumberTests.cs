using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class NumberTests
    {
        [Theory]
        [InlineData("0")]
        [InlineData("7")]
        [InlineData("70")]
        [InlineData("-26")]
        [InlineData("12e6")]
        [InlineData("12e33552")]
        [InlineData("12E3")]
        [InlineData("12e+3")]
        [InlineData("61e-9")]
        public static void CheckIfWork_WithValidValues(string inputString)
        {
            Number num = new();
            bool actual = num.Match(inputString).Success();
            Assert.True(actual);
        }

        [Theory]
        [InlineData("a")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("07")]
        [InlineData("-0")]
        [InlineData("22e3x3")]
        [InlineData("22e323e33")]
        [InlineData("22e")]
        [InlineData("22e+")]
        [InlineData("22e-")]
        public static void CheckIfWork_WithInvalidValues(string inputString)
        {
            Number num = new();
            bool actual = num.Match(inputString).Success();
            Assert.False(actual);
        }
    }
}
