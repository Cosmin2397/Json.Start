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

    }
}
