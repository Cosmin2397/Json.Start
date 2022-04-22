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
            IMatch match = choices.Match(null);
            bool isMatch = match.Success();
            Assert.False(isMatch);
        }

        [Fact]
        public static void CheckIfWork_WithStringEmpty()
        {
            Choice choices = new(
                new Character('0'),
                new Range('1', '9')
                );
            IMatch match = choices.Match(string.Empty);
            Assert.False(match.Success());
        }

        [Fact]
        public static void CheckIfWork_WithValidNumbers()
        {
            Choice choices = new(
                new Character('0'),
                new Range('1', '9')
                );

            Assert.True(choices.Match("106").Success());
            Assert.True(choices.Match("033").Success());
            Assert.True(choices.Match("092").Success());
        }

        [Fact]
        public static void CheckIfWork_WithValidLetters()
        {
            Choice choices = new(
                new Range('a', 'f'),
                new Range('A', 'F')
                );
            Assert.True(choices.Match("aG").Success());
            Assert.True(choices.Match("bE").Success());
            Assert.True(choices.Match("cD").Success());
            Assert.True(choices.Match("dC").Success());
            Assert.True(choices.Match("eB").Success());
            Assert.True(choices.Match("fA").Success());
        }

        [Fact]
        public static void CheckIfWork_WithInvalidNumbers()
        {
            Choice choices = new(
                new Character('0'),
                new Range('1', '9')
                );

            Assert.False(choices.Match("a12").Success());
            Assert.False(choices.Match("m12").Success());
            Assert.False(choices.Match("q12").Success());
        }

        [Fact]
        public static void CheckIfWork_WithInvalidLetters()
        {
            Choice choices = new(
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            Assert.False(choices.Match("g12").Success());
            Assert.False(choices.Match("Z12").Success());
            Assert.False(choices.Match("Y12").Success());
            Assert.False(choices.Match("W12").Success());
            Assert.False(choices.Match("w12").Success());
            Assert.False(choices.Match("M12").Success());
        }

        [Fact]
        public static void CheckIfWork_WithChoicePatterns()
        {
            var hex = new Choice(
                 new Choice(
                         new Character('0'),
                         new Range('1', '9')),
                 new Choice(
                         new Range('a', 'f'),
                         new Range('A', 'F'))
                     );

            Assert.True(hex.Match("01aA").Success());
            Assert.True(hex.Match("02bB").Success());
            Assert.True(hex.Match("03cC").Success());
            Assert.True(hex.Match("03dD").Success());
            Assert.True(hex.Match("04eE").Success());
            Assert.True(hex.Match("05fF").Success());
            Assert.False(hex.Match("g8").Success());
            Assert.False(hex.Match("G8").Success());
            Assert.False(hex.Match("").Success());
            Assert.False(hex.Match(null).Success());
        }
    }
}
