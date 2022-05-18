using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            pattern = new Choice();
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text); 
        }

    }

    }
