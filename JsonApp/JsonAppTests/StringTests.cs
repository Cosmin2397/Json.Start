using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class StringTests
    {

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
