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
            Character comma = new(',');
            Character whiteSpace = new(' ');
            Choice value = new(str, num, new Text("true"), new Text("false"), new Text("null"));
            Sequence array = new(new Character('['), new List(value, new Sequence(comma, whiteSpace)), new Character(']'));
            Sequence obj = new(new Character('{'), new List(new Sequence(whiteSpace, str, whiteSpace, new Character(':'), value, whiteSpace), comma), new Character('}'));
            value.Add(array);
            value.Add(obj);
            pattern = new Sequence(whiteSpace, value, whiteSpace);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
