using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Text : IPattern
    {
        private readonly string prefix;
        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return new Match(true, text);
            }

            return new Match(false, text);
        }
    }

}