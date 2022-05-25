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
            Any whiteSpace = new(" \n\t\r");
            Many whiteSpaces = new(whiteSpace);
            Choice value = new(str, num, new Text("true"), new Text("false"), new Text("null"));
            Sequence element = new(whiteSpaces, value);
            List elements = new(element, comma);
            Sequence member = new(whiteSpaces, str,new Character(':'), whiteSpace, value);
            List members = new(member, comma);
            Sequence array = new(new Character('['), elements, whiteSpaces, new Character(']'));
            Sequence obj = new(new Character('{'), members,whiteSpaces, new Character('}'));
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
