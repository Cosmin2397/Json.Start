using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            if (string.IsNullOrEmpty(input) || EndsWithAnUnfinishedHexNumber(input) || ContainsControlChars(input))
            {
                return false;
            }

            return HaveTwoQuotes(input)
                && ContainsInvalidEscapeChar(input)
                && EndsWithReverseSolidus(input);
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

        static bool ContainsInvalidEscapeChar(string input)
        {
            const string escapeChar = "\"\\/fnbrtu";
            for (int i = 0; i < input.Length - 1; i++)
            {
                int x = 0;
                if (input[i] == '\\')
                {
                    x++;
                }

                if ((x > 0 && escapeChar.Contains(input[i + 1])) || input.IndexOf('\\') == -1)
                    {
                        return true;
                    }
            }

            return false;
        }

        static bool HaveTwoQuotes(string input)
        {
            if (input == null)
            {
                return false;
            }

            return input.StartsWith("\"") && input.EndsWith("\"") && input.Length > 1;
        }

        static bool EndsWithReverseSolidus(string input)
        {
            const int lastChar = 2;
            return input[^lastChar] != '\\';
        }

        static bool EndsWithAnUnfinishedHexNumber(string input)
        {
            const int two = 2;
            int length = -1;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '\\' && input[i + 1] == 'u')
                {
                    length = (input.Length - 1) - (i + two);
                }
            }

            const int minimumUnicode = 4;

            return length > -1 && length <= minimumUnicode;
        }
    }
}
