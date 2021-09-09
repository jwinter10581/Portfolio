using System;

namespace BiggerBetterAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            int first, second, third;

            Console.WriteLine("Hey, we're gonna add three numbers together.");
            Console.Write("Which number first? ");
            first = Convert.ToInt32(Console.ReadLine());

            Console.Write("...and the second? ");
            second = Convert.ToInt32(Console.ReadLine());

            Console.Write("And lastly, the third number? ");
            third = Convert.ToInt32(Console.ReadLine());

            int sum = first + second + third;
            Console.WriteLine("{0} + {1} + {2} = {3}", first, second, third, sum);
        }
    }
}
