using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimulation
{
    public class GamePhases : IGamePhases
    {
        Game game {get; set;}
        PlayerMoves moves { get; }
        SetsMain set { get; }
        Deck deck { get; }
        public GamePhases(Game gra)
        {
            this.game = gra;
            moves = new PlayerMoves(gra);
            this.set = new SetsMain();
            deck = new Deck(7,15);
        }
        void schedule()
        {
            Console.WriteLine("Pierwszy: Gracz " + game.players[game.startingPlayer].name);
            Console.WriteLine("Pula: {0}\nLiczba kart w talii: {1}", game.pool, deck.Count());
            foreach (Player g in game.present)
            {
                Console.WriteLine("\nGracz {0}\nKwota: {1}\nPostawione: {2}", g.name, g.cash, g.wagered);
                Console.Write("Karty: ");
                foreach (Card k in g.hand)
                    Console.Write(" {0}{1}", k.number, k.color);
                Console.WriteLine("\nWynik: {0}\nPunkty: {1}", set.setName(g.stan), g.stan);
            }
        }
        public void showtime()
        {
            Console.Clear();
            schedule();
            Console.WriteLine("Czas sprawdzania\n");
            long max = 0;
            max = game.present.Max(g => g.stan);
            game.present.RemoveAll(g => g.stan != max);
            Console.WriteLine("Zwyciezcy dostaja po {0}.\nA są nimi", game.pool / game.present.Count);
            foreach (Player g in game.present)
            {
                Console.WriteLine("Gracz {0} z kombinacją {1}", g.name, g.stan);
                g.cash += game.pool / game.present.Count;
            }
            game.pool = 0;
            game.present.Clear();
            foreach (Player g in game.players)
            {
                foreach (Card k in g.hand)
                {
                    deck.giveToDeck(k);
                }
                g.hand.Clear();
                if (g.cash <= 0)
                {
                    Console.WriteLine("\nGracz {0} nie ma juz pieniedzy by oplacic stawke wejsciowa wiec odpada", g.name);
                }
            }
            Console.WriteLine("Wciśnij Enter");
            Console.ReadKey();
        }

        public void beginning()
        {
            for (int i = 0; i < game.players.Count; i++)
            {
                game.present.Add(game.players[i]);
                game.present[i].clear = false;
                game.present[i].wagered = 0;
                game.present[i].allin = false;
            }
            game.startingPlayer++;
            if (game.startingPlayer >= game.players.Count)
                game.startingPlayer = 0;
            game.pool = 0;
            deck.shuffle();
        }
        public void entry_rate()
        {
            foreach (Player g in game.present)
            {
                g.cash -= game.entry_rate;
                g.wagered += game.entry_rate;
                game.pool += game.entry_rate;
                deck.giveFromDeck(5, g);
                g.stan = set.setScore(g.hand);
            }
        }

        public void puttingPhase()
        {
            int choice;
            int i = game.startingPlayer;
            moves.setNotClear();
            Console.Clear();
            while (((!moves.all_clear()) || (!moves.equal_rates())) && (game.present.Count != 1))
            {
                Console.WriteLine("Czas stawianki!\n");
                schedule();
                if (game.present[i].allin != true)
                {
                    Console.WriteLine("\n\nGraczu {0}\n", game.present[i].name);
                    if (moves.equal_rates())
                    {
                        Console.WriteLine("1. Czekaj\n2. Postaw\n3. Allin\n4. Pas\nTwoj wybor:");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                moves.wait(game.present[i]);
                                break;
                            case 2:
                                moves.put(game.present[i]);
                                break;
                            case 3:
                                moves.allin(game.present[i]);
                                break;
                            case 4:
                                moves.pass(game.present[i]);
                                i--;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("1. Sprawdz\n2. Przebij\n3. Allin\n4. Pass\nTwoj wybor:");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                moves.check(game.present[i]);
                                break;
                            case 2:
                                moves.raise(game.present[i]);
                                break;
                            case 3:
                                moves.allin(game.present[i]);
                                break;
                            case 4:
                                moves.pass(game.present[i]);
                                i--;
                                break;
                        }
                    }
                }
                i++;
                if (i >= game.present.Count)
                    i = 0;
                Console.Clear();
            }
            schedule();
            Console.WriteLine("\nKoniec\n");
        }

        public void matchingPhase()
        {
            if (game.present.Count != 1)
                for (int i = 0; i < game.present.Count; i++)
                {
                    Console.Clear();
                    Console.WriteLine("Czas dobieranki!\n");
                    schedule();
                    string a;
                    Console.WriteLine("\n\nGraczu {0}\nCzas wymienic karty. Jak chcesz je wymienic (np. 11101)", game.present[(i + game.startingPlayer) % game.present.Count].name);
                    a = Convert.ToString(Console.ReadLine());
                    deal(game.present[(i + game.startingPlayer) % game.present.Count], a);
                }
        }
        void deal(Player g, string k)
        {
            if (k.Length < 5)
            {
                int temp = 5 - k.Length;
                for (int i = 0; i < temp; i++) k += '0';
            }
            int licznik = 0;
            for (int i = 0; i < 5; i++)
            {
                if (k[i] != '0')
                {
                    var temp = g.hand[i - licznik];
                    g.hand.RemoveAt(i - licznik);
                    deck.giveToDeck(temp);
                    licznik++;
                }
            }
            deck.giveFromDeck(licznik, g);
            g.stan = set.setScore(g.hand);
        }
    }
}
