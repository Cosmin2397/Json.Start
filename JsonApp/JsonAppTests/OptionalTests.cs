using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class OptionalTests
    {
        [Fact]
        public static void CheckIfWork_WithNull()
        {
            Optional optional = new(new Character('a'));
            Assert.True(optional.Match(null).Success());
            Assert.Equal(optional.Match(null).RemainingText(), null);
        }

        [Fact]
        public static void CheckIfWork_WithStringEmpty()
        {
            Optional optional = new(new Character('a'));
            Assert.True(optional.Match(string.Empty).Success());
            Assert.Equal(optional.Match(string.Empty).RemainingText(), string.Empty);
        }

        [Theory]
        [InlineData("aaaaaaaaaaaaabc", "aaaaaaaaaaaabc")]
        [InlineData("abaabc", "baabc")]
        [InlineData("bc", "bc")]
        public static void CheckIfWork_WithValidChar(string inputString, string expectedString)
        {
            Optional optional = new(new Character('a'));
            Assert.True(optional.Match(inputString).Success());
            Assert.Equal(optional.Match(inputString).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("123456789bc", "23456789bc")]
        [InlineData("1234", "234")]
        [InlineData("bc", "bc")]
        public static void CheckIfWork_WithValidRange(string inputString, string expectedString)
        {
            Optional optional = new(new Range('0', '9'));
            Assert.True(optional.Match(inputString).Success());
            Assert.Equal(optional.Match(inputString).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("a123456789bc", "123456789bc")]
        [InlineData("b123456789bc", "123456789bc")]
        [InlineData("cc", "c")]
        public static void CheckIfWork_WithValidAny(string inputString, string expectedString)
        {
            Optional optional = new(new Any("abc"));
            Assert.True(optional.Match(inputString).Success());
            Assert.Equal(optional.Match(inputString).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("truex", "x")]
        [InlineData("truetruex", "truex")]
        [InlineData("cc", "cc")]
        public static void CheckIfWork_WithValidText(string inputString, string expectedString)
        {
            Optional optional = new(new Text("true"));
            Assert.True(optional.Match(inputString).Success());
            Assert.Equal(optional.Match(inputString).RemainingText(), expectedString);
        }
    }
}
