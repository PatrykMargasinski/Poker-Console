using System;
using System.Collections.Generic;
using System.Text;

namespace PokerSimulation
{
    public partial class Card
    {

        public static bool operator ==(Card a1, Card a2)
        {
            return (a1.number == a2.number);
        }
        public static bool operator !=(Card a1, Card a2)
        {
            return !(a1==a2);
        }
        public static bool operator !=(Card a, int a1)
        {
            return (a.number != a1);
        }

        public static bool operator ==(Card a, int a1)
        {
            return (a.number == a1);
        }
        public static bool operator >(Card a1, Card a2)
        {
            return (a1.number > a2.number);
        }
        public static bool operator <(Card a1, Card a2)
        {
            return (a1.number < a2.number);
        }

        public static bool Equals(Card a1, Card a2)
        {
            return a1 == a2;
        }

    }
}
