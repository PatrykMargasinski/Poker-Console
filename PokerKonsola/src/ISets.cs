using System;
using System.Collections.Generic;
using System.Text;

namespace PokerSimulation
{
    interface ISets
    {
        bool poker(List<Card> a);
        bool flush(List<Card> a);
        bool fourOfTheKind(List<Card> a);
        bool straight(List<Card> a);
        bool pair(List<Card> a);
        bool threeOfaKind(List<Card> a);
        bool twoPair(List<Card> a);
        bool fullHouse(List<Card> a);
    }
}
