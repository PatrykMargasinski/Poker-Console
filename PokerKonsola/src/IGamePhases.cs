using System;
using System.Collections.Generic;
using System.Text;

namespace PokerSimulation
{
    interface IGamePhases
    {
        void beginning();
        void entry_rate();
        void puttingPhase();
        void matchingPhase();
        void showtime();
    }
}
