using System;

namespace Json
{
    public static class JsonString
    {
        const int HexLength = 4;
        const int EscapeLength = 2;

        public static bool IsJsonString(string input)
        {
            if (string.IsNullOrEmpty(input) || ContainsControlChars(input))
            {
                return false;
            }

            return HasStartAndEndQuotes(input)
                 && ContainsValidEscapeChar(input[1.. (input.Length - 1)])
                 && ContainValidQuote(input[1.. (input.Length - 1)]);
        }

        static int GetReverseSolidusIndex(string input)
        {
            return input.IndexOf('\\');
        }

        static bool ContainsControlChars(string input)
        {
            const int space = 32;
            foreach (char c in input)
            {
                if (c < space)
                {
                    return true;
                }
            }

            return false;
        }

        static bool ContainValidQuote(string input)
        {
            int indexOfQuote = input.IndexOf('"');
            if (indexOfQuote == -1)
            {
                return true;
            }
            else if (input[indexOfQuote - 1] != '\\')
            {
                return false;
            }

            ContainValidQuote(input[(indexOfQuote + 1) ..]);
            return true;
        }

        static bool ContainsEscapeCharacter(char escape)
        {
            char[] escapedChars = { '"', '\\', '/', 'b', 'f', 'n', 'r', 't' };
            return Array.IndexOf(escapedChars, escape) != -1;
        }

        static bool ContainsValidEscapeChar(string input)
        {
            int indexOfReverseSolidus = GetReverseSolidusIndex(input);
            if (indexOfReverseSolidus == -1)
            {
                return true;
            }
            else if (indexOfReverseSolidus >= input.Length - 1)
            {
                return false;
            }
            else if (!(ContainsEscapeCharacter(input[indexOfReverseSolidus + 1]) || AreValidHexs(input[(indexOfReverseSolidus + 1) ..])))
            {
                return false;
            }

            return ContainsValidEscapeChar(input[(indexOfReverseSolidus + EscapeLength) ..]);
        }

        static bool HasStartAndEndQuotes(string input)
        {
            return input.StartsWith("\"") && input.EndsWith("\"") && input.Length > 1;
        }

        static bool ContainsDigits(char letter)
        {
            return letter >= '0' && letter <= '9';
        }

        static bool ContainsHexLetters(char letter)
        {
            return letter >= 'a' && letter <= 'f' ||
                   letter >= 'A' && letter <= 'F';
        }

        static bool IsHexChar(char c)
        {
            return ContainsDigits(c) || ContainsHexLetters(c);
        }

        static bool IsValidHex(string hexNum)
        {
            foreach (char c in hexNum)
            {
                if (!IsHexChar(c))
                {
                    return false;
                }
            }

            return true;
        }

        static bool AreValidHexs(string input)
        {
            string hexNum = "";
            if (input[0] != 'u' || input.Length - 1 < HexLength)
            {
                return false;
            }
            else if (input[0] == 'u')
                {
                    hexNum = input[1.. (HexLength + 1)];
                    if (!IsValidHex(hexNum))
                    {
                        return false;
                    }
                }

            return true;
        }
    }
}