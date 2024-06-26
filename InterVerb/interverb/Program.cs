﻿//use of string interpolation and verbatim
namespace interverb;

class Program
{
    static void Main(string[] args)
    {
      string projectName = "ACME";
      //adding location to use interpolation and verbatim to declare a method using \, the {} are with $
      string projectLocation = $@"c:\Exercise\{projectName}\data.txt";

      string russianMessage = "\u041f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c  \u0440\u0443\u0441\u0442\u043a\u0439 \u0432\u044b\u0432\u043e\u0434";
      string russianLocation = $@"c:\Exercise\{projectName}\ru-RU\data.txt";
 
      Console.WriteLine($"View English output: \n\t\t{projectLocation}");
      Console.WriteLine($"\n{russianMessage}\n\t\t{russianLocation}");
    }
}
