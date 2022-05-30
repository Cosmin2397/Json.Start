using System;
using System.IO;
using JsonApp;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        { 
         string textFile = System.IO.File.ReadAllText(args[0]);
         Value value = new();
         IMatch isJson = value.Match(textFile);
         if (isJson.Success() && isJson.RemainingText() == string.Empty)
         {
          Console.WriteLine("Is valid");
         }
         else
         {
          Console.WriteLine("Is invalid");
         }
         if (args == null || args.Length == 0 || !File.Exists(args[0]))
         {
          Console.WriteLine("You need to input a valid file path!");
         }
        }
    }
}
