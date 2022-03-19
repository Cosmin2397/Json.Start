using System;

namespace Json
{
    public static class JsonNumber
    {
        static int firstDigitAfterSigns = 2;

        public static bool IsJsonNumber(string input)
        {
            if (IsNullOrEmpty(input))
            {
                return false;
            }

            int dotIndex = input.IndexOf('.');
            int exponentIndex = input.ToLower().IndexOf('e');
            return IsValidInteger(Integer(input, dotIndex, exponentIndex))
                && IsValidFraction(Fraction(input, dotIndex, exponentIndex))
                && IsValidExponent(Exponent(input, exponentIndex));
        }

        static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        static bool ContainsDigits(string input)
        {
            if (IsNullOrEmpty(input))
            {
                return false;
            }

            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        static bool StartWithValidChar(string input)
        {
            return input.StartsWith('-') || input.StartsWith('+');
        }

        static string Integer(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex == -1 && exponentIndex == -1)
            {
                return input;
            }
            else if (dotIndex == -1 && exponentIndex != -1)
            {
                return input[0..exponentIndex];
            }

            return input[0.. dotIndex];
        }

        static string Fraction(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex == -1)
            {
                return string.Empty;
            }
            else if (exponentIndex > dotIndex)
            {
                return input[dotIndex ..exponentIndex];
            }

            return input[dotIndex..];
        }

        static string Exponent(string input, int exponentIndex)
        {
            if (exponentIndex == -1)
            {
                return string.Empty;
            }

            return input[exponentIndex..];
        }

        static bool IsValidInteger(string integer)
        {
            if (integer.Length > 1 && integer[0] == '0')
            {
                return false;
            }

            return ContainsDigits(integer) ||
                (integer.StartsWith('-')
                && ContainsDigits(integer[1..]));
        }

        static bool IsValidFraction(string fraction)
        {
            if (fraction.Length == 0)
            {
                return true;
            }

            return ContainsDigits(fraction[1..]);
        }

        static bool IsValidExponent(string exponent)
        {
            if (exponent.Length == 0)
            {
                return true;
            }

            return ContainsDigits(exponent[1..])
                || (StartWithValidChar(exponent[1..])
                && ContainsDigits(exponent[firstDigitAfterSigns..]));
        }
    }
}
