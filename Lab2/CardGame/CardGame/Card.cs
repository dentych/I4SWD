using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public interface ICard
    {
        /**
        \brief Card's number.
        */
        int Number { get; set; }

        /**
        \brief Card's value based on the card's number and modifier.
        */
        int Value { get; }

        /**
        \brief Color of the card plus its value. 
        */
        string CardName { get; }
    }

    public abstract class Card : ICard
    {
        private int cardValue = 1;
        protected int modifier = 1;

        public Card()
        {
            cardValue = Game.rand.Next(1, 9); // Can be numbers 1-8, 9 is exclusive.
        }

        public int Number
        {
            get { return cardValue; }
            set { cardValue = value; }
        }

        public int Value
        {
            get { return cardValue * modifier; }
        }

        public abstract string CardName { get; }
    }

    public class RedCard : Card
    {
        public override string CardName
        {
            get { return "Red " + Number.ToString(); }
        }
    }

    public class BlueCard : Card
    {
        public BlueCard() { modifier = 2; }

        public override string CardName
        {
            get { return "Blue " + Number.ToString(); }
        }
    }

    public class GreenCard : Card
    {
        public GreenCard() { modifier = 3; }

        public override string CardName
        {
            get { return "Green " + Number.ToString(); }
        }
    }

    public class YellowCard : Card
    {
        public YellowCard() { modifier = 4; }

        public override string CardName
        {
            get { return "Yellow " + Number.ToString(); }
        }
    }
}