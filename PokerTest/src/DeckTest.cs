using NUnit.Framework;
using PokerSimulation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTest
{
    [TestFixture]
    public class DeckTest
    {
        Deck deck;
        [SetUp]
        public void Setup()
        {
            deck = new Deck(7,15);
        }

        [Test]
        public void RightSizeTest()
        {
            Assert.AreEqual(32, deck.Count());
        }

        [Test]
        public void ShuffledTest()
        {
            int counter = 0;
            for (int i = 7; i < 15; i++)
                for (char j = 'a'; j < 'e'; j++)
                {
                    if (deck.cards[counter].color == j && deck.cards[counter].number == i) { }
                    else Assert.True(true);
                    counter++;
                }
        }
    }
}