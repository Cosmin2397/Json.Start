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
            return new Match(false, text);
        }
    }
}
