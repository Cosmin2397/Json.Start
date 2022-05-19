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
            Choice validCharacters = new(new Range(' ', '!'), new Range('#', '['), new Range(']', char.MaxValue));
            Choice hex = new (new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            Sequence hexSeq = new (new Character('u'), new Sequence(hex, hex, hex, hex));
            Any escapeChars = new("\"\\/bfnrt");
            Sequence escapeCharsSeq = new(new Character('\\'), new Choice(escapeChars, hexSeq));
            Choice character = new (validCharacters, escapeCharsSeq);
            Many characters = new(character);
            pattern = new Sequence(quote, characters , quote);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
