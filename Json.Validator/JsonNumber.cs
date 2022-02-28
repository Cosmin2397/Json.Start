using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (IsNullOrEmpty(input) || IsInvalidFractionalNum(input) || DoesStartWithZero(input))
            {
                return false;
            }

            return HaveDigits(input);
        }

        static bool HaveDigits(string input)
        {
            int digitsCount = 0;
            int charCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= '0' && input[i] <= '9')
                {
                    digitsCount++;
                }
                else if (input[i] == '-' || input[i] == '+' || input[i] == '.' || char.ToLower(input[i]) == 'e')
                {
                    charCount++;
                }
            }

            return digitsCount + charCount == input.Length && IsValidExponent(input);
        }

        static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        static bool DoesStartWithZero(string input)
        {
            if (input.Length <= 1)
            {
                return false;
            }

            return input[0] == '0';
        }

        static bool IsInvalidFractionalNum(string input)
        {
            const int endWithDot = 2;
            int dots = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == '.')
                {
                    dots++;
                }
                else if (input[^1] == '.')
                {
                    dots += endWithDot;
                }
            }

            return dots > 1;
        }

        static bool IsValidExponent(string input)
        {
            int exponent = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                if (char.ToLower(input[i]) == 'e')
                {
                    exponent++;
                }
            }

            return exponent <= 1;
        }
    }
}
