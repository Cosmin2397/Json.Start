using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Range : IPattern
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Match(string text)
        {
            if(string.IsNullOrEmpty(text) || start > end)
            {
                return false;
            }

            return text[0] >= start && text[0] <= end;
        }
    }
}
