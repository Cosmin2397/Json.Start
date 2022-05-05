using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class OneOrMoreTests
    {
        [Theory]
        [InlineData(null,null)]
        [InlineData("","")]
        [InlineData("bc", "bc")]
        public static void CheckIfWork_WithInvalidRangeValues(string inputString, string expectedString)
        {
            OneOrMore one = new(new Range('0', '9'));
            Assert.False(one.Match(inputString).Success());
            Assert.Equal(one.Match(inputString).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("123", "")]
        [InlineData("1a", "a")]
        [InlineData("1913cb1a", "cb1a")]
        public static void CheckIfWork_WithValidRangeValues(string inputString, string expectedString)
        {
            OneOrMore one = new(new Range('0', '9'));
            Assert.True(one.Match(inputString).Success());
            Assert.Equal(one.Match(inputString).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("bc", "bc")]
        public static void CheckIfWork_WithInvalidCharacterValues(string inputString, string expectedString)
        {
            OneOrMore one = new(new Character('a'));
            Assert.False(one.Match(inputString).Success());
            Assert.Equal(one.Match(inputString).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("aaa123", "123")]
        [InlineData("abc1a", "bc1a")]
        [InlineData("aa1913cb1a", "1913cb1a")]
        public static void CheckIfWork_WithValidCharacterValues(string inputString, string expectedString)
        {
            OneOrMore one = new(new Character('a'));
            Assert.True(one.Match(inputString).Success());
            Assert.Equal(one.Match(inputString).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("dbc", "dbc")]
        public static void CheckIfWork_WithInvalidAnyValues(string inputString, string expectedString)
        {
            OneOrMore one = new(new Any("abc"));
            Assert.False(one.Match(inputString).Success());
            Assert.Equal(one.Match(inputString).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("aaa123", "123")]
        [InlineData("bbc1a", "1a")]
        [InlineData("c1913cb1a", "1913cb1a")]
        public static void CheckIfWork_WithValidAnyValues(string inputString, string expectedString)
        {
            OneOrMore one = new(new Any("abc"));
            Assert.True(one.Match(inputString).Success());
            Assert.Equal(one.Match(inputString).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("dbc", "dbc")]
        public static void CheckIfWork_WithInvalidTextValues(string inputString, string expectedString)
        {
            OneOrMore one = new(new Text("abc"));
            Assert.False(one.Match(inputString).Success());
            Assert.Equal(one.Match(inputString).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("abc123", "123")]
        [InlineData("abcabcabcb1a", "b1a")]
        [InlineData("abcac1913cb1a", "ac1913cb1a")]
        public static void CheckIfWork_WithValidTextValues(string inputString, string expectedString)
        {
            OneOrMore one = new(new Text("abc"));
            Assert.True(one.Match(inputString).Success());
            Assert.Equal(one.Match(inputString).RemainingText(), expectedString);
        }
    }
}
