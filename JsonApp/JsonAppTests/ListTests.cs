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

        [Theory]
        [InlineData("1; 22  ;\n 333 \t; 22", "")]
        [InlineData("1 \n;", " \n;")]
        [InlineData("abc", "abc")]
        public static void CheckIfWork_WithValidRangeValues(string inputString, string expectedString)
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.True(list.Match(inputString).Success());
            Assert.Equal(expectedString, list.Match(inputString).RemainingText());
        }
    }
}
