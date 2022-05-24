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
            Any whiteSpace = new(@" \u0020\u000A\u000D\u0009");
            Choice value = new(str, num, new Text("true"), new Text("false"), new Text("null"));
            Sequence element = new(comma, whiteSpace);
            List elements = new(value, element);
            Sequence member = new(whiteSpace, str, whiteSpace, new Character(':'), value, whiteSpace);
            List members = new(member, comma);
            Sequence array = new(new Character('['), new Choice(elements, whiteSpace) , new Character(']'));
            Sequence obj = new(new Character('{'), new Choice(members, whiteSpace), new Character('}'));
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
