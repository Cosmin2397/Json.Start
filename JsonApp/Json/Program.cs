using System;
using JsonApp;

namespace Json
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string textFile = System.IO.File.ReadAllText(@input);
            Value value = new();
            bool isJson = value.Match(textFile).Success();
            if (isJson)
            {
                Console.WriteLine("Is valid");
            }
            else
            {
                Console.WriteLine("Is invalid");
            }
        }
    }
}
