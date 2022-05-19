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
            Any escapeChars = new("\"\\/bfnrt");
            Sequence escapeCharsSeq = new(new Character('\\'), new Choice(escapeChars));
            pattern = new Sequence(quote, new Many(new Choice(validCharacters, escapeCharsSeq)), quote);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
