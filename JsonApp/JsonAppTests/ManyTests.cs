using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public  class ManyTests
    {
        [Fact]
        public static void CheckIfWork_WithNull()
        {
            Many many = new( new Character('a'));
            Assert.True(many.Match(null).Success());
            Assert.True(many.Match(null).RemainingText() == null);
        }

        [Fact]
        public static void CheckIfWork_WithStringEmpty()
        {
            Many many = new(new Character('a'));
            Assert.True(many.Match(string.Empty).Success());
            Assert.True(many.Match(string.Empty).RemainingText() == string.Empty);
        }
    }
}
