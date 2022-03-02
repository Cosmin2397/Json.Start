using System;
using System.Text.RegularExpressions;

namespace Json
{
    public static class JsonString
    {
        private static readonly Regex HexRegex = new Regex("([A-Fa-f0-9]{4})$");

        public static bool IsJsonString(string input)
        {
            if (string.IsNullOrEmpty(input) || HasAIncompleteHex(input) || ContainsControlChars(input))
            {
                return false;
            }

            return HasStartAndEndQuotes(input)
                && ContainsValidEscapeChar(input);
        }

        static bool ContainsControlChars(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsControl(input[i]))
                {
                    return true;
                }
            }

            return false;
        }

        static bool ContainsValidEscapeChar(string input)
        {
            char[] escapeChar = { '"', '\\', '/', 'f', 'n', 'b', 'r', 't', 'u' };
            int indexOfReverseSolidus = input.IndexOf('\\');
            foreach (char c in escapeChar)
            {
                if ((input[indexOfReverseSolidus + 1] == c
                    && indexOfReverseSolidus + 1 != input.Length - 1)
                    || indexOfReverseSolidus == -1)
                {
                    return true;
                }
            }

            return false;
        }

        static bool HasStartAndEndQuotes(string input)
        {
            return input.StartsWith("\"") && input.EndsWith("\"") && input.Length > 1;
        }

        static bool HasAIncompleteHex(string input)
            {
            const int hexLength = 4;
            int hexIndex = input.IndexOf('u');
            if (!input.Contains("\\u"))
            {
                return false;
            }
            else if ((input.Length - 1) - (hexIndex + 1) < hexLength)
            {
                return true;
            }

            string hexNum = input.Substring(hexIndex + 1, 4);
            bool isHex = HexRegex.Match(hexNum).Success;
            return !isHex;
        }
    }
}
