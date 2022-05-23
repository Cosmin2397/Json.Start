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
            Choice value = new(str, num, new Text("true"), new Text("false"), new Text("null"));
            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
