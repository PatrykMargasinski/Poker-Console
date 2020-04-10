using System;
using System.Collections.Generic;
using System.Text;

namespace PokerSimulation
{
    public class Sets : ISets
    {
        public bool poker(List<Card> a)
        {
            if (straight(a) && flush(a)) return true;
            return false;
        }
        public bool flush(List<Card> a)
        {
            char cl = a[0].color;
            for (int i = 0; i < 5; i++) if (a[i].color != cl) return false;
            return true;
        }
        public bool fourOfTheKind(List<Card> a)
        {
            int num = a[1].number; int counter = 0;
            for (int i = 0; i < 5; i++) if (a[i].number == num) counter++;
            if (counter == 4) return true;
            return false;
        }
        public bool straight(List<Card> a)
        {
            for (int i = 0; i < 4; i++) 
                    if (a[i].number != a[i + 1].number + 1) return false;
            return true;
        }
        public bool pair(List<Card> a)
        {
            for (int i = 0; i < 4; i++) if (a[i].number == a[i + 1].number) return true;
            return false;
        }
        public bool threeOfaKind(List<Card> a)
        {
            int num = a[2].number;
            for (int i = 0; i < 3; i++) if (a[i].number == num && a[i + 1].number == num && a[i + 2].number == num) return true;
            return false;
        }

        public bool twoPair(List<Card> a)
        {
            if ((a[0].number == a[1].number && a[2].number == a[3].number) || (a[0].number == a[1].number && a[3].number == a[4].number) || (a[1].number == a[2].number && a[3].number == a[4].number)) return true;
            else return false;
        }
        public bool fullHouse(List<Card> a)
        {
            if (a[0].number == a[1].number && a[3].number == a[4].number && (a[0].number == a[2].number || a[4].number == a[2].number)) return true;
            else return false;
        }
    }
}
