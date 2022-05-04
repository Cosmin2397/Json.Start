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
            Assert.True(many.Match(inputData).RemainingText() == expectedString);
        }
    }
}
