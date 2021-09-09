using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.InputValidation
{
    public class ValidateString
    {
        public static string ReadString(string prompt)
        {
            string userInput = "";

            while (userInput == "")
            {
                Console.WriteLine(prompt);

                userInput = Console.ReadLine().Trim();

                if (userInput == "")
                {
                    Console.WriteLine("That input wasn't valid, please try again.");
                }
            }

            return userInput;
        }
    }
}
