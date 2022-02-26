using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (StartsWithZero(input))
            {
                return false;
            }

            return double.TryParse(input, out _);
        }

        static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        static bool StartsWithZero(string input)
        {
            return IsNullOrEmpty(input)
                   || (input.Length > 1 && input[0] == '0' && input[1] != '.');
        }
    }
}
