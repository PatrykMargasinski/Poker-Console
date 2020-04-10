using System;
using System.Collections.Generic;
using System.Text;

namespace PokerSimulation
{
    interface IDeck
    {
        void shuffle();
        void giveToDeck(Card temp);
        void giveFromDeck(int ile, Player g);
    }
}
