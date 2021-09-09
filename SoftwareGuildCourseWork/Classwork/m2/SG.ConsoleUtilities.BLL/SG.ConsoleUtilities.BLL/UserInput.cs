using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.ConsoleUtilities.BLL
{
    public class UserInput
    {
        public static int GetIntFromUser(string prompt)
        {
            bool first = true;
            int result;
            string userInput;

            do
            {
                if (!first) // If here 2+ time, the input was not valid
                {
                    Console.WriteLine("That was not a valid input.");
                }

                first = false;

                Console.Write(prompt);
                userInput = Console.ReadLine();
            } while (!int.TryParse(userInput, out result));

            return result;
        }
    }
}
