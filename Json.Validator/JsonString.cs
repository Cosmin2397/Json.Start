using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return HaveTwoQuotes(input)
                && ContainsControlChars(input)
                && ContainsInvalidEscapeChar(input)
                && EndsWithReverseSolidus(input);
        }

        static bool ContainsControlChars(string input)
        {
            string[] controlChars = { "\n", "\r" };
            foreach (string c in controlChars)
            {
                if (input?.Contains(c) != false)
                {
                    return false;
                }
            }

            return true;
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
            const int lasChar = 2;
            return input[input.Length - lasChar] != '\\';
        }
    }
}
