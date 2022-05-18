using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class NumberTests
    {
        [Theory]
        [InlineData(null)]
        public static void CheckIfWork_WithInvalidValues(string inputString)
        {
            Number num = new();
            bool actual = num.Match(inputString).Success();
            Assert.False(actual);
        }
    }
}
