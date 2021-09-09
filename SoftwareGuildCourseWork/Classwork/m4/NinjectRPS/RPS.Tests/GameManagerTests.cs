using Ninject;
using NUnit.Framework;
using RPS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Tests
{
    [TestFixture]
    public class GameManagerTests
    {
        [Test]
        public void PaperPropertyInjectionTests()
        {
            var kernel = new StandardKernel();
            kernel.Load(new AlwaysPaperModule());


            var gm = kernel.Get<GameManager2>();

            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Rock).Player1Result);
            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Paper).Player1Result);
            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Scissors).Player1Result);
        }

        [Test]
        public void PaperMethodInjectionTests()
        {
            var kernel = new StandardKernel();
            kernel.Load(new AlwaysPaperModule());


            var gm = kernel.Get<GameManager3>();

            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Rock).Player1Result);
            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Paper).Player1Result);
            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Scissors).Player1Result);
        }
    }
}
