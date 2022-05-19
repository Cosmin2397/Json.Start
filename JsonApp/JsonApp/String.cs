using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonApp;

namespace JsonApp
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            Character quote = new('\"');
            Choice validCharacters = new(new Range((char)32, (char)33), new Range((char)35, (char)91), new Range((char)93, (char)11093));
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));
            Any escapeChars = new("\"\\/bfnrt");
            Sequence escapeCharsSeq = new(new Character('\\'), new Choice(escapeChars, hexSeq));
            pattern = new Sequence(quote, new Many(new Choice(validCharacters, escapeCharsSeq)), quote);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
