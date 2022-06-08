using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class IntArray
    {
        private int[] intArray;

        public IntArray()
        {
            intArray = Array.Empty<int>();
        }

        public void Add(int element)
        {
            Array.Resize(ref intArray, intArray.Length + 1);
            intArray[^1] = element;
        }

        public int Count()
        {
            return intArray.Length;
        }

        public int Element(int index)
        {
            return intArray[index];
        }

        public void SetElement(int index, int element)
        {
            intArray[index] = element;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            Array.Resize(ref intArray, intArray.Length + 1);
            ShiftToRight(index);
            intArray[index] = element;
        }

        public void Clear()
        {
            for (var i = 0; i < intArray.Length; i++)
            {
                SetElement(i, 0);
            }
        }

        public bool Remove(int element)
        {
            if (!Contains(element))
            {
                return false;
            }

            RemoveAt(IndexOf(element));
            return true;
        }

        public void RemoveAt(int index)
        {
            ShiftToLeft(index);
            Array.Resize(ref intArray, intArray.Length - 1);
        }

        private void ShiftToRight(int index)
        {
            for (int i = intArray.Length - 1; i >= index; i--)
            {
                intArray[i] = intArray[i - 1];
            }
        }

        private void ShiftToLeft(int index)
        {
            for (int i = index + 1; i <= intArray.Length - 1; i++)
            {
                intArray[i - 1] = intArray[i];
            }
        }
    }
}
