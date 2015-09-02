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

        public Deck() {
            GenerateDeck();
            PrintDeck();
        }

        public void DealToPlayer(IPlayer player, int amountofcards = 1)
        {
            Random rand = new Random();
            
            for (int i = 0; i < amountofcards; i++)
            {
                int index = rand.Next(0, cards.Count);
                player.DealCard(cards[index]);
                cards.RemoveAt(index);
            }
        }

        public void PrintDeck()
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card.CardName);
            }
        }

        private void GenerateDeck(int cardId = 0, int value = 1)
        {
            if (value > 8)
            {
                value = 1;
                cardId++;
            }

            Card card = NewCard(cardId, value);
            if (card != null)
            {
                cards.Add(card);
                GenerateDeck(cardId, value+1);
            }
        }

        private Card NewCard(int cardId, int value)
        {
            switch (cardId)
            {
                case 0:
                    return new RedCard(value);
                case 1:
                    return new BlueCard(value);
                case 2:
                    return new GreenCard(value);
                case 3:
                    return new YellowCard(value);
                default:
                    return null;
            }
        }
    }
}
