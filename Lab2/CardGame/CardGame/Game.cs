using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Game
    {
        public static Random rand = new Random();

        int currentPlayer = 0;
        int CurrentPlayer {
            get { return currentPlayer; }
            set { currentPlayer = (++currentPlayer) % 4; }
        }
        List<IPlayer> players = new List<IPlayer>();
        Deck deck = new Deck();

        public void NewPlayer(IPlayer player)
        {
            players.Add(player);
        }

        public void DealCardToAllPlayers(int amount = 1)
        {
            foreach (IPlayer p in players)
            {
                deck.DealToPlayer(p, amount);
            }
        }

        public void DealCardToNextPlayer()
        {
            deck.DealToPlayer(players[currentPlayer]);
            currentPlayer++;
        }

        public void PlayersShowHands()
        {
            foreach (IPlayer p in players)
            {
                p.ShowHand();
            }
        }

        public void AnnounceWinner()
        {
            IPlayer highscorePlayer = null;
            int bestScore = 0;

            foreach (IPlayer p in players)
            {
                int score = p.TotalValue();
                if (score > bestScore)
                {
                    bestScore = score;
                    highscorePlayer = p;
                }
            }

            Console.WriteLine("The winner of this game: " + highscorePlayer.Name);
        }
    }
}
