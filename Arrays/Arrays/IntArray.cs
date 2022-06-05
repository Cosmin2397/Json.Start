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
    }
}
