using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            string[] controlChars = { "\n", "\r" };
            foreach (string c in controlChars)
            {
                if (input?.Contains(c) != false)
                {
                    return false;
                }
            }

            return input.StartsWith("\"") && input.EndsWith("\"") && input.Length > 1;
        }
    }
}
