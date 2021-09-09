using System;

namespace TheCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int startValue, endValue, increment, countNumber = 0;

            Console.WriteLine("*** I LOVE TO COUNT! LET ME SHARE MY COUNTING WITH YOU! ***");
            Console.Write("What number should I start at? ");
            startValue = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nWhat number should I end at? ");
            endValue = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nWhat should I count by? ");
            increment = Convert.ToInt32(Console.ReadLine());

            for (int i = startValue; i < endValue; i += increment)
            {
                Console.Write(i + " ");
                countNumber++;

                if(countNumber == 3)
                {
                    countNumber = 0;
                    Console.WriteLine(" - Ah ah ah!");
                }
            }
        }
    }
}
