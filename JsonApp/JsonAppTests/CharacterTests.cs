using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class CharacterTests
    {
        [Fact]
        public static void CheckIfWork_WithNull()
        {
            Character character = new('a');
            Assert.False(character.Match(null));
        }

        [Fact]
        public static void CheckIfWork_WithEmpty()
        {
            Character character = new('a');
            Assert.False(character.Match(string.Empty));
        }
    }
}
