using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace Battleship.Tests
{
    [TestFixture]
    public class CoordinateTests
    {
        [TestCase ("A1", 1, 1, 0)]
        [TestCase("B9", 2, 9, 0)]
        [TestCase("J7", 10, 7, 0)]
        [TestCase("D5", 4, 5, 0)]
        public void PromptCoordinateReturnsCorrectly(string input, int expectedX, int expectedY, int initialCoordinate)
        {
            Coordinate actual = new Coordinate(initialCoordinate, initialCoordinate);

            actual = actual.AcquireCoordinateFromUser(input);

            Coordinate expected = new Coordinate(expectedX, expectedY);

            Assert.AreEqual(expected, actual);
        }
    }
}
