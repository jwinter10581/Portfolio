using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Factorizor.BLL;

namespace Factorizor.Tests
{
    [TestFixture]
    public class FactorizorTests
    {
        [TestCase(1, new string[] { "1", ""})]
        [TestCase(6, new string[]{"1", "2", "3", "6", ""})]
        [TestCase(10, new string[] { "1","2","5","10",""})]
        [TestCase(20, new string[] { "1","2","4","5","10","20", ""})]
        public void FactorizerTests(int number, string[] expected)
        {
            FactorFinder FF = new FactorFinder();
            string[] actual = FF.CreateFactorArray(number);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6)]
        [TestCase(28)]
        [TestCase(496)]
        public void PerfectNumberArePerfect(int number)
        {
            FactorFinder FF = new FactorFinder();
            PerfectChecker Perfect = new PerfectChecker();

            string[] factorArray = FF.CreateFactorArray(number);

            bool actual = Perfect.PerfectFactor(factorArray);

            Assert.IsTrue(actual);
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public void RegularNumbersArentPerfect(int number)
        {
            FactorFinder FF = new FactorFinder();
            PerfectChecker Prime = new PerfectChecker();

            string[] factorArray = FF.CreateFactorArray(number);

            bool actual = Prime.PerfectFactor(factorArray);

            Assert.IsFalse(actual);
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void PrimeNumbersArePrime(int number)
        {
            FactorFinder FF = new FactorFinder();
            PrimeChecker Prime = new PrimeChecker();

            string[] factorArray = FF.CreateFactorArray(number);

            bool actual = Prime.PrimeFactor(factorArray);

            Assert.IsTrue(actual);
        }

        [TestCase(8)]
        [TestCase(10)]
        [TestCase(20)]
        public void RegularNumbersArentPrime(int number)
        {
            FactorFinder FF = new FactorFinder();
            PrimeChecker Prime = new PrimeChecker();

            string[] factorArray = FF.CreateFactorArray(number);

            bool actual = Prime.PrimeFactor(factorArray);

            Assert.IsFalse(actual);
        }
    }
}
