using Microsoft.Practices.Unity;
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
            var container = new UnityContainer();
            InjectionProperty injectionProperty = new InjectionProperty("ChoiceBehavior", new AlwaysPaper());
            container.RegisterType<GameManager2>(injectionProperty);


            var gm = container.Resolve<GameManager2>();

            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Rock).Player1Result);
            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Paper).Player1Result);
            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Scissors).Player1Result);
        }

        [Test]
        public void PaperMethodInjectionTests()
        {
            var container = new UnityContainer();
            InjectionMethod injectionMethod = new InjectionMethod("SetChoiceBehavior", new AlwaysPaper());
            container.RegisterType<GameManager3>(injectionMethod);


            var gm = container.Resolve<GameManager3>();

            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Rock).Player1Result);
            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Paper).Player1Result);
            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Scissors).Player1Result);
        }
    }
}
