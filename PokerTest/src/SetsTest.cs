using NUnit.Framework;
using PokerSimulation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTest
{
    [TestFixture]
    public class SetsTest
    {
        Sets sets;
        List<Card> hand;
        SetsMain main;
        [SetUp]
        public void Setup()
        {
            sets = new Sets();
            main = new SetsMain();
            hand = new List<Card>();
        }

        [Test]
        public void Testing()
        {
            Assert.True(true);
        }

        [Test]
        public void KingPokerTest()
        {
            for (int i = 10; i <= 10; i++)
            {
                for (char k = 'a'; k <= 'd'; k++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        hand.Add(new Card(i + j, k));
                    }
                    Assert.True(main.setName(main.setScore(hand))=="Poker krolewski");
                    hand.Clear();
                }
            }
        }

        [Test]
        public void PokerTest()
        {
            for(int i=7;i<=9;i++)
            {
                for (char k = 'a'; k <= 'd'; k++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        hand.Add(new Card(i + j, k));
                    }
                    hand.Reverse();
                    Assert.True(sets.poker(hand));
                    hand.Clear();
                }
            }
        }
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }


        [Test]
        public void FourOfTheKindTest()
        {
            for (int i = 7; i < 15; i++)
            {
                hand.Clear();
                for(char j='a';j<='d';j++)
                {
                    hand.Add(new Card(i, j));
                }
                hand.Add(new Card(1, 'a'));
                Assert.True(sets.fourOfTheKind(hand));
            }
        }
        [Test]
        public void StraightTest()
        {
            Random ran = new Random();
            for (int n = 7; n <= 9; n++)
            {
                for (int k = 0; k < 10; k++)
                {
                    for (int j = 0; j < 5; j++)
                        hand.Add(new Card(n + j, (char)ran.Next('a','d')));
                    hand.Reverse();
                    Assert.True(sets.straight(hand));
                    hand.Clear();
                }
            }
        }
        [Test]
        public void FullHouseTest()
        {
            var all = new List<int>();
            Random ran = new Random();
            for (int j = 7; j < 15; j++) all.Add(j);
            var result = GetPermutations(all, 2).ToList();
            result.RemoveAll(a => a.ToList().Count != 2);
            foreach (var l in result)
            {
                for (int i = 0; i < 2; i++) hand.Add(new Card(l.ToList()[0], (char)ran.Next('a', 'd')));
                for (int i = 0; i < 3; i++) hand.Add(new Card(l.ToList()[1], (char)ran.Next('a', 'd')));
                Assert.True(sets.fullHouse(hand));
                hand.Clear();
            }
        }

        [Test]
        public void TwoPairTest()
        {
            var all = new List<int>();
            Random ran = new Random();
            for (int j = 7; j < 15; j++) all.Add(j);
            var result = GetPermutations(all, 2).ToList();
            result.RemoveAll(a => a.ToList().Count != 2);
            foreach (var l in result)
            {
                for (int i = 0; i < 2; i++) hand.Add(new Card(l.ToList()[0], (char)ran.Next('a', 'd')));
                for (int i = 0; i < 2; i++) hand.Add(new Card(l.ToList()[1], (char)ran.Next('a', 'd')));
                hand.Add(new Card(1, 'e'));
                Assert.True(sets.twoPair(hand));
                hand.Clear();
            }
        }

    }
}