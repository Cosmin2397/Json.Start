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
        }
    }
}
