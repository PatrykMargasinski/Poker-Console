using System;
using System.Collections.Generic;
using System.Text;

namespace PokerSimulation
{
    public class Player
    {
        public string name;
        public List <Card> hand;
        public int cash;
        public bool clear;
        public bool allin;
        public int wagered;
        public long stan;
        public Player(string name, int p)
        {
            hand = new List<Card>();
            this.cash=p;
            this.name=name;
        }
}
}
