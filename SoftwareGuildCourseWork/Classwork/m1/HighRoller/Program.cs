using System;

namespace HighRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            Random diceRoller = new Random();

            Console.WriteLine("TIME TO ROLL THE DICE!");
            Console.WriteLine("How many sides would you like your die to be?");
            int dieSize = Convert.ToInt32(Console.ReadLine());

            int rollResult = diceRoller.Next(dieSize) + 1;

            Console.WriteLine($"I rolled a {rollResult}.");

            if (rollResult == 1)
            {
                Console.WriteLine("You rolled a critical failure!");
            }

            else if (rollResult == dieSize)
            {
                Console.WriteLine("You rolled a critical! Nice job!");
            }
        }
    }
}
