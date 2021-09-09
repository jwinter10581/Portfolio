using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.InputValidation
{
    public class ValidateDecimal
    {
        public static decimal ReadDecimal(string prompt)
        {
            decimal output;

            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();

                if (decimal.TryParse(userInput, out output))
                {
                    break; // Successfully parsed
                }
                else
                {
                    Console.WriteLine("That was not a valid input.  Please enter a number and try again.");
                }
            }
            return output;
        }
    }
}
