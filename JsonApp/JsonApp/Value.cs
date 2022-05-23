using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            String str = new();
            Number num = new();
            pattern = new Sequence(str);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
