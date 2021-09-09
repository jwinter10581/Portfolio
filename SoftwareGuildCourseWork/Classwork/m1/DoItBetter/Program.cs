using System;

namespace DoItBetter
{
    class Program
    {
        static void Main(string[] args)
        {
            int miles, hotDogs, languages;

            Console.Write("How many miles can you run? ");
            miles = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("That's just my warmup, I can run " + (miles * 2 + 1) + " without breaking a sweat!");

            Console.WriteLine("How many hot dogs can you eat? ");
            hotDogs = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sounds like my breakfast.  I can scarf " + (hotDogs * 2 + 1) + " and still hunger for more.");

            Console.WriteLine("How many languages do you know? ");
            languages = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("I remember when I could only speak that many, currently I know " + (languages * 2 + 1) + " and counting...");

        }
    }
}
