using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimulation
{
    public class SetsMain : ISetsMain
    {
        Sets ukl;
        SetsScore wyn;
        public SetsMain()
        {
            ukl = new Sets();
            wyn = new SetsScore();
        }
        public string setName(long a)
        {
            if (a != 91400000000)
                a /= 10000000000;
            switch (a)
            {
                case 91400000000: return "Poker krolewski"; break;
                case 9: return "Poker"; break;
                case 8: return "Kolor"; break;
                case 7: return "Kareta"; break;
                case 6: return "Full"; break;
                case 5: return "Strit"; break;
                case 4: return "Trojka"; break;
                case 3: return "Dwie pary"; break;
                case 2: return "Para"; break;
                case 1: return "Wysoka karta"; break;
            }
            throw new Exception("No combination");
        }
        public long setScore(List <Card> a)
        {
            a = a.OrderByDescending(i => i.number).ToList();
            if (ukl.poker(a)) return wyn.poker(a);
            if (ukl.flush(a)) return wyn.flush(a);
            if (ukl.fourOfTheKind(a)) return wyn.fourOfTheKind(a);
            if (ukl.fullHouse(a)) return wyn.fullHouse(a);
            if (ukl.straight(a)) return wyn.straight(a);
            if (ukl.threeOfaKind(a)) return wyn.threeOfaKind(a);
            if (ukl.twoPair(a)) return wyn.twoPair(a);
            if (ukl.pair(a)) return wyn.pair(a);
            return wyn.highCard(a);
        }

    }
}
