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
            pattern = new Choice();
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
