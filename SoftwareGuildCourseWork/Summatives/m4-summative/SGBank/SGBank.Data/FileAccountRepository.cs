using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        public List<Account> ReadAllAccounts()
        {
            string[] lines = File.ReadAllLines(@".\Accounts.txt");

            List<Account> accounts = new List<Account>();

            for (int a = 1; a < lines.Length; a++)
            {
                string[] columns = lines[a].Split(',');

                Account customer = new Account();
                customer.AccountNumber = columns[0];
                customer.Name = columns[1];
                customer.Balance = Convert.ToDecimal(columns[2]);

                if (columns[3] == "F")
                {
                    customer.Type = AccountType.Free;
                }
                if (columns[3] == "B")
                {
                    customer.Type = AccountType.Basic;
                }
                if (columns[3] == "P")
                {
                    customer.Type = AccountType.Premium;
                }

                accounts.Add(customer);
            }
            return accounts;
        }

        public Account LoadAccount(string AccountNumber)
        {
            var accounts = ReadAllAccounts();

            foreach (var customer in accounts)
            {
                if (customer.AccountNumber == AccountNumber)
                {
                    return customer;
                }
            }

            return null;
        }

        public void SaveAccount(Account account)
        {
            var accounts = ReadAllAccounts();
            
            foreach (var customer in accounts)
            {
                if(customer.AccountNumber == account.AccountNumber)
                {
                    customer.Balance = account.Balance;                    
                    break;
                }

                if(!accounts.Exists(c => c.AccountNumber == account.AccountNumber))
                {
                    accounts.Add(account);
                    break;
                }
            }

            using (StreamWriter writer = new StreamWriter(@".\Accounts.txt"))
            {
                writer.Write("AccountNumber,Name,Balance,Type");
            }

            foreach (var customer in accounts)
            {
                using (StreamWriter writer = File.AppendText(@".\Accounts.txt"))
                {
                    writer.WriteLine();
                    writer.Write(customer.AccountNumber + ",");
                    writer.Write(customer.Name + ",");
                    writer.Write(customer.Balance + ",");

                    if (customer.Type == AccountType.Free)
                    {
                        writer.Write("F");
                    }
                    if (customer.Type == AccountType.Basic)
                    {
                        writer.Write("B");
                    }
                    if (customer.Type == AccountType.Premium)
                    {
                        writer.Write("P");
                    }
                }
            }
        }
    }
}
