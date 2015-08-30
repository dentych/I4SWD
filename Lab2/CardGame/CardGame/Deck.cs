using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Deck
    {
        List<Card> cards = new List<Card>();

        public Deck() { }

        public void DealToPlayer(Player player, int amountofcards = 1)
        {
            if (amountofcards < 1) throw new Exception("Amount of cards must be greater than 0!");

            if (amountofcards > 1)
            {
                for (int i = 0; i < amountofcards; i++)
                {
                    player.DealCard(GenerateCard());
                }
            }
            else
            {
                player.DealCard(GenerateCard());
            }
        }

        private Card GenerateCard()
        {
            int number = Game.rand.Next(4);
            switch (number)
            {
                case 0:
                    return new RedCard();
                case 1:
                    return new BlueCard();
                case 2:
                    return new GreenCard();
                case 3:
                    return new YellowCard();
                default:
                    throw new Exception("Generation of card went wrong. (Switch)");
            }

            throw new Exception("Generation of card went wrong and returned nothing.");
        }
    }
}
