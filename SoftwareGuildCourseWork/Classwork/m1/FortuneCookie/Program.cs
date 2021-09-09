using System;

namespace FortuneCookie
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();

            int fortune = rng.Next(10);

            Console.WriteLine("Ahh, let us determine your fortune shall we?");
            switch (fortune)
            {
                case 0:
                    Console.WriteLine("Those aren't the droids you're looking for.");
                    break;
                case 1:
                    Console.WriteLine("Never go in against a Sicilian when death is on the line!");
                    break;
                case 2:
                    Console.WriteLine("Goonies never say die.");
                    break;
                case 3:
                    Console.WriteLine("With great power, there must also come — great responsibility.");
                    break;
                case 4:
                    Console.WriteLine("Never argue with the data.");
                    break;
                case 5:
                    Console.WriteLine("Try not. Do, or do not. There is no try.");
                    break;
                case 6:
                    Console.WriteLine("You are a leaf on the wind, watch how you soar.");
                    break;
                case 7:
                    Console.WriteLine("Do absolutely nothing, and it will be everything that you thought it could be.");
                    break;
                case 8:
                    Console.WriteLine("Kneel before Zod.");
                    break;
                case 9:
                    Console.WriteLine("Make it so.");
                    break;
            }
        }
    }
}
