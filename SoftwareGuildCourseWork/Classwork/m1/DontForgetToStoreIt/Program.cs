using System;

namespace DontForgetToStoreIt
{
    class Program
    {
        static void Main(string[] args)
        {
            int meaningOfLifeAndEverything;
            double pi;
            string cheese, color;

            Console.WriteLine("Give me pie to at least 5 decimals: ");
            pi = Convert.ToDouble(Console.ReadLine());

            // We've got Convert.ToDouble down, but meaningOfLifeAndEverything is an Int
            // So we'll have to use Convert.ToInt32

            Console.WriteLine("What is the meaning of life, the universe, and everything? ");
            meaningOfLifeAndEverything = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is your favorite kind of cheese? ");
            cheese = Console.ReadLine();

            Console.WriteLine("Do you like the coloro red or blue more? ");
            color = Console.ReadLine();

            Console.WriteLine($"Ooh {color} {cheese} sounds delicious!");
            Console.WriteLine($"The circumference of life is " + (2 * pi * meaningOfLifeAndEverything));

        }
    }
}
