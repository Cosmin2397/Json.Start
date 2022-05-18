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
            Character minus = new('-');
            Character dot = new('.');
            Any exponential = new("eE");
            Any signs = new("+-");
            Any empty = new("");
            Range startNum = new('1', '9');
            Range digits = new('0', '9');
            Character zero = new('0');
            Sequence zeroDotSeq = new(new Optional(minus), zero);
            Sequence zeroSeq = new(zero, empty);
            Sequence fullNum = new(new Optional(signs), startNum, new Many(digits));
            Sequence exponentialSeq = new(exponential, new Optional(signs), new OneOrMore(digits), empty);
            Sequence dotSeq = new(new Choice(zeroDotSeq, fullNum), dot, new OneOrMore(digits), new Choice(exponentialSeq, empty));
            Sequence wholeNumSeq = new(new Choice(fullNum, zeroSeq), new Choice(exponentialSeq, empty));
            pattern = new Choice(dotSeq, wholeNumSeq);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text); 
        }

    }

    }
