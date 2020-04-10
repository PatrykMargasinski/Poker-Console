using System;
using System.Collections.Generic;
using System.Text;

namespace PokerSimulation
{
    class SetsScore : ISetsScore
    {
        public long twoPair(List<Card> a)
        {
            if (a[2].number == a[3].number) return (30000000000 + (100000000 * a[0].number) + (1000000 * a[2].number) + (10000 * a[4].number));//33221
            if (a[2].number == a[3].number) return (30000000000 + (100000000 * a[2].number) + (1000000 * a[4].number) + (10000 * a[0].number));//32211
            return (30000000000 + (100000000 * a[0].number) + (1000000 * a[4].number) + (10000 * a[2].number));//33211
        }

        public long fullHouse(List<Card> a)
        {
            return (60000000000 + (100000000 * a[2].number) + (1000000 * (a[0] != a[3] ? a[0] : a[4]).number));
        }

        public long fourOfTheKind(List<Card> a)
        {
            return (70000000000 + (100000000 * a[2].number));
        }

        public long flush(List<Card> a)
        {
            return (80000000000 + (100000000 * a[0].number) + (1000000 * a[1].number) + (10000 * a[2].number) + (100 * a[3].number) + (1 * a[4].number));
        }

        public long pair(List<Card> a)
        {
            if (a[0].number == a[1].number) return (20000000000 + (100000000 * a[1].number) + (1000000 * a[2].number) + (10000 * a[3].number) + (100 * a[4].number));
            if (a[1].number == a[2].number) return (20000000000 + (100000000 * a[1].number) + (1000000 * a[0].number) + (10000 * a[3].number) + (100 * a[4].number));
            if (a[2].number == a[3].number) return (20000000000 + (100000000 * a[2].number) + (1000000 * a[0].number) + (10000 * a[1].number) + (100 * a[4].number));
            if (a[3].number == a[4].number) return (20000000000 + (100000000 * a[4].number) + (1000000 * a[0].number) + (10000 * a[1].number) + (100 * a[2].number));
            throw (new Exception("No return"));
        }

        public long poker(List<Card> a)
        {
            return (90000000000 + (100000000 * a[0].number));
        }

        public long straight(List<Card> a)
        {
            return (50000000000 + (100000000 * a[0].number));
        }

        public long threeOfaKind(List<Card> a)
        {
            if (a[2].number == a[0].number) return (40000000000 + (100000000 * a[2].number) + (1000000 * a[3].number) + (10000 * a[4].number));
            if (a[1].number == a[3].number) return (40000000000 + (100000000 * a[2].number) + (1000000 * a[0].number) + (10000 * a[4].number));
            if (a[2].number == a[4].number) return (40000000000 + (100000000 * a[2].number) + (1000000 * a[0].number) + (10000 * a[1].number));
            throw (new Exception("No return"));
        }

        public long highCard(List<Card> a)
        {
            return (10000000000 + (100000000 * a[0].number) + (1000000 * a[1].number) + (10000 * a[2].number) + (100 * a[3].number) + (1 * a[4].number));
        }
    }
}
