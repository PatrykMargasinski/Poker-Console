using System;
using System.Collections.Generic;
using System.Text;

namespace PokerSimulation
{
    public class PlayerMoves : IPlayerMoves
    {
        Game game;
        public PlayerMoves(Game g)
        {
            game = g;
        }
        public void wait(Player g)
        {
            g.clear = true;
        }

        public void put(Player g)
        {
            int st;
            Console.WriteLine("\nIle chcesz postawic: ");
            st = Convert.ToInt32(Console.ReadLine());
            if (g.cash <= st)
            {
                allin(g);
            }
            else
            {
                g.cash -= st;
                g.wagered += st;
                game.pool += st;
                setNotClear();
                g.clear = true;
            }
        }
        public void check(Player g)
        {
            int max = 0;
            foreach (Player gr in game.present)
                if (gr.wagered > max)
                    max = gr.wagered;
            int to_pay = max - g.wagered;
            if (g.cash <= to_pay) allin(g);
            else
            {
                game.pool += to_pay;
                g.wagered += to_pay;
                g.cash -= to_pay;
                g.clear = true;
            }
        }

        public void raise(Player g)
        {
            int max = 0;
            foreach (Player gr in game.present)
                if (gr.wagered > max)
                    max = gr.wagered;
            int do_zaplaty = max - g.wagered;

            int st;
            Console.WriteLine("\nO ile chcesz przebic: ");
            st = Convert.ToInt32(Console.ReadLine());
            g.cash -= (st + do_zaplaty);
            g.wagered += (st + do_zaplaty);
            game.pool += (st + do_zaplaty);
            setNotClear();
            g.clear = true;
        }
        public void allin(Player g)
        {
            g.allin = true;
            setNotClear();
            game.pool += g.cash;
            g.wagered += g.cash;
            g.cash = 0;
            g.clear = true;
        }
        public void pass(Player g)
        {
            game.present.Remove(g);
        }
        public void setNotClear()
        {
            foreach (Player g in game.present)
                if (g.allin == false)
                   g.clear = false;
        }
        public bool all_clear()
        {
            foreach (Player g in game.present)
                if (g.clear == false)
                    return false;
            return true;
        }

        public bool equal_rates()
        {
            int temp = game.present[0].wagered;
            for (int i = 1; i < game.present.Count; i++)
                if (game.present[i].wagered != temp)
                    return false;
            return true;
        }
    }
}
