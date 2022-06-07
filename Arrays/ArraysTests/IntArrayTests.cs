using Arrays;
using Xunit;

namespace ArraysTests
{
    public class IntArrayTests
    {
        [Fact]
        public void CanAddAnElement()
        {
            var intArray = new IntArray();
            intArray.Add(1);
            intArray.Add(2);
            intArray.Add(3);
            Assert.Equal(2, intArray.Element(1));
        }

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

        [Fact]
        public void CanCheckIfContains()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            Assert.True(arr.Contains(1));
        }

        [Fact]
        public void CanGetIndexOfElement()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            Assert.Equal(0, arr.IndexOf(1));
        }

        [Fact]
        public void CanInsertItem()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.Insert(1, 4);
            Assert.Equal(4, arr.Element(1));
        }

        [Fact]
        public void CanClear()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.Clear();
            Assert.Equal(0, arr.Element(2));
        }

        [Fact]
        public void CanRemoveElement()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.Remove(1);
            Assert.Equal(2, arr.Element(0));
        }

        [Fact]
        public void CanRemoveElementAt()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.RemoveAt(0);
            Assert.Equal(2, arr.Element(0));
        }
    }
}