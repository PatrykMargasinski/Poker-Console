using System;
using System.Collections.Generic;
using System.Text;

namespace PokerSimulation
{
    interface IPlayerMoves
    {
        void wait(Player g);
        void check(Player g);
        void pass(Player g);
        void raise(Player g);
        void allin(Player g);
        void put(Player g);
    }
}
