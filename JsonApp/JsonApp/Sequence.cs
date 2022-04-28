using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Sequence : IPattern
    {
        readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch match = new Match(true, text);
            foreach (var pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());
                if (!match.Success())
                {
                    return new Match(false, text);
                }
            }

            return match;

        }
    }
}
