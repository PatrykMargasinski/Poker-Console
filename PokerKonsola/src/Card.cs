using System;
using System.Collections.Generic;
using System.Text;

namespace PokerSimulation
{
    public partial class Card
    {

        public int number;
        public char color;

        public Card(int a, char b)
        {
            number = a;
            color = b;
        }
    }
}
