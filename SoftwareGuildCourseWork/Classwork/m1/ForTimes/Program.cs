using System;

namespace ForTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hey there, do you like times tables? I do!");
            Console.Write("What number would you like me to recite? ");
            int numberRequested = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 15; i++)
            {
                Console.WriteLine(i + " * " + numberRequested + " = " + (i * numberRequested));
            }
        }
    }
}
