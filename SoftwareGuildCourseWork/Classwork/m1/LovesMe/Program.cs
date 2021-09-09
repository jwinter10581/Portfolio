using System;

namespace LovesMe
{
    class Program
    {
        static void Main(string[] args)
        {
            int daisy = 34;
            bool love = true;

            Console.WriteLine("Well, here goes nothing.");

            while (daisy > 0)
            {
                if (love)
                {
                    Console.WriteLine("It loves me NOT!");
                    love = false;
                    daisy--;
                }

                else if (!love)
                {
                    Console.WriteLine("It loves me!");
                    love = true;
                    daisy--;
                }
            }

            if (love)
            {
                Console.WriteLine("I knew it, it LOVES ME!!!");
            }
            else
            {
                Console.WriteLine("Bummer dude, better luck next time.");
            }
        }
    }
}
