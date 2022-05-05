using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class OneOrMore : IPattern
    {
        private readonly IPattern pattern;



        public OneOrMore(IPattern pattern)
        {
            this.pattern = pattern;
        }


        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
