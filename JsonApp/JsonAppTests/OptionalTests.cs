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
    }
}
