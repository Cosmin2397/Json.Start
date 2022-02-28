using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (StartsWithZero(input) || IsInvalidFractionalNum(input))
            {
                return false;
            }

            return IsZero(input);
        }

        static bool IsZero(string input)
        {
            return input == "0";
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

        static bool IsInvalidFractionalNum(string input)
        {
            int dots = 0;
            foreach (char c in input)
            {
                if (c == '.')
                {
                    dots++;
                }
            }

            return dots > 1 || input[^1] == '.';
        }
    }
}
