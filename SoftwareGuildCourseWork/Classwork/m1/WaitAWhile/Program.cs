using System;

namespace WaitAWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeNow = 5; // Increasing this to 11 means it won't loop and will just do the finishing statement
            int bedTime = 10;  // Increasing this to 11 means the original loop will run one more time

            while (timeNow < bedTime)
            {
                Console.WriteLine($"It's only {timeNow} o'clock!");
                Console.WriteLine("I think I'll stay up just a little bit longer...");
                timeNow++; // Time passes
            }

            Console.WriteLine($"Oh, it's {timeNow} o'clock.");
            Console.WriteLine("Guess I should head to bed...");
        }
    }
}
