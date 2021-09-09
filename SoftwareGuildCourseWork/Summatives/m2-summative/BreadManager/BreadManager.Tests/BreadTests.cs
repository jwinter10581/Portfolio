using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BreadManager.Controller;
using BreadManager.Data;
using BreadManager.Models;
using BreadManager.View;

namespace BreadManager.Tests
{
    [TestFixture]
    public class BreadTests
    {
        [TestCase("1", BreadType.Baguette)]
        [TestCase("5", BreadType.Cornbread)]
        [TestCase("10", BreadType.White)]
        public void EnumReturnsBreadType(string choice, BreadType expected)
        {
            UserInputValidation userIV = new UserInputValidation();

            Assert.AreEqual(expected, userIV.ReadEnum(choice));
        }
    }
}
