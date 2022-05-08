using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class List:IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            Sequence sequence = new(element, new Many(new Sequence(separator, element)));
            this.pattern = sequence;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}