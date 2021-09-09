using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SWG_Warmups.BLL;

namespace SWG_Warmups.Tests
{
    [TestFixture]
    public class WarmupsTests
    {
        private Warmups warmups = new Warmups();

        [TestCase("Link","L",5.00,2.50)]
        [TestCase("Zelda", "L", 3.50, 3.50)]
        [TestCase("Ganon", "G", 4.00, 2.00)]
        [TestCase("Impa", "I", 2.00, 1.00)]
        [TestCase("", "Z", 1.50, 1.50)]
        public void NameoftheDay(string Name, string specialLetter, double orderTotal, double expected)
        {
            var actual = warmups.NameoftheDay(Name, specialLetter, orderTotal);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("charmander", 'l', 1, 4.00, 4.00)]
        [TestCase("squirtle", 'l', 6, 2.00, 1.00)]
        [TestCase("bulbasaur", 'b', 3, 4.00, 2.00)]
        [TestCase("pikachu", 'u', 10, 2.00, 1.00)]
        [TestCase("mewtwo", 'm', 2, 2.00, 2.00)]
        [TestCase("", 'z', 3, 1.50, 1.50)]
        public void RandomLetterDiscount(string Name, char specialLetter, int lettertoCheck, double orderTotal, double expected)
        {
            var actual = warmups.RandomLetterDiscount(Name, specialLetter, lettertoCheck, orderTotal);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("mario","mario")]
        [TestCase("wwaluigi", "waluigi")]
        [TestCase("luigii", "luigi")]
        [TestCase("peach", "peach")]
        [TestCase("bowwwwser", "bowwwwser")]
        [TestCase("ttoadd", "toad")]
        public void CheckingForTypos(string firstName, string expected)
        {
            var actual = warmups.CheckingForTypos(firstName);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("aaron", "aaron")]
        [TestCase("eerin", "erin")]
        [TestCase("bill", "bill")]
        [TestCase("william", "william")]
        [TestCase("amylee", "amylee")]
        public void QualityAssurance(string firstName, string expected)
        {
            var actual = warmups.QualityAssurance(firstName);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("jo", "jo")]
        [TestCase("flowbad", "flow")]
        [TestCase("sambadus", "samus")]
        [TestCase("badmetroid", "metroid")]
        [TestCase("aran", "aran")]
        public void NoBadWords(string firstName, string expected)
        {
            var actual = warmups.NoBadWords(firstName);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Ash", "AAsAsh")]
        [TestCase("Misty", "MMiMisMistMisty")]
        [TestCase("Brock", "BBrBroBrocBrock")]
        public void FunnyNameDay(string firstName, string expected)
        {
            var actual = warmups.FunnyNameDay(firstName);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 8, 6, 7, 5, 3, 0, 9 }, 2)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3)]
        [TestCase(new[] { 9, 9, 9, 8, 9, 8, 9, 8, 9, 10 }, 10)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 7, 7 }, 0)]
        public void CustomerSurvey(int[] surveyResults, int expected)
        {
            var actual = warmups.CustomerSurvey(surveyResults);
            Assert.AreEqual(expected, actual);

        }

        [TestCase(new[] { 8, 6, 7, 5, 3, 0, 9, 2 }, false)] //5
        [TestCase(new[] { 1, 2, 3, 4, 5, 7, 8, 5, 10 }, false)] //5
        [TestCase(new[] { 9, 9, 9, 8, 9, 8, 9, 9, 9, 10, 10 }, true)] //9
        [TestCase(new[] { 10, 10 }, true)] //10
        public void AreCustomersHappy(int[] surveyResults, bool expected)
        {
            var actual = warmups.AreCustomersHappy(surveyResults);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 8, 6, 7, 5, 3, 0, 9, 2 }, new[] { 1, 2, 3, 4, 5, 7, 8, 5, 10 }, 5)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 7, 8, 5, 10 }, new[] { 9, 9, 9, 8, 9, 8, 9, 9, 9, 10, 10 }, 7)]
        [TestCase(new[] { 9, 9, 9, 8, 9, 8, 9, 9, 9, 10, 10 },new[] { 9, 9, 9, 8, 9, 8, 9, 9, 9, 10, 10 }, 9)]
        public void WeekendAverage(int[] saturdayResults, int[] sundayResults, double expected)
        {
            var actual = warmups.WeekendAverage(saturdayResults, sundayResults);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 3, 3 }, false)]
        [TestCase(new[] { 10, 3, 6, 5, 3, 6 }, false)]
        [TestCase(new[] { 10, 6, 7, 5, 3, 3, 3, 2 }, true)]
        [TestCase(new[] { 10, 10, 10, 10, 3, 4, 9, 2, 1 }, true)]
        public void TooMuchUnsatisfaction(int[] surveyResults, bool expected)
        {
            var actual = warmups.TooMuchUnsatisfaction(surveyResults);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, true)]
        [TestCase(3, false)]
        [TestCase(13, false)]
        [TestCase(20, true)]
        public void FreshCoffee(int hourofDay, bool expected)
        {
            var actual = warmups.FreshCoffee(hourofDay);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(true, true, 11)]
        [TestCase(false, false, 6)]
        [TestCase(true, false, 8)]
        [TestCase(false, true, 9)]
        public void StaffingNeeds(bool isWinter, bool isWeekend, int expected)
        {
            var actual = warmups.StaffingNeeds(isWinter, isWeekend);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(false, false, false, false)]
        [TestCase(true, true, true, true)]
        [TestCase(false, false, true, true)]
        [TestCase(true, true, false, false)]
        [TestCase(true, false, false, true)]
        [TestCase(false, false, true, true)]
        public void PhoneSupport(bool isStoreOpen, bool isMorning, bool isDistrictManager, bool expected)
        {
            var actual = warmups.PhoneSupport(isStoreOpen, isMorning, isDistrictManager);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3.00, 1, 4, 12, 5, 3, true)]
        [TestCase(3.00, 1, 0, 12, 5, 3, false)]
        [TestCase(5.00, 0, 13, 12, 5, 3, false)]
        [TestCase(5.00, 0, 14, 13, 5, 2, true)]
        public void CashOnly(double itemPrice, int numberDollars, int numberQuarters, int numberDimes, int numberNickels, int numberPennies, bool expected)
        {
            var actual = warmups.CashOnly(itemPrice, numberDollars, numberQuarters, numberDimes, numberNickels, numberPennies);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("software",'w',"----w---")]
        [TestCase("programming",'m',"------mm---")]
        [TestCase("battleship",'z',"----------")]
        [TestCase("puppy",'p',"p-pp-")]
        public void Hangman(string secretWord, char letterGuess, string expected)
        {
            var actual = warmups.Hangman(secretWord, letterGuess);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("software", 'w', 250, 250)]
        [TestCase("craftmanship", 'a', 300, 300)]
        [TestCase("guild", 'z', 5000, 0)]
        [TestCase("puppy", 'p', 600, 1800)]
        public void WheelofFortune(string secretWord, char letterGuess, int pointValue, int expected)
        {
            var actual = warmups.WheelofFortune(secretWord, letterGuess, pointValue);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Christopher",10, false)]
        [TestCase("Meg", 10, true)]
        [TestCase("Louis", 7, true)]
        [TestCase("Stewie", 5, false)]
        [TestCase("Peter", 5, true)]
        [TestCase("", 10, false)]
        public void ValidateStringLength(string userEntry, int maxLength, bool expected)
        {
            var actual = warmups.ValidateStringLength(userEntry, maxLength);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("5",true)]
        [TestCase("Five", false)]
        [TestCase("2147483648", false)]
        [TestCase("ReallyBigNumber", false)]
        [TestCase("8675309", true)]
        public void ValidateInteger(string userEntry, bool expected)
        {
            var actual = warmups.ValidateInteger(userEntry);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1",5, true)]
        [TestCase("6", 5, false)]
        [TestCase("0", 5, false)]
        [TestCase("-1", 5, false)]
        [TestCase("4", 5, true)]
        [TestCase("Gotcha",5,false)]
        public void ValidateIntegerinRange(string userEntry, int maxValue, bool expected)
        {
            var actual = warmups.ValidateIntegerinRange(userEntry, maxValue);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", true)]
        [TestCase("1.05", true)]
        [TestCase("OnePointZeroFive", false)]
        [TestCase("1", true)]
        [TestCase("", false)]
        public void ValidateDouble(string userEntry, bool expected)
        {
            var actual = warmups.ValidateDouble(userEntry);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("3.50", 1.00, 4.00,true)]
        [TestCase(".75", 1.00, 4.00, false)]
        [TestCase("4.75", 1.00, 4.00, false)]
        [TestCase("1.00", 1.00, 4.00, true)]
        [TestCase("4.00", 1.00, 4.00, true)]
        [TestCase("Free", 1.00, 4.00, false)]
        public void ValidateDoubleinRange(string userEntry, double minPrice, double maxPrice, bool expected)
        {
            var actual = warmups.ValidateDoubleinRange(userEntry, minPrice, maxPrice);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("A1",true)]
        [TestCase("AC1", false)]
        [TestCase("123", false)]
        [TestCase("A10", true)]
        [TestCase("A09", true)]
        [TestCase("Z99", true)]
        [TestCase("", false)]
        [TestCase("A", false)]
        [TestCase("ABCDEFG", false)]
        public void ValidateItemEntry(string userEntry, bool expected)
        {
            var actual = warmups.ValidateItemEntry(userEntry);
            Assert.AreEqual(expected, actual);
        }

        string[] productSelections = new string[] { "A1", "A2", "A3", "B1", "B2", "C1", "X23", "Z99" };

        [TestCase("A1", true)]
        [TestCase("AAAAA", false)]
        [TestCase("B2", true)]
        [TestCase("", false)]
        [TestCase("X23", true)]
        public void ValidateSelectionFromArray(string userEntry, bool expected)
        {
            var actual = warmups.ValidateSelectionFromArray(userEntry, productSelections);
            Assert.AreEqual(expected, actual);
        }
    }
}
