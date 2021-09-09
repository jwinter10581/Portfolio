using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.UI
{
    public class UserInput
    {

        public const int MinimumFactor = 1;

        public static bool IsValidFactor(int guess)
        {
            return (MinimumFactor < guess);
        }

        /// <summary>
        /// TODO: Add more validation for negative numbers, letter number combos, zero, anything else you can think of
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static int GetIntFromUser(string prompt)
        {
            bool first = true;
            int result;
            string userInput;

            do
            {
                if (!first) // If here a second or subsequent time, the input was not valid
                {
                    Console.WriteLine("That is not a valid input.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

                first = false; // Set first to false to cause error message to display above on the next pass through the loop

                Console.Write(prompt); // 1 & 2 Prompt and Read
                userInput = Console.ReadLine();
            } while (!int.TryParse(userInput, out result));

            return result;
        }
    }
}
