using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Any: IPattern
    {
        private readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            if(accepted == String.Empty)
            {
                return new Match(accepted == text, text);
            }
            if (!string.IsNullOrEmpty(text) && accepted.Contains(text[0]))
            {
                return new Match(true, text[1..]);
            }


            return new Match(false, text);
        }
    }
}
