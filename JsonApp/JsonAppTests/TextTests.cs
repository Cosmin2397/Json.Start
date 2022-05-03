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

        [Fact]
        public static void Check_WithAInvalidString_ShouldReturnFalse()
        {
            Text unsupportedTrue = new("true");
            Text unsupportedFalse = new("false");
            Text empty = new("");
            Assert.False(unsupportedTrue.Match("tru").Success());
            Assert.True(unsupportedTrue.Match("tru").RemainingText() == "tru");
            Assert.False(unsupportedTrue.Match("false").Success());
            Assert.True(unsupportedTrue.Match("false").RemainingText() == "false");
            Assert.False(unsupportedFalse.Match("true").Success());
            Assert.True(unsupportedFalse.Match("true").RemainingText() == "true");
            Assert.False(unsupportedFalse.Match("nfalse").Success());
            Assert.True(unsupportedFalse.Match("nfalse").RemainingText() == "nfalse");
        }
    }
}
