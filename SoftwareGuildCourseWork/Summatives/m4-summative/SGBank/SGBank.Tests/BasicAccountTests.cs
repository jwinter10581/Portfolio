using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.Tests
{
    [TestFixture]
    public class BasicAccountTests
    {
        [TestCase("33333", "Basic Account", 100, AccountType.Free, 250, false)] // wrong acct type
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -100, false)] // negative deposit
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 250, true)] // success
        public void BasicAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();

            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(response.Success, expectedResult);
        }

        [TestCase("33333", "Basic Account", 1500, AccountType.Basic, -1000, 1500, false)] // too much withdraw
        [TestCase("33333", "Basic Account", 100, AccountType.Free, -100, 100, false)] // not a basic acct
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 100, 100, false)] // positive withdraw
        [TestCase("33333", "Basic Account", 150, AccountType.Basic, -50, 100, true)] // success
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -150, -60, true)] // success, with overdraft
        public void BasicAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdraw = new BasicAccountWithdrawRule();

            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(response.Success, expectedResult);

            if (response.Success == true)
            {
                Assert.AreEqual(response.Account.Balance, newBalance);
            }
        }
    }
}
