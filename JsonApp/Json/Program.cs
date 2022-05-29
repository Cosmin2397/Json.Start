using System;
using System.IO;
using JsonApp;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args != null && args.Length > 0 && File.Exists(args[0]))
            {
                string textFile = System.IO.File.ReadAllText(args[0]);
                Value value = new();
                bool isJson = value.Match(textFile).Success();
                bool isEmpty = value.Match(textFile).RemainingText() == string.Empty;
                if (isJson && isEmpty)
                {
                    Console.WriteLine("Is valid");
                }
                else
                {
                    Console.WriteLine("Is invalid");
                }
            }
            else
            {
                Console.WriteLine("You need to input a valid file path!");
            }
        }
    }
}
