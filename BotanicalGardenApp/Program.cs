using BotanicalGardenApp.Presentation;
using System;

namespace BotanicalGardenApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Information();
            Display display = new Display();
        }

        static void Information()
        {
            Console.WriteLine(new string('-', 42));
            Console.WriteLine(new string(' ', 5) + "NP\"Obuchenie IT kariera\"-2021" + new string(' ', 5));
            Console.WriteLine();
            Console.WriteLine(new string(' ', 10) + "Botanical Garden" + new string(' ', 10));
            Console.WriteLine(new string(' ', 5) + "Created by Monika and Feray" + new string(' ', 5));
            Console.WriteLine(new string('-', 42));
            Console.ReadKey();
            Console.Clear();
        }
    }
}
