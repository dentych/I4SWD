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
            game.NewPlayer(new Player("Dennis"));
            game.NewPlayer(new Player("Far"));
            game.NewPlayer(new Player("Hanne"));
            game.NewPlayer(new WeakPlayer("Hory shet"));

            game.DealCardToAllPlayers(5);

            game.PlayersShowHands();
            game.AnnounceWinner();
        }
    }
}
