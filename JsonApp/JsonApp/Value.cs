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
            Character comma = new(',');
            Character whiteSpace = new(' ');
            String str = new();
            Number num = new();
            Choice value = new(str, num, new Text("true"), new Text("false"), new Text("null"));
            Sequence array = new(new Character('['), new List(value, new Sequence(comma, whiteSpace)), new Character(']'));
            Sequence obj = new(new Character('{'), new List(new Sequence(whiteSpace, str, whiteSpace, new Character(':'), value, whiteSpace), comma), new Character('}'));
            value.Add(array);
            value.Add(obj);
            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
