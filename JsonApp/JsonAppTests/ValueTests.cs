using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class ValueTests
    {
        [Theory]
        [InlineData(" { \"age\": 20, \"age\": 23 } ")]
        [InlineData(" [ \"name\" , 3 , true , \"Ovidiu\" ] ")]
        [InlineData(" 23 ")]
        [InlineData(" \"Ion\" ")]
        [InlineData(" true ")]
        [InlineData(" false ")]
        [InlineData(" null ")]
        public static void CheckIfWork_WithValidData(string inputString)
        {
            Value value = new();
            Assert.True(value.Match(inputString).Success());
        }

        [Theory]
        [InlineData(" { \"name\" : \"Cosmin\" , \"name\" : \"Ovidiu\" ")]
        [InlineData(" [ \"name\" ,3 ,true \"Ovidiu\"")]
        [InlineData(" 24e ")]
        [InlineData(" \"Ion ")]
        [InlineData(" truex ")]
        [InlineData(" fals ")]
        [InlineData(" nulllllllll ")]
        public static void CheckIfWork_WithInvalidData(string inputString)
        {
            Value value = new();
            Assert.False(value.Match(inputString).Success());
        }
    }
}
