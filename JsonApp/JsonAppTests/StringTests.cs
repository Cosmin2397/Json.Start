using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class StringTests
    {
        [Theory]
        [InlineData("\"abc\"", "")]
        [InlineData("\"\"", "")]
        [InlineData("\"\\u1234\"", "")]
        [InlineData("\"⛅⚾\"", "")]
        [InlineData("\"\\\"\\\"\"", "")]
        [InlineData("\"\\\\\"", "")]
        [InlineData("\"\\/\"", "")]
        [InlineData("\"\\b\"", "")]
        [InlineData("\"\\f\"", "")]
        [InlineData("\"\\n\"", "")]
        [InlineData("\"\\r\"", "")]
        [InlineData("\"\\t\"", "")]
        [InlineData("\"\\uabcd\"", "")]
        [InlineData("\"\\uDEFA\"", "")]
        [InlineData("\"\\uDEFA \\uabcd \\u1234\"", "")]
        [InlineData("\"\\uDEFAa \\uabcd b\\u1234\"", "")]
        [InlineData("\"a \\\\\\/\\b\\f\\n\\r\\t\\u26Be b\"", "")]
        public static void CheckIfWork_WithValidValues(string inputString, string remainingText)
        {
            String jsonString = new();
            bool actual = jsonString.Match(inputString).Success();
            Assert.True(actual);
            Assert.Equal(remainingText, jsonString.Match(inputString).RemainingText());
        }

        [Theory]
        [InlineData("a", "a")]
        [InlineData("\"abc", "\"abc")]
        [InlineData("abc\"", "abc\"")]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("\"a\nb\rc\"", "\"a\nb\rc\"")]
        [InlineData("\"aa\\cc\"", "\"aa\\cc\"")]
        [InlineData("\"\\uabc\"", "\"\\uabc\"")]
        [InlineData("\"\\uDEF\"", "\"\\uDEF\"")]
        [InlineData("\"\\uDEFA \\uabcd \\u123\"", "\"\\uDEFA \\uabcd \\u123\"")]
        [InlineData("\"\\uDEFAa \\uabc b\\u1234\"", "\"\\uDEFAa \\uabc b\\u1234\"")]
        [InlineData("\"\\\"", "\"\\\"")]
        public static void CheckIfWork_WithInvalidValues(string inputString, string remainingText)
        {
            String jsonString = new();
            bool actual = jsonString.Match(inputString).Success();
            Assert.False(actual);
            Assert.Equal(remainingText, jsonString.Match(inputString).RemainingText());
        }
    }
}
