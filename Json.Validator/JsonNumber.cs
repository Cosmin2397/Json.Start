using System;

namespace Json
{
    public static class JsonNumber
    {
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

        static bool ContainsOnlyDigits(string input)
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

        static bool StartWithMinus(string input)
        {
            return input.StartsWith('-');
        }

        static bool StartWithValidChar(string input)
        {
            return StartWithMinus(input) || input.StartsWith('+');
        }

        static bool IsNegativeInteger(string input)
        {
            return StartWithMinus(input) && ContainsOnlyDigits(input[1..]);
        }

        static bool IsPlusMinusExponent(string input)
        {
            return StartWithValidChar(input) && ContainsOnlyDigits(input[1..]);
        }

        static string Integer(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex == -1 && exponentIndex == -1)
            {
                return input;
            }

            if (dotIndex == -1 && exponentIndex != -1)
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

            if (exponentIndex != -1)
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

            return ContainsOnlyDigits(integer) ||
                IsNegativeInteger(integer);
        }

        static bool IsValidFraction(string fraction)
        {
            if (fraction.Length == 0)
            {
                return true;
            }

            fraction = fraction[1..];
            return ContainsOnlyDigits(fraction);
        }

        static bool IsValidExponent(string exponent)
        {
            if (exponent.Length == 0)
            {
                return true;
            }

            exponent = exponent[1..];
            return ContainsOnlyDigits(exponent)
                || IsPlusMinusExponent(exponent);
        }
    }
}
