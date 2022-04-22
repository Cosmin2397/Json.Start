using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Match : IMatch
    {
        readonly bool success;
        readonly string message;

        public Match(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }
        public bool Success()
        {
            return success;
        }
        public string RemainingText()
        {
            if(Success())
            {
                return message[1..];
            }

            return message;
        }
    }
}