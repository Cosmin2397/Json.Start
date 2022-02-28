using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (IsNullOrEmpty(input) || IsInvalidFractionalNum(input))
            {
                return false;
            }

            return HaveDigits(input);
        }

        static bool HaveDigits(string input)
        {
            int digitsCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= '0' && input[i] <= '9')
                {
                    digitsCount++;
                }
            }

            return digitsCount == input.Length;
        }

        static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
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

            return dots > 1;
        }
    }
}
