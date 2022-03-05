using Xunit;
using static Json.JsonString;

namespace Json.Facts
{
    public class JsonStringFacts
    {
        [Fact]
        public void IsWrappedInDoubleQuotes()
        {
            Assert.True(IsJsonString(Quoted("abc")));
        }

        [Fact]
        public void AlwaysStartsWithQuotes()
        {
            Assert.False(IsJsonString("abc\""));
        }

        [Fact]
        public void AlwaysEndsWithQuotes()
        {
            Assert.False(IsJsonString("\"abc"));
        }

        [Fact]
        public void IsNotNull()
        {
            Assert.False(IsJsonString(null));
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            Assert.False(IsJsonString(string.Empty));
        }

        [Fact]
        public void IsAnEmptyDoubleQuotedString()
        {
            Assert.True(IsJsonString(Quoted(string.Empty)));
        }

        [Fact]
        public void HasStartAndEndQuotes()
        {
            Assert.False(IsJsonString("\""));
            Assert.True(IsJsonString(Quoted("New input")));
        }


        [Fact]
        public void DoesNotContainControlCharacters()
        {
            Assert.False(IsJsonString(Quoted("a\nb\rc")));
            Assert.False(IsJsonString(Quoted("a\nb\\c")));

        }

        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            Assert.True(IsJsonString(Quoted("⛅⚾")));
        }

        [Fact]
        public void CanContainEscapedQuotationMark()
        {
            Assert.True(IsJsonString(Quoted(@"\""a\"" b")));
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            Assert.True(IsJsonString(Quoted(@"a \\ b")));
        }

        [Fact]
        public void CanContainEscapedSolidus()
        {
            Assert.True(IsJsonString(Quoted(@"a \/ b")));
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            Assert.True(IsJsonString(Quoted(@"a \b b")));
            Assert.False(IsJsonString(Quoted(@"a \m b")));
        }

        [Fact]
        public void CanContainEscapedFormFeed()
        {
            Assert.True(IsJsonString(Quoted(@"a \f b")));
        }

        [Fact]
        public void CanContainEscapedLineFeed()
        {
            Assert.True(IsJsonString(Quoted(@"a \n b")));
        }

        [Fact]
        public void CanContainEscapedCarrigeReturn()
        {
            Assert.True(IsJsonString(Quoted(@"a \r b")));
        }

        [Fact]
        public void CanContainEscapedHorizontalTab()
        {
            Assert.True(IsJsonString(Quoted(@"a \t b")));
            Assert.True(IsJsonString(Quoted(@"ThisIsA\t")));
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            Assert.True(IsJsonString(Quoted(@"a \u26Be b")));
            Assert.True(IsJsonString(Quoted(@"a \uFFF4 b")));
            Assert.False(IsJsonString(Quoted(@"a \uFFF4 b\u12z3")));
            Assert.True(IsJsonString(Quoted(@"a \uFFF4 b\u12a3 \u321F")));
        }

        [Fact]
        public void CanContainAllEscapedCharacters()
        {
            Assert.True(IsJsonString(Quoted(@"a \\\\/\b\f\n\r\t\u26Be b")));
        }

        [Fact]
        public void DoesNotContainUnrecognizedExcapceCharacters()
        {
            Assert.False(IsJsonString(Quoted(@"a\x")));
            Assert.False(IsJsonString(Quoted(@"asfaseaw\M")));
        }

        [Fact]
        public void DoesNotEndWithReverseSolidus()
        {
            Assert.False(IsJsonString(Quoted(@"a\")));
            Assert.False(IsJsonString(Quoted(@"cF4Ea\")));
            Assert.False(IsJsonString(Quoted(@"cfaofda\u1F4Ea\")));
            Assert.False(IsJsonString(Quoted(@"cf\ta\/ofd\na\u1F4Ea\")));
        }

        [Fact]
        public void DoesNotEndWithAnUnfinishedHexNumber()
        {
            Assert.False(IsJsonString(Quoted(@"a\u")));
            Assert.False(IsJsonString(Quoted(@"a\u123")));
            Assert.False(IsJsonString(Quoted(@"a\u1GT4")));
            Assert.False(IsJsonString(Quoted(@"a\u1\u1234")));
            Assert.True(IsJsonString(Quoted(@"a\u0AaF")));
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
