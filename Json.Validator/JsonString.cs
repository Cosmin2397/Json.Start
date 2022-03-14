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
                 && ContainsValidEscapeChar(input[1.. (input.Length - 1)]);
        }

        static int GetReverseSolidusIndex(string input)
        {
            return input.IndexOf('\\');
        }

        static bool ContainsQuotationMark(string input)
        {
            return input.IndexOf('"') != -1;
        }

        static bool ContainsControlChars(string input)
        {
            foreach (char c in input)
            {
                if (c < ' ')
                {
                    return true;
                }
            }

            return false;
        }

        static bool ContainsEscapeCharacter(char escape)
        {
            const string escapedChars = @"\""\\/bfnrt";
            return escapedChars.Contains(escape);
        }

        static bool ContainsValidEscapeChar(string input)
        {
            int indexOfReverseSolidus = GetReverseSolidusIndex(input);
            if (indexOfReverseSolidus == -1 && !ContainsQuotationMark(input))
            {
                return true;
            }
            else if (indexOfReverseSolidus == -1 && ContainsQuotationMark(input))
            {
                return false;
            }

            if (indexOfReverseSolidus >= input.Length - 1 || !(ContainsEscapeCharacter(input[indexOfReverseSolidus + 1]) || AreValidHexs(input[(indexOfReverseSolidus + 1) ..])))
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
            if (input[0] != 'u' || input.Length - 1 < HexLength)
            {
                return false;
            }

            return IsValidHex(input[1.. (HexLength + 1)]);
        }
    }
}