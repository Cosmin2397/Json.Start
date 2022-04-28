
namespace JsonAppTests
{
    using Xunit;
    using JsonApp;

    namespace JsonAppTests
    {
        public class AnyTests
        {
            [Fact]
            public static void CheckIfWork_WithNull()
            {
                Any accepted = new("Ee");
                Assert.False(accepted.Match(null).Success());
                Assert.True(accepted.Match(null).RemainingText() == null);
            }

            [Fact]
            public static void CheckIfWork_WithEmpty()
            {
                Any accepted = new("Ee");
                Assert.False(accepted.Match(string.Empty).Success());
                Assert.True(accepted.Match(string.Empty).RemainingText() == string.Empty);
            }

            [Fact]
            public static void Check_WithAInvalidString_ShouldReturnFalse()
            {
                Any accepted = new("Ee");
                Assert.False(accepted.Match("a").Success());
            }

            [Fact]
            public static void Check_WithAInvalidSignString_ShouldReturnTrue()
            {
                Any accepted = new("+-");
                Assert.False(accepted.Match("2").Success());
                Assert.True(accepted.Match("2").RemainingText() == "2");
                Assert.False(accepted.Match("*3").Success());
                Assert.True(accepted.Match("*3").RemainingText() == "*3");
                Assert.False(accepted.Match("/4").Success());
                Assert.True(accepted.Match("/4").RemainingText() == "/4");
            }
        }
    }
}
