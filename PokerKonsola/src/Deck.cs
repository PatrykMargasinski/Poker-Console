using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimulation
{
    public class Deck : IDeck
    {
        public List<Card> cards = new List<Card>();
        public Deck(int a, int b)
        {
            cards = new List<Card>();
            for (int i = a; i < b; i++)
                for (char j = 'a'; j < 'e'; j++)
                    cards.Add(new Card(i, j));
            shuffle();
        }
        public void shuffle()
        {
            var rnd = new Random();
            cards = cards.OrderBy(item => rnd.Next()).ToList();
        }

        public int Count()
        {
            return cards.Count;
        }

        public void giveFromDeck(int ile, Player g)
        {
            Card temp;
            for (int i = 0; i < ile; i++)
            {
                temp = cards[0];
                cards.RemoveAt(0);
                g.hand.Add(temp);
            }
        }
        public void giveToDeck(Card temp)
        {
            cards.Add(temp);
        }
    }
}
