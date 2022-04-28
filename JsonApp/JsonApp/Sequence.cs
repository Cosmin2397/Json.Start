﻿using System;
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
            string initialText = text;
            foreach (var pattern in patterns)
            {
                var match = pattern.Match(text);
                text = match.RemainingText();
                if (!match.Success())
                {
                    return new Match(false, initialText);
                }
            }

            return new Match(true, text);

        }
    }
}