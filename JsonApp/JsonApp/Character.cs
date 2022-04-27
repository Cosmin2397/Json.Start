using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Character : IPattern
    {
        readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }


        public IMatch Match(string text)
        {

            bool succes = true;
            if (string.IsNullOrEmpty(text) || text[0] != pattern)
            {
                succes = false;
            }
            if (succes == true)
            {
                text = text[1..];
            }

            return new Match(succes, text);
        }
    }
}
