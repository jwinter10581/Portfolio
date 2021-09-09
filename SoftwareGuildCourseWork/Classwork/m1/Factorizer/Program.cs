using System;

namespace Factorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the factorizer!  We'll be having some fun with numbers today.");
            Console.Write("What integer would you like factorized? ");

            int userNumber, counter = 0, arrayPosition = 0, sum = 0;

            while (!int.TryParse(Console.ReadLine(), out userNumber))
            {
                Console.WriteLine("Please enter an integer: ");
            }

            Console.WriteLine($"The factors of {userNumber} are: ");

            for (int f = 1; f <= userNumber; f++)
            {
                if (userNumber % f == 0)
                {
                    Console.Write(f + " ");
                    counter++;
                }
            }
            Console.WriteLine($"\n{userNumber} has {counter} factors.");

            int[] perfectArray = new int[counter];

            for (int p = 1; p < userNumber; p++)
            {
                if(userNumber % p == 0)
                {
                    perfectArray[arrayPosition] = p;
                    arrayPosition++;
                }
            }

            for (int s = 0; s < perfectArray.Length; s++)
            {
                sum += perfectArray[s];
            }

            if (sum == userNumber)
            {
                Console.WriteLine($"{userNumber} is a perfect number!");
            }
            else
            {
                Console.WriteLine($"{userNumber} is not a perfect number.");
            }

            if (counter == 2)
            {
                Console.WriteLine($"{userNumber} is a prime number!");
            }
            else
            {
                Console.WriteLine($"{userNumber} is not a prime number.");
            }
        }
    }
}
