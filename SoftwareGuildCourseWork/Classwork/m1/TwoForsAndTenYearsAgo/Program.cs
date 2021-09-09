using System;

namespace TwoForsAndTenYearsAgo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What year would you like to count back from? ");
            int year = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(i + " years ago would be " + (year - i));
            }

            Console.WriteLine("\nI can count backwards using a different way too...");

            for (int i = year; i >= year - 20; i--)
            {
                Console.WriteLine((year - i) + " years ago would be " + i);
            }

        }
    }
}
