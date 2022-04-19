﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Choice
    {
        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public bool Match(string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                return false;
            }
            if(patterns[0].Match(text))
            { 
                return true; 
            }
            return false;
        }
    }
}