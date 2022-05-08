using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class ListTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("abc", "abc")]
        [InlineData("1,2,3", "")]
        [InlineData("1,2,3,", ",")]
        [InlineData("1a", "a")]
        public static void CheckIfWork_WithInvalidRangeValues(string inputString, string expectedString)
        {
            List one = new(new Range('0', '9'), new Character(','));
            Assert.True(one.Match(inputString).Success());
            Assert.Equal(expectedString, one.Match(inputString).RemainingText());
        }

    }
}
