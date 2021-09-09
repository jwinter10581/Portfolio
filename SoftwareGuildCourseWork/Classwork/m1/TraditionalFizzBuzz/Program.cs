using System;

namespace TraditionalFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int fizzBuzz = 0, requestedFizzBuzz;

            Console.WriteLine("Hey there, you know what you need?  Some fizzing and buzzing.");
            Console.Write("How much fizz buzz do you need in your life? ");
            requestedFizzBuzz = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 1; fizzBuzz <= requestedFizzBuzz; i++)
            {
                if (fizzBuzz == requestedFizzBuzz)
                {
                    Console.WriteLine("TRADITION!");
                    break;
                }

                else if ((i % 15) == 0)
                {
                    Console.WriteLine("FIZZ BUZZ");
                    fizzBuzz++;
                }
                else if ((i % 5) == 0)
                {
                    Console.WriteLine("Buzz!");
                    fizzBuzz++;
                }
                else if ((i % 3) == 0)
                {
                    Console.WriteLine("Fizz!");
                    fizzBuzz++;
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
