
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
            Assert.False(range.Match(null).Success());
        }

        [Fact]
        public static void CheckIfWork_WithEmpty()
        {
            Range range = new('a', 'f');
            Assert.False(range.Match(string.Empty).Success());
        }

        [Fact]
        public static void Check_WithAValidChar_ShouldReturnTrue()
        {
            Range range = new('a', 'f');
            Assert.True(range.Match("a").Success());
        }

        [Fact]
        public static void Check_WithAInvalidChar_ShouldReturnFalse()
        {
            Range range = new('a', 'f');
            Assert.False(range.Match("z").Success());
        }

        [Fact]
        public static void Check_WithAStringValidChar_ShouldReturnTrue()
        {
            Range range = new('a', 'f');
            Assert.True(range.Match("fbcd").Success());
            Assert.True(range.Match("abc").Success());
            Assert.True(range.Match("bcd").Success());
        }

        [Fact]
        public static void Check_WithAStringInvalidChar_ShouldReturnFalse()
        {
            Range range = new('a', 'f');
            Assert.False(range.Match("gbcd").Success());
            Assert.False(range.Match("1bc").Success());
            Assert.False(range.Match("!cd").Success());
        }

        [Fact]
        public static void Check_WithAnInvalidRAnge_ShouldReturnFalse()
        {
            Range range = new('f', 'a');
            Assert.False(range.Match("abcd").Success());
            Assert.False(range.Match("fbc").Success());
            Assert.False(range.Match("bcd").Success());
        }

    }
}