using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class TextTests
    {
        [Fact]
        public static void CheckIfWork_WithNull()
        {
            Text accepted = new("true");
            Assert.False(accepted.Match(null).Success());
            Assert.True(accepted.Match(null).RemainingText() == null);
        }

        [Fact]
        public static void CheckIfWork_WithEmpty()
        {
            Text accepted = new("true");
            Assert.False(accepted.Match(string.Empty).Success());
            Assert.True(accepted.Match(string.Empty).RemainingText() == string.Empty);
        }
    }
}
