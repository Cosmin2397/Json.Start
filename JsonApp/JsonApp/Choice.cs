﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Choice : IPattern
    {
        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in patterns)
            {
                var match = pattern.Match(text);
                if (match.Success())
                {
                    return match;
                }
            }

            return new Match(false, text);

        }

        public void Add(IPattern pattern)
        {
            Array.Resize(ref patterns, patterns.Length + 1);
            patterns[^1] = pattern;
        }
    }
}
