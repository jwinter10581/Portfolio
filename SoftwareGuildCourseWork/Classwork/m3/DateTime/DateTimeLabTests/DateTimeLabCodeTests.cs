using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateTimeLab;
using NUnit.Framework;

namespace DateTimeLabTests
{
    [TestFixture]
    public class DateTimeLabCodeTests
    {
        DateTimeLabCode _dateTimeCode;

        [SetUp]
        public void TestSetup()
        {
            _dateTimeCode = new DateTimeLabCode();
        }

        [Test]
        public void GetTheDateTodayTest()
        {
            var expected = DateTime.Today;
            var actual = _dateTimeCode.GetTheDateToday();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(12, 25, 2015, "12/25/15")]
        [TestCase(4, 1, 2017, "4/1/17")]
        public void GetShortDateStringFromParamatersTest(int month, int day, int year, string expected)
        {
            var actual = _dateTimeCode.GetShortDateStringFromParamaters(month, day, year);
            Assert.AreEqual(expected,actual);
        }

        [TestCase("10/1/1971", "10/1/1971")]
        [TestCase("09.09.99", "9/9/1999")]
        [TestCase("January 27, 2006", "1/27/2006")]
        [TestCase("13 Aug 1994", "8/13/1994")]
        public void GetDateTimeObjectFromStringTest(string date, string expected)
        {
            var actual = _dateTimeCode.GetDateTimeObjectFromString(date).ToShortDateString();
            Assert.AreEqual(expected,actual);
        }

        [TestCase("12/4/2005 1:55 pm", "12.04.2005 01:55 PM")]
        [TestCase("April 4, 2010 3:30 PM", "04.04.2010 03:30 PM")]
        [TestCase("9 Jun 2002 5:05 am", "06.09.2002 05:05 AM")]
        public void GetFormatedDateStringTest(string testDate, string expected)
        { 
            var actual = _dateTimeCode.GetFormatedDateString(testDate);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("01/01/2005", "July 1, 2005")]
        [TestCase("4/20/2005", "October 20, 2005")]
        [TestCase("12/31/2005", "June 30, 2006")]
        public void GetDateInSixMonthsTest(string testDate, string expected)
        {
            var actual = _dateTimeCode.GetDateInSixMonths(testDate);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("04/01/2005", "March 2, 2005")]
        [TestCase("10/20/2005", "September 20, 2005")]
        [TestCase("06/30/2006", "May 31, 2006")]
        public void GetDateThirtyDaysInPastTest(string testDate, string expected)
        {
            var actual = _dateTimeCode.GetDateThirtyDaysInPast(testDate);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetNextWednesdays1()
        {
            var actual = _dateTimeCode.GetNextWednesdays(3, "January 1, 2016");

            Assert.AreEqual(3, actual.Length);

            var first = new DateTime(2016, 1, 6);
            Assert.AreEqual(actual[0], first);

            var second = new DateTime(2016, 1, 13);
            Assert.AreEqual(actual[1], second);

            var third = new DateTime(2016, 1, 20);
            Assert.AreEqual(actual[2], third);
        }

        [Test]
        public void GetNextWednesdays2()
        {
            var actual = _dateTimeCode.GetNextWednesdays(5, "February 3, 2016");

            Assert.AreEqual(5, actual.Length);

            var first = new DateTime(2016, 2, 3);
            Assert.AreEqual(actual[0], first);

            var second = new DateTime(2016, 2, 10);
            Assert.AreEqual(actual[1], second);

            var third = new DateTime(2016, 2, 17);
            Assert.AreEqual(actual[2], third);

            var fourth = new DateTime(2016, 2, 24);
            Assert.AreEqual(actual[3], fourth);

            var fifth = new DateTime(2016, 3, 2);
            Assert.AreEqual(actual[4], fifth);
        }
    }
}
