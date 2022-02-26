using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (StartsWithZeroOrIsNullOrEmpty(input))
            {
                return false;
            }

            return int.TryParse(input, out _);
        }

        static bool StartsWithZeroOrIsNullOrEmpty(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            return input.Length > 1 && input[0] == '0';
        }
    }
}
