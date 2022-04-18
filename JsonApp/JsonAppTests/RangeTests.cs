
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonApp;
using Xunit;


namespace JsonAppTests
{
    public class RangeTests
    {
        [Fact]
        public static void CheckIfWork_WithNull()
        {
            Range range = new('a', 'f');
            Assert.False(range.Match(null));
        }

        [Fact]
        public static void CheckIfWork_WithEmpty()
        {
            Range range = new('a', 'f');
            Assert.False(range.Match(string.Empty));
        }

        [Fact]
        public static void Check_WithAValidChar_ShouldReturnTrue()
        {
            Range range = new('a', 'f');
            Assert.True(range.Match("a"));
        }

        [Fact]
        public static void Check_WithAInvalidChar_ShouldReturnFalse()
        {
            Range range = new('a', 'f');
            Assert.False(range.Match("z"));
        }

        [Fact]
        public static void Check_WithAStringValidChar_ShouldReturnTrue()
        {
            Range range = new('a', 'f');
            Assert.True(range.Match("fbcd"));
            Assert.True(range.Match("abc"));
            Assert.True(range.Match("bcd"));
        }

        [Fact]
        public static void Check_WithAStringInvalidChar_ShouldReturnFalse()
        {
            Range range = new('a', 'f');
            Assert.False(range.Match("gbcd"));
            Assert.False(range.Match("1bc"));
            Assert.False(range.Match("!cd"));
        }

    }
}