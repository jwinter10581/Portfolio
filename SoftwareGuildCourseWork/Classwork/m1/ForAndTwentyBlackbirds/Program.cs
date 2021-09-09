using System;

namespace ForAndTwentyBlackbirds
{
    class Program
    {
        static void Main(string[] args)
        {
            int birdsInPie = 0;
            for (int i = 0; i < 24; i++)
            {
                Console.WriteLine($"Blackbird #{birdsInPie} goes into the pie!");
                birdsInPie++;
            }

            Console.WriteLine($"There are {birdsInPie} birds in there!");
            Console.WriteLine("Quite the pie full!");
        }
    }
}
