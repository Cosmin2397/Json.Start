
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
        }
    }
}
