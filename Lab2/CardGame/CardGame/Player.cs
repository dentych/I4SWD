using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public interface IPlayer
    {
        string Name { get; set; }

        void DealCard(Card card);
        int TotalValue();
        void ShowHand();
    }

    public class Player : IPlayer
    {
        public string Name { get; set; }
        List<Card> cards = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }

        public void DealCard(Card card)
        {
            cards.Add(card);
        }

        public int TotalValue()
        {
            int totalValue = 0;

            foreach (Card card in cards)
            {
                totalValue += card.Value;
            }

            return totalValue;
        }

        public void ShowHand()
        {
            Console.WriteLine("Showing hand for player: {0}.", Name);

            foreach (Card card in cards)
            {
                Console.WriteLine(card.CardName);
            }

            Console.WriteLine("Total value of hand: {0}.\n", TotalValue().ToString());
        }
    }

    public class WeakPlayer : IPlayer
    {
        private int cardsHold = 0;
        List<Card> cards = new List<Card>();
        public string Name { get; set; }

        public void DealCard(Card card)
        {
            cards.Add(card);
            if (++cardsHold > 3)
            {
                cards.RemoveAt(0);
                cardsHold--;
            }
        }

        public int TotalValue()
        {
            int totalValue = 0;

            foreach (Card card in cards)
            {
                totalValue += card.Value;
            }

            return totalValue;
        }

        public void ShowHand()
        {
            Console.WriteLine("Showing hand for player: {0}.", Name);

            foreach (Card card in cards)
            {
                Console.WriteLine(card.CardName);
            }

            Console.WriteLine("Total value for hand: {0}", TotalValue());
        }
    }
}