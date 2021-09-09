using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Calculator.BLL;
using NUnit.Framework;

namespace SG.Calculator.Tests
{
    [TestFixture]
    public class SimpleMathTests
    {

        [Test]
        public void IntegerDivision()
        {
            SimpleMath math = new SimpleMath();
            int result = math.Divide(5, 2);

            Assert.AreEqual(2, result);
        }

        [TestCase (4,2,2)]
        [TestCase (13,6,2)]
        [TestCase (-20,5,-4)]
        public void IntegerDivision1(int x, int y, int expected)
        {
            SimpleMath math = new SimpleMath();
            int result = math.Divide(x, y);

            Assert.AreEqual(expected, result);
        } 
        
        [Test]
        public void DivideByZeroTest()
        {
            SimpleMath math = new SimpleMath();
            Assert.Throws<DivideByZeroException>(() => math.Divide(5, 0));
        }
    }
}
