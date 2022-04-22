using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Choice : IPattern
    {
        readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in patterns)
            {
                if (pattern.Match(text).Success())
                {
                    return pattern.Match(text);
                };
            }

            return new Match(false, text);

        }
    }
}
