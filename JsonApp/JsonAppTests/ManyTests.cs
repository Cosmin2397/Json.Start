using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public  class ManyTests
    {
        [Fact]
        public static void CheckIfWork_WithNull()
        {
            Many many = new( new Character('a'));
            Assert.True(many.Match(null).Success());
            Assert.True(many.Match(null).RemainingText() == null);
        }

        [Fact]
        public static void CheckIfWork_WithStringEmpty()
        {
            Many many = new(new Character('a'));
            Assert.True(many.Match(string.Empty).Success());
            Assert.True(many.Match(string.Empty).RemainingText() == string.Empty);
        }

        [Theory]
        [InlineData("aaaaaaaaaabc", "bc")]
        [InlineData("aaaaaaaababc", "babc")]
        [InlineData("bc", "bc")]
        public static void CheckIfWork_WithValidChar(string inputData, string expectedString)
        {
            Many many = new(new Character('a'));
            Assert.True(many.Match(inputData).Success());
            Assert.Equal(many.Match(inputData).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("123456789bc", "bc")]
        [InlineData("1234", "")]
        [InlineData("bc", "bc")]
        public static void CheckIfWork_WithValidRange(string inputData, string expectedString)
        {
            Many many = new(new Range('0', '9'));
            Assert.True(many.Match(inputData).Success());
            Assert.Equal(many.Match(inputData).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("a123456789bc", "123456789bc")]
        [InlineData("b123456789bc", "123456789bc")]
        [InlineData("cc", "")]
        public static void CheckIfWork_WithValidAny(string inputData, string expectedString)
        {
            Many many = new(new Any("abc"));
            Assert.True(many.Match(inputData).Success());
            Assert.Equal(many.Match(inputData).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("truex", "x")]
        [InlineData("truetruex", "x")]
        [InlineData("cc", "cc")]
        public static void CheckIfWork_WithValidText(string inputData, string expectedString)
        {
            Many many = new(new Text("true"));
            Assert.True(many.Match(inputData).Success());
            Assert.Equal(many.Match(inputData).RemainingText(), expectedString);
        }
    }
}
