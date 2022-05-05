using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class OneOrMoreTests
    {
        [Theory]
        [InlineData(null,null)]
        [InlineData("","")]
        [InlineData("bc", "bc")]
        public static void CheckIfWork_WithInvalidRangeValues(string inputString, string expectedString)
        {
            OneOrMore one = new(new Range('0', '9'));
            Assert.False(one.Match(inputString).Success());
            Assert.Equal(one.Match(inputString).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("123", "")]
        [InlineData("1a", "a")]
        [InlineData("1913cb1a", "cb1a")]
        public static void CheckIfWork_WithValidRangeValues(string inputString, string expectedString)
        {
            OneOrMore one = new(new Range('0', '9'));
            Assert.True(one.Match(inputString).Success());
            Assert.Equal(one.Match(inputString).RemainingText(), expectedString);
        }
    }
}
