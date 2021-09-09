using System;

namespace LazyTeenager
{
    class Program
    {
        static void Main(string[] args)
        {
            int timesScolded = 0, cleaningChance = 0, cleaningCheck = 0;
            Random rng = new Random();

            do
            {
                timesScolded++;
                cleaningChance += 10;
                cleaningCheck = rng.Next(101);
                Console.WriteLine($"Clean your room!! (x{timesScolded})");

                if (timesScolded == 7)
                {
                    Console.WriteLine("That's it, I'm doing it!!!  YOU'RE GROUNDED AND TAKING YOUR XBOX!");
                    break;
                }
                else if (cleaningChance > cleaningCheck)
                {
                    Console.WriteLine("FINE! I'LL CLEAN MY ROOM. BUT I REFUSE TO EAT MY PEAS!");
                    break;
                }

            } while (true);
        }
    }
}
