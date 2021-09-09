using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.UI
{
    public class UserOutput
    {
        public static void DisplayIntroduction()
        {
            Console.WriteLine("Welcome to the better, testable, factorizor!");
            Console.WriteLine("Today we will be checking what factors a number has, if it's prime, and if it's perfect.");
            Console.WriteLine("A prime number is a number with only two factors, a perfect number is when the sum of the factors adds up to the number.");
        }

        public static void DisplayFactors(string[] factorArray)
        {
            Console.Write($"The factors for {factorArray[factorArray.Length - 2]} are: ");

            for (int i = 0; i < factorArray.Length - 1; i++)
            {
                Console.Write($"{factorArray[i]} ");
            }
        }

        public static void DisplayPerfect(bool perfectStatus, string[] factorArray)
        {
            if (perfectStatus)
            {
                Console.WriteLine($"\n{factorArray[factorArray.Length - 2]} is a perfect number.");
            }
            else
            {
                Console.WriteLine($"\n{factorArray[factorArray.Length - 2]} is not a perfect number.");
            }
        }

        public static void DisplayPrime(bool primeStatus, string[] factorArray)
        {
            if (primeStatus)
            {
                Console.WriteLine($"{factorArray[factorArray.Length - 2]} is a prime number.");
            }
            else
            {
                Console.WriteLine($"{factorArray[factorArray.Length - 2]} is not a prime number.");
            }
        }
    }
}
