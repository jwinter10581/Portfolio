using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.InputValidation
{
    public class ValidateType
    {
        public static AccountType ReadEnum(string prompt, int min, int max)
        {
            AccountType accountType = AccountType.Unavailable;

            do
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();

                if (Enum.TryParse(userInput, out accountType))
                {
                    switch (accountType)
                    {
                        case AccountType.Free:
                            return AccountType.Free;
                        case AccountType.Basic:
                            return AccountType.Basic;
                        case AccountType.Premium:
                            return AccountType.Premium;
                        default:
                            accountType = AccountType.Unavailable;
                            break;
                    }
                }
                if (accountType == 0)
                {
                    Console.WriteLine("That wasn't a valid type of account, please re-enter your choice.");
                    Console.WriteLine("Please enter 1 for Free, 2 for Basic, or 3 for Premium.");
                    Console.WriteLine($"Accounts may be chosen by number ({min} - {max}) or by name.");
                }
            } while (accountType == 0);

            return accountType;
        }
    }
}
