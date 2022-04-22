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
            Assert.False(character.Match(null).Success());
        }

        [Fact]
        public static void CheckIfWork_WithEmpty()
        {
            Character character = new('a');
            Assert.False(character.Match(string.Empty).Success());
        }

        [Fact]
        public static void Check_WithAInvalidChar_ShouldReturnFalse()
        {
            Character character = new('a');
            Assert.False(character.Match("z").Success());
        }

        [Fact]
        public static void Check_WithAValidChar_ShouldReturnTrue()
        {
            Character character = new('a');
            Assert.True(character.Match("a").Success());
        }

        [Fact]
        public static void Check_WithAStringValidChar_ShouldReturnTrue()
        {
            Character character = new('a');
            Assert.True(character.Match("abcd").Success());
            Assert.True(character.Match("abcd").RemainingText() == "bcd");
            Assert.True(character.Match("abc").Success());
            Assert.True(character.Match("abc").RemainingText() == "bc");
            Assert.True(character.Match("acd").Success());
            Assert.True(character.Match("acd").RemainingText() == "cd");
        }

        [Fact]
        public static void Check_WithAStringInvalidChar_ShouldReturnFalse()
        {
            Character character = new('a');
            Assert.False(character.Match("gbcd").Success());
            Assert.False(character.Match("1bc").Success());
            Assert.False(character.Match("!cd").Success());
        }
    }
}
