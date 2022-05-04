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
            Assert.Equal(accepted.Match(inputData).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("", "")]
        public static void CheckIfWork_WithEmpty(string inputData, string expectedString)
        {
            Text accepted = new("true");
            Assert.False(accepted.Match(inputData).Success());
            Assert.Equal(accepted.Match(inputData).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("tru", "tru")]
        [InlineData("false", "false")]
        public static void Check_WithAInvalidString_ShouldReturnFalse(string inputData, string expectedString)
        {
            Text unsupportedTrue = new("true");
            Assert.False(unsupportedTrue.Match(inputData).Success());
            Assert.Equal(unsupportedTrue.Match(inputData).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("true", "true")]
        [InlineData("nfalse", "nfalse")]
        public static void Check_WithAInvalidStringFalse_ShouldReturnFalse(string inputData, string expectedString)
        {
            Text unsupportedFalse = new("false");
            Assert.False(unsupportedFalse.Match(inputData).Success());
            Assert.Equal(unsupportedFalse.Match(inputData).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("truex", "x")]
        [InlineData("true", "")]
        public static void Check_WithAValidStringTrue_ShouldReturnTrue(string inputData, string expectedString)
        {
            Text acceptedTrue = new("true");

            Assert.True(acceptedTrue.Match(inputData).Success());
            Assert.Equal(acceptedTrue.Match(inputData).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("falsex", "x")]
        [InlineData("false", "")]
        public static void Check_WithAValidStringFalse_ShouldReturnTrue(string inputData, string expectedString)
        {
            Text acceptedFalse = new("false");

            Assert.True(acceptedFalse.Match(inputData).Success());
            Assert.Equal(acceptedFalse.Match(inputData).RemainingText(), expectedString);
        }

        [Theory]
        [InlineData("truex", "truex")]
        [InlineData("false", "false")]
        public static void Check_WithAValidStringEmpty_ShouldReturnTrue(string inputData, string expectedString)
        {
            Text empty = new("");

            Assert.True(empty.Match(inputData).Success());
            Assert.Equal(empty.Match(inputData).RemainingText(), expectedString);
        }
    }
}
