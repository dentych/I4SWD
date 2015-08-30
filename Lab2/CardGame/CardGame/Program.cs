using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.NewPlayer("Dennis");
            game.NewPlayer("Far");
            game.NewPlayer("Hanne");

            game.DealCardToAllPlayers(5);

            game.PlayersShowHands();
            game.AnnounceWinner();
        }
    }
}
