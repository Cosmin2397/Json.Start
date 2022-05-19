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
            Sequence natural = new(new Optional(new Character('-')), new Range('1', '9'), new Many(digit));
            Choice integer = new(natural, new Character('0'));
            Sequence exponent = new(new Any("eE"), new Optional(new Any("+-")), new OneOrMore(digit));
            Sequence fraction = new(new Character('.'), new OneOrMore(digit), new Optional(exponent));
            pattern = new Sequence(integer, new Optional(fraction), new Optional(exponent));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text); 
        }

    }

    }
