using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimulation
{
    public class Game : IGame
    {
        int number_of_players;
        public int entry_rate { get; }
        public int pool { get; set; }
        public int startingPlayer { get; set; }
        public List<Player> players { get; }//wszyscy zapisani gracze
        public List<Player> present { get; set; }//gracze w rozgrywke, którzy nie pasowali
        public GamePhases phases { get; }
        public Game(int l)
        {
            players = new List<Player>();
            present = new List<Player>();
            phases = new GamePhases(this);
            number_of_players = l;
            while ((l--) > 0) players.Add(new Player((number_of_players - l).ToString(), 5000));
            entry_rate = 10;
            startingPlayer = -1;
        }
        public Game() : this(5)
        {
            
        }
        public void game()
        {
            while (players.Count > 1)
            {
                phases.beginning();
                phases.entry_rate();
                phases.puttingPhase();
                phases.matchingPhase();
                phases.puttingPhase();
                phases.showtime();
            }
            Console.Clear();
            Console.WriteLine("Zwyciezca calej gry zostaje gracz {0} z kwota: {1}", players[0].name, players[0].cash);
        }
    }
}
