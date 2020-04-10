using NUnit.Framework;
using PokerSimulation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTest
{
    [TestFixture]
    public class PlayerMovesTest
    {
        Game game;
        PlayerMoves pm;
        Player p;
        Player p2;
        [SetUp]
        public void Setup()
        {
            game = new Game();
            pm = new PlayerMoves(game);
            p = new Player("Testowy",5000);
            p2 = new Player("Testowy2", 5000);
            game.present.Add(p);
            game.present.Add(p2);
        }
        [Test]
        public void waitTest()
        {
            pm.wait(p);
            Assert.True(p.clear);
        }
        [Test]
        public void passTest()
        {
            pm.pass(p);
            Assert.AreEqual(game.present.Count,1);
        }
        [Test]
        public void allinTest()
        {
            pm.allin(p);
            Assert.AreEqual(p.cash,0);
        }


    }
}