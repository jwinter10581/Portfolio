using System;

namespace Opinionator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();

            Console.WriteLine("I can't decide what animal I like the best.");
            Console.WriteLine("I know! Random can decide FOR ME!");

            int x = randomizer.Next(5);

            Console.WriteLine($"The number we chose was {x}.");

            switch (x)
            {
                case 0:
                    Console.WriteLine("Llamas are the best.");
                    break;
                case 1:
                    Console.WriteLine("Dodos are the best.");
                    break;
                case 2:
                    Console.WriteLine("Wooly mammoths are DEFINITELY the best!");
                    break;
                case 3:
                    Console.WriteLine("Sharks are the GOAT!  They have their own week.");
                    break;
                case 4:
                    Console.WriteLine("Cockatoos are just okay.");
                    break;
                case 5:
                    Console.WriteLine("Have you ever met a naked mole-rat? They're strange.");
                    break;
            }

            Console.WriteLine("Thanks Random, maybe you're the best.");
        }
    }
}
