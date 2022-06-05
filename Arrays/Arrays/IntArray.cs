using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class IntArray
    {
        private int[] arr;

        public IntArray()
        {
            arr = Array.Empty<int>();
        }

        public void Add(int element)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[^1] = element;
        }

        public int Count()
        {
            return arr.Length;
        }

        public int Element(int index)
        {
            return arr[index];
        }

        public void SetElement(int index, int element)
        {
            arr[index] = element;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            Array.Resize(ref arr, arr.Length + 1);
            for (int i = arr.Length - 1; i >= index; i--)
            {
                arr[i] = arr[i - 1];
            }

            arr[index] = element;
        }

        public void Clear()
        {
            for (var i = 0; i < arr.Length; i++)
            {
                SetElement(i, 0);
            }
        }
    }
}
