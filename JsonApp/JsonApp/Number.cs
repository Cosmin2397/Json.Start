using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            Range digit = new('0', '9');
            OneOrMore digits = new(digit);
            Choice integer = new(new Sequence(new Optional(new Character('-')), new Range('1','9'), new Many(digits)), new Character('0'));
            Sequence exponent = new(new Any("eE"), new Optional(new Any("+-")), digits);
            Sequence fraction = new(new Character('.'), digits);
            pattern = new Sequence(integer, new Optional(fraction), new Optional(exponent));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text); 
        }

    }

    }
