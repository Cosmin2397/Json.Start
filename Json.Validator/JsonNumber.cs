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

        static bool StartsWithMinus(string input)
        {
            return input.Length > 1
                && input.StartsWith('-')
                && ContainsDigits(input[1..]);
        }

        static bool StartsWithPlus(string input)
        {
            return input.Length > 1
                && input.StartsWith('+')
                && ContainsDigits(input[1..]);
        }

        static string Integer(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex != -1 && (exponentIndex < 0 || exponentIndex > dotIndex))
            {
                return input[0.. dotIndex];
            }
            else if (dotIndex == -1 && exponentIndex != -1)
            {
                return input[0..exponentIndex];
            }

            return input;
        }

        static string Fraction(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex != -1 && exponentIndex == -1)
            {
                return input[(dotIndex + 1) ..];
            }
            else if (dotIndex != -1 && exponentIndex > dotIndex)
            {
                return input[(dotIndex + 1) ..exponentIndex];
            }

            return "1";
        }

        static string Exponent(string input, int exponentIndex)
        {
            if (exponentIndex != -1)
            {
                return input[(exponentIndex + 1) ..];
            }

            return "1";
        }

        static bool IsValidInteger(string integer)
        {
            if (integer.Length > 1 && integer[0] == '0')
            {
                return false;
            }

            return ContainsDigits(integer) || StartsWithMinus(integer);
        }

        static bool IsValidFraction(string integer)
        {
            return ContainsDigits(integer);
        }

        static bool IsValidExponent(string integer)
        {
            if (string.IsNullOrEmpty(integer))
            {
                return false;
            }

            return ContainsDigits(integer)
                || StartsWithMinus(integer)
                || StartsWithPlus(integer);
        }
    }
}
