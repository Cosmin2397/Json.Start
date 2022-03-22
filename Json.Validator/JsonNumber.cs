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

        static string Integer(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex != -1)
            {
                return input[..dotIndex];
            }

            if (exponentIndex != -1)
            {
                 return input[..exponentIndex];
            }

            return input;
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

            if (integer.StartsWith('-'))
            {
                integer = integer[1..];
            }

            return ContainsOnlyDigits(integer);
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
            if (exponent.StartsWith('-') || exponent.StartsWith('+'))
            {
                exponent = exponent[1..];
            }

            return ContainsOnlyDigits(exponent);
        }
    }
}
