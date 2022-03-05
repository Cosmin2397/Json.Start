using System;

namespace Json
{
    public static class JsonString
    {
        const int HexLength = 4;

        public static bool IsJsonString(string input)
        {
            if (string.IsNullOrEmpty(input) || ContainsControlChars(input))
            {
                return false;
            }

            return HasStartAndEndQuotes(input)
                && ContainsValidEscapeChar(input)
                && AreValidHexs(input);
        }

        static bool ContainsControlChars(string input)
        {
            const int us = 31;
            const int dell = 127;
            const int lastControl = 159;
            foreach (char c in input)
            {
                if ((c >= 0 && c <= us) || (c >= dell && c <= lastControl))
                {
                    return true;
                }
            }

            return false;
        }

        static bool ContainsValidEscapeChar(string input)
        {
            if (!input.Contains('\\'))
            {
                return true;
            }

            const string escapeChar = "\\/bfnrtu\"";
            int maxLegth = input.Length - 1;
            for (int i = 0; i < maxLegth; i++)
            {
                if (input.EndsWith("\\\""))
                {
                    return false;
                }
                else if (input[i] == '\\' && !escapeChar.Contains(input[i + 1]) && input[i - 1] != '\\')
                {
                    return false;
                }
            }

            return true;
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
            const int escapeChars = 2;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\' && input[i + 1] == 'u')
                {
                    if (i + escapeChars + HexLength > input.Length - 1)
                    {
                        return false;
                    }

                    string hexNum = input.Substring(i, escapeChars + HexLength);
                    if (!ContainsValidEscapeChar(hexNum) || !IsValidHex(hexNum.Substring(escapeChars)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}