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

            return HaveCharsAndDigits(input)
                && IsValidExponent(input)
                && ExponentIsComplete(input)
                && ExponentIsAfterFraction(input);
        }

        static int HaveDigits(string input)
        {
            int digitsCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= '0' && input[i] <= '9')
                {
                    digitsCount++;
                }
            }

            return digitsCount;
        }

        static bool HaveCharsAndDigits(string input)
        {
            int charCount = 0;
            int digitsCount = HaveDigits(input);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-' || input[i] == '+' || input[i] == '.' || char.ToLower(input[i]) == 'e')
                {
                    charCount++;
                }
            }

            return charCount + digitsCount == input.Length;
        }

        static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        static bool DoesStartWithZero(string input)
        {
            if (input.Length <= 1 || IsAFraction(input))
            {
                return false;
            }

            return input[0] == '0';
        }

        static bool IsAFraction(string input)
        {
            return input.Contains('.');
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

        static bool ExponentIsComplete(string input)
        {
            for (int i = 0; i < input.Length; ++i)
            {
                if (char.ToLower(input[i]) == 'e')
                {
                    return HaveDigits(input.Substring(i)) > 0;
                }
            }

            return true;
        }

        static bool HaveExponentAndFraction(string input)
        {
            return input.Contains('.') && input.Contains('e');
        }

        static bool ExponentIsAfterFraction(string input)
        {
            if (HaveExponentAndFraction(input))
            {
                return input.IndexOf('e') > input.IndexOf('.');
            }
            else if (!HaveExponentAndFraction(input))
            {
                return true;
            }

            return false;
        }
    }
}
