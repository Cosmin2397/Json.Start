using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class TextTests
    {
        [Theory]
        [InlineData(null, null)]
        public static void CheckIfWork_WithNull(string inputData, string expectedString)
        {
            Text accepted = new("true");
            Assert.False(accepted.Match(inputData).Success());
            Assert.True(accepted.Match(inputData).RemainingText() == expectedString);
        }

        [Theory]
        [InlineData("", "")]
        public static void CheckIfWork_WithEmpty(string inputData, string expectedString)
        {
            Text accepted = new("true");
            Assert.False(accepted.Match(inputData).Success());
            Assert.True(accepted.Match(inputData).RemainingText() == expectedString);
        }

        [Theory]
        [InlineData("tru", "tru")]
        [InlineData("false", "false")]
        public static void Check_WithAInvalidString_ShouldReturnFalse(string inputData, string expectedString)
        {
            Text unsupportedTrue = new("true");
            bool uTrue = unsupportedTrue.Match(inputData).Success();
            bool uTrueText = unsupportedTrue.Match(inputData).RemainingText() == expectedString;
            Assert.False(uTrue);
            Assert.True(uTrueText);
        }

        [Theory]
        [InlineData("true", "true")]
        [InlineData("nfalse", "nfalse")]
        public static void Check_WithAInvalidStringFalse_ShouldReturnFalse(string inputData, string expectedString)
        {
            Text unsupportedFalse = new("false");
            bool uFalse = unsupportedFalse.Match(inputData).Success();
            bool uFalseText = unsupportedFalse.Match(inputData).RemainingText() == expectedString;
            Assert.False(uFalse);
            Assert.True(uFalseText);
        }

        [Theory]
        [InlineData("truex", "x")]
        [InlineData("true", "")]
        public static void Check_WithAValidStringTrue_ShouldReturnTrue(string inputData, string expectedString)
        {
            Text acceptedTrue = new("true");

            Assert.True(acceptedTrue.Match(inputData).Success());
            Assert.True(acceptedTrue.Match(inputData).RemainingText() == expectedString);
        }

        [Theory]
        [InlineData("falsex", "x")]
        [InlineData("false", "")]
        public static void Check_WithAValidStringFalse_ShouldReturnTrue(string inputData, string expectedString)
        {
            Text acceptedFalse = new("false");

            Assert.True(acceptedFalse.Match(inputData).Success());
            Assert.True(acceptedFalse.Match(inputData).RemainingText() == expectedString);
        }

        [Theory]
        [InlineData("truex", "truex")]
        [InlineData("false", "false")]
        public static void Check_WithAValidStringEmpty_ShouldReturnTrue(string inputData, string expectedString)
        {
            Text empty = new("");

            Assert.True(empty.Match(inputData).Success());
            Assert.True(empty.Match(inputData).RemainingText() == expectedString);
        }
    }
}
