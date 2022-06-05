using Arrays;
using Xunit;
using System;

namespace ArraysTests
{
    public class IntArrayTests
    {
        [Fact]
        public void CanCountsElements()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            Assert.Equal(3, arr.Count());
        }

        [Fact]
        public void CanAddAnElement()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            Assert.Equal(2, arr.Element(1));
        }

        [Fact]
        public void CanGetElementByIndex()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            Assert.Equal(3, arr.Element(2));
        }

        [Fact]
        public void CanSetElementAtIndex()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.SetElement(2, 0);
            Assert.Equal(0, arr.Element(2));
        }
    }
}