﻿using Xunit;
using JsonApp;

namespace JsonAppTests
{
    public class SequenceTests
    {
        [Fact]
        public static void CheckIfWork_WithNull()
        {
            Sequence sequence = new(
                new Character('0'),
                new Range('1', '9')
                );
            IMatch match = sequence.Match(null);
            bool isMatch = match.Success();
            Assert.False(isMatch);
        }

        [Fact]
        public static void CheckIfWork_WithStringEmpty()
        {
            Sequence sequence = new(
                new Character('0'),
                new Range('1', '9')
                );
            IMatch match = sequence.Match(string.Empty);
            Assert.False(match.Success());
        }

        [Fact]
        public static void CheckIfWork_WithInvalidNumbers()
        {
            Sequence sequence = new(
                new Character('0'),
                new Range('1', '9')
                );

            Assert.False(sequence.Match("a12").Success());
            Assert.True(sequence.Match("a12").RemainingText() == "a12");
            Assert.False(sequence.Match("m12").Success());
            Assert.True(sequence.Match("m12").RemainingText() == "m12");
            Assert.False(sequence.Match("0a2").Success());
            Assert.True(sequence.Match("0a2").RemainingText() == "0a2");
        }

        [Fact]
        public static void CheckIfWork_WithInvalidLetters()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
               );

            Assert.False(ab.Match("def").Success());
            Assert.True(ab.Match("def").RemainingText() == "def");
            Assert.False(ab.Match("").Success());
            Assert.True(ab.Match("").RemainingText() == "");
            Assert.False(ab.Match(null).Success());
            Assert.True(ab.Match(null).RemainingText() == null);
        }

        [Fact]
        public static void CheckIfWork_WithValidNumbers()
        {
            Sequence sequence = new(
                new Character('0'),
                new Range('1', '9'),
                new Character('0')
                );

            Assert.True(sequence.Match("010").Success());
            Assert.True(sequence.Match("010").RemainingText() == "");
            Assert.True(sequence.Match("0301").Success());
            Assert.True(sequence.Match("0301").RemainingText() == "1");
            Assert.True(sequence.Match("0902").Success());
            Assert.True(sequence.Match("0902").RemainingText() == "2");
        }

        [Fact]
        public static void CheckIfWork_WithValidLetters()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
               );

            Assert.True(ab.Match("abc").Success());
            Assert.True(ab.Match("abc").RemainingText() == "c");


        }

        [Fact]
        public static void CheckIfWork_WithSequencePatterns()
        {
            var hex = new Choice(
             new Range('0', '9'),
             new Range('a', 'f'),
             new Range('A', 'F')
             );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            Assert.True(hexSeq.Match("u1234").Success());
            Assert.True(hexSeq.Match("u1234").RemainingText() == "");
            Assert.True(hexSeq.Match("uabcdef").Success());
            Assert.True(hexSeq.Match("uabcdef").RemainingText() == "ef");
            Assert.True(hexSeq.Match("uB005 ab").Success());
            Assert.True(hexSeq.Match("uB005 ab").RemainingText() == " ab");
            Assert.False(hexSeq.Match("abc").Success());
            Assert.True(hexSeq.Match("abc").RemainingText() == "abc");
        }
    }
}
