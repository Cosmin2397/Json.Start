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
            pattern = new Sequence(quote, quote);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
