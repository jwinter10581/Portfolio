using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.UI.InputValidation;
using SGBank.Data;

namespace SGBank.UI.Workflows
{
    public class CreateAccountWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            FileAccountRepository repository = new FileAccountRepository();
            Account newCustomer = new Account();

            Console.WriteLine("Create an account");
            Console.WriteLine("----------------------------");
         
            newCustomer.Name = ValidateString.ReadString("Enter a name for the account: ");
            newCustomer.AccountNumber = ValidateString.ReadString("Enter an account number: ");  // I think I might need to update this to make sure there's no accountNumber duplicates because it'll only grab the first one.
            newCustomer.Balance = ValidateDecimal.ReadDecimal("Enter an account balance: ");
            newCustomer.Type = ValidateType.ReadEnum("Enter an account type: ", 1, 3);  // 1 for free, 2 for basic, 3 for premium   

            var accounts = repository.ReadAllAccounts();
            var accountNumberInUse = accounts.Any(a => a.AccountNumber == newCustomer.AccountNumber);

            if (accountNumberInUse)
            {
                Console.WriteLine($"The account number: {newCustomer.AccountNumber} is already in use.  Press any key to continue...");
                Console.ReadKey();
                return;
            }

            repository.SaveAccount(newCustomer);
        }
    }
}
