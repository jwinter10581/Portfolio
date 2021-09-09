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
    public class PremiumAccountTests
    {
        [TestCase("77777", "Premium Account", 100, AccountType.Free, 250, false)] // wrong acct type
        [TestCase("77777", "Premium Account", 100, AccountType.Premium, -100, false)] // negative deposit
        [TestCase("77777", "Premium Account", 100, AccountType.Premium, 1250, true)] // success
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
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

        [TestCase("77777", "Premium Account", 100, AccountType.Free, -100, false)] // wrong acct type
        [TestCase("77777", "Premium Account", 100, AccountType.Premium, 100, false)] // positive withdraw
        [TestCase("77777", "Premium Account", 100, AccountType.Premium, -1000, false)] // over 500 negative withdrawal
        [TestCase("77777", "Premium Account", 15000, AccountType.Premium, -1500, true)] // success
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();

            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(response.Success, expectedResult);
        }
    }
}
