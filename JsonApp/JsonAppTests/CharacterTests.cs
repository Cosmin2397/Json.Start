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

        [Fact]
        public static void Check_WithAInvalidChar_ShouldReturnFalse()
        {
            Character character = new('a');
            Assert.False(character.Match("z"));
        }

        [Fact]
        public static void Check_WithAValidChar_ShouldReturnTrue()
        {
            Character character = new('a');
            Assert.True(character.Match("a"));
        }

        [Fact]
        public static void Check_WithAStringValidChar_ShouldReturnTrue()
        {
            Character character = new('a');
            Assert.True(character.Match("abcd"));
            Assert.True(character.Match("abc"));
            Assert.True(character.Match("acd"));
        }

        [Fact]
        public static void Check_WithAStringInvalidChar_ShouldReturnFalse()
        {
            Character character = new('a');
            Assert.False(character.Match("gbcd"));
            Assert.False(character.Match("1bc"));
            Assert.False(character.Match("!cd"));
        }
    }
}
