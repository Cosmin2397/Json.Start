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

        [Fact]
        public static void CheckIfWork_WithValidLetters()
        {
            Choice choices = new(
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            Assert.True(choices.Match("a12"));
            Assert.True(choices.Match("B12"));
            Assert.True(choices.Match("C12"));
            Assert.True(choices.Match("d12"));
            Assert.True(choices.Match("E12"));
            Assert.True(choices.Match("c12"));
        }

        [Fact]
        public static void CheckIfWork_WithInvalidNumbers()
        {
            Choice choices = new(
                new Character('0'),
                new Range('1', '9')
                );

            Assert.False(choices.Match("a12"));
            Assert.False(choices.Match("m12"));
            Assert.False(choices.Match("q12"));
        }

        [Fact]
        public static void CheckIfWork_WithInvalidLetters()
        {
            Choice choices = new(
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            Assert.False(choices.Match("g12"));
            Assert.False(choices.Match("Z12"));
            Assert.False(choices.Match("Y12"));
            Assert.False(choices.Match("W12"));
            Assert.False(choices.Match("w12"));
            Assert.False(choices.Match("M12"));
        }

        [Fact]
        public static void CheckIfWork_WithChoicePatterns()
        {
            var hex = new Choice(
                         new Character('0'),
                         new Range('1', '9')
                     );

            Assert.True(hex.Match("012"));
            Assert.True(hex.Match("12"));
            Assert.True(hex.Match("92"));
            Assert.True(hex.Match("a9"));
            Assert.True(hex.Match("f8"));
            Assert.True(hex.Match("A9"));
            Assert.True(hex.Match("F8"));
            Assert.False(hex.Match("g8"));
            Assert.False(hex.Match("G8"));
            Assert.False(hex.Match(""));
            Assert.False(hex.Match(null));
        }
    }
}
