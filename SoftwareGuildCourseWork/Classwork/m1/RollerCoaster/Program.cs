using System;

namespace RollerCoaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("We're going to go on a roller coaster...");
            Console.WriteLine("Let me know when you want to get off!");

            string keepRiding = "y";
            int loopsLooped = 0;
            while (keepRiding == "y")  // If we change this to a "n", the only thing to break out of the loop is the user enter "n"
            {
                Console.WriteLine("WHEEEEEEEEEEEEE!!!!");
                Console.Write("Want to keep going? (y-n) : "); // If a user enters anything that isn't y, it will break out of the loop.
                keepRiding = Console.ReadLine();
                loopsLooped++;
            }

            Console.WriteLine("Wow, that was FUN!");
            Console.WriteLine($"We looped that loop {loopsLooped} times!");
        }
    }
}
