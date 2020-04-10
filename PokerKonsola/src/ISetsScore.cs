using System;
using System.Collections.Generic;
using System.Text;

namespace PokerSimulation
{
    interface ISetsScore
    {
        long poker(List<Card> a);
        long flush(List<Card> a);
        long fourOfTheKind(List<Card> a);
        long straight(List<Card> a);
        long pair(List<Card> a);
        long threeOfaKind(List<Card> a);
        long twoPair(List<Card> a);
        long fullHouse(List<Card> a);
        long highCard(List<Card> a);
    }
}
