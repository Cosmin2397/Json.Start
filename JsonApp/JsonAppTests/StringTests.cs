using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class StringTests
    {
        [Theory]
        [InlineData("\"\"", "")]
        public static void CheckIfWork_WithValidValues(string inputString, string remainingText)
        {
            String jsonString = new();
            bool actual = jsonString.Match(inputString).Success();
            Assert.True(actual);
            Assert.Equal(remainingText, jsonString.Match(inputString).RemainingText());
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        public static void CheckIfWork_WithInvalidValues(string inputString, string remainingText)
        {
            String jsonString = new();
            bool actual = jsonString.Match(inputString).Success();
            Assert.False(actual);
            Assert.Equal(remainingText, jsonString.Match(inputString).RemainingText());
        }
    }
}
