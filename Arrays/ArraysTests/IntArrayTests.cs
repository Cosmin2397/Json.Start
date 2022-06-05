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
    }
}