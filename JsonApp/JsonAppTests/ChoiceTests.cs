using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class ChoiceTests
    {
        [Fact]
        public static void CheckIfWork_WithNull()
        {
            Choice choices = new(
                new Character('0'),
                new Range('1', '9')
                );

            Assert.False(choices.Match(null));
        }

        [Fact]
        public static void CheckIfWork_WithStringEmpty()
        {
            Choice choices = new(
                new Character('0'),
                new Range('1', '9')
                );

            Assert.False(choices.Match(string.Empty));
        }

        [Fact]
        public static void CheckIfWork_WithValidNumbers()
        {
            Choice choices = new(
                new Character('0'),
                new Range('1', '9')
                );

            Assert.True(choices.Match("012"));
            Assert.True(choices.Match("112"));
            Assert.True(choices.Match("912"));
        }
    }
}
