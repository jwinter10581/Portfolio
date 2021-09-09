using System;

namespace HiddenNuts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] hidingSpots = new string[100];
            Random squirrel = new Random();
            hidingSpots[squirrel.Next(0, hidingSpots.Length)] = "Nut";
            Console.WriteLine("The nut has been hidden...");

            for (int n = 0; n < hidingSpots.Length; n++)
            {
                if (hidingSpots[n] == "Nut")
                {
                    Console.WriteLine("Found it!  It's hiding in spot #" + n);
                }
            }
        }
    }
}
