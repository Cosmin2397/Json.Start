using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class SequenceTests
    {
        [Fact]
        public static void CheckIfWork_WithNull()
        {
            Sequence sequence = new(
                new Character('0'),
                new Range('1', '9')
                );
            IMatch match = sequence.Match(null);
            bool isMatch = match.Success();
            Assert.False(isMatch);
        }

        [Fact]
        public static void CheckIfWork_WithStringEmpty()
        {
            Sequence sequence = new(
                new Character('0'),
                new Range('1', '9')
                );
            IMatch match = sequence.Match(string.Empty);
            Assert.False(match.Success());
        }

        [Fact]
        public static void CheckIfWork_WithInvalidNumbers()
        {
            Sequence sequence = new(
                new Character('0'),
                new Range('1', '9')
                );

            Assert.False(sequence.Match("a12").Success());
            Assert.True(sequence.Match("a12").RemainingText() == "a12");
            Assert.False(sequence.Match("m12").Success());
            Assert.True(sequence.Match("m12").RemainingText() == "m12");
            Assert.False(sequence.Match("0a2").Success());
            Assert.True(sequence.Match("0a2").RemainingText() == "0a2");
        }

        [Fact]
        public static void CheckIfWork_WithInvalidLetters()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
               );

            Assert.False(ab.Match("def").Success());
            Assert.True(ab.Match("def").RemainingText() == "def");
            Assert.False(ab.Match("").Success());
            Assert.True(ab.Match("").RemainingText() == "");
            Assert.False(ab.Match(null).Success());
            Assert.True(ab.Match(null).RemainingText() == null);
        }
    }
}
