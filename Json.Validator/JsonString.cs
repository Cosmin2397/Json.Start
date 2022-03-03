using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            if (string.IsNullOrEmpty(input) || ContainsControlChars(input))
            {
                return false;
            }

            return HasStartAndEndQuotes(input)
                && ContainsValidEscapeChar(input)
                && IsHex(input);
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
            bool isValidHex = false;
            const string escapeChar = "\\\"/bfnrtu";
            int maxLegth = input.Length - 1;
            for (int i = 0; i < maxLegth; i++)
            {
                if (input[i] == '\\' && i == maxLegth - 1)
                {
                    isValidHex = false;
                    break;
                }
                else if (input[i] == '\\' && escapeChar.Contains(input[i + 1]))
                {
                   isValidHex = true;
                }
                else if (!input.Contains('\\'))
                {
                   return true;
                }
            }

            return isValidHex;
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

        static bool IsHex(string input)
        {
            const int hexLength = 4;
            const int firstHexChar = 2;
            string hexNum = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\' && input[i + 1] == 'u')
                {
                    if (i + firstHexChar + hexLength > input.Length - 1)
                    {
                        return false;
                    }

                    hexNum = input.Substring(i + firstHexChar, hexLength);
                }

                foreach (char c in hexNum)
                {
                    if (!(ContainsDigits(c) || ContainsHexLetters(c)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}