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
        public static void CheckIfWork_WithValidNumbers()
        {
            Sequence sequence = new(
                new Character('0'),
                new Range('1', '9'),
                new Character('0')
                );

            Assert.True(sequence.Match("010").Success());
            string result = sequence.Match("010").RemainingText();
            Assert.True(sequence.Match("033").Success());
            Assert.True(sequence.Match("092").Success());
        }

        [Fact]
        public static void CheckIfWork_WithValidLetters()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
               );



            Assert.True(ab.Match("abc").Success());
            

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
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
               );

            Assert.False(ab.Match("def").Success());
            Assert.False(ab.Match("").Success());
            Assert.False(ab.Match(null).Success());
        }

        [Fact]
        public static void CheckIfWork_WithSequencePatterns()
        {
            var hex = new Choice(
             new Range('0', '9'),
             new Range('a', 'f'),
             new Range('A', 'F')
             );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            Assert.True(hexSeq.Match("u1234").Success());
            Assert.True(hexSeq.Match("uabcdef").Success());
            Assert.True(hexSeq.Match("uB005 ab").Success());
            Assert.False(hexSeq.Match("abc").Success() && (hexSeq.Match("abc").RemainingText() != "abc"));
        }
    }
}
