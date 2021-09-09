using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
            Console.ReadLine();
        }

        static void Execute()
        {
            for (int i = 1; i <= 100; i++)
            {
                //if (i % 15 == 0)  3 * 5 = 15, but directions say "if both"
                if (i % 5 == 0 && i % 3 == 0)
                {
                    Console.WriteLine(i + " FizzBuzz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine(i + " Buzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine(i + " Fizz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
