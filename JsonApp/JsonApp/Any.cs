using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Any: IPattern
    {
        private readonly string _accepted;

        public Any(string accepted)
        {
            _accepted = accepted;
        }

        public IMatch Match(string text)
        {
            foreach (char c in _accepted)
            {
                if (!string.IsNullOrEmpty(text) && text[0] == c)
                {
                    return new Match(true, text[1..]);
                }
            }

            return new Match(false, text);
        }
    }
}
