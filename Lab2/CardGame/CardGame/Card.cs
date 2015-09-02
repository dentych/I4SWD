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
        protected int modifier = 1;

        public Card(int cardValue = 1)
        {
            Number = cardValue; // Can be numbers 1-8, 9 is exclusive.
        }

        public int Number { get; set; }
        public int Value
        {
            get { return Number * modifier; }
        }

        public abstract string CardName { get; }
    }

    public class RedCard : Card
    {
        public RedCard(int value) : base(value) { }
        
        public override string CardName
        {
            get { return "Red " + Number.ToString(); }
        }
    }

    public class BlueCard : Card
    {
        public BlueCard(int value) : base(value) { modifier = 2; }

        public override string CardName
        {
            get { return "Blue " + Number.ToString(); }
        }
    }

    public class GreenCard : Card
    {
        public GreenCard(int value): base(value) { modifier = 3; }

        public override string CardName
        {
            get { return "Green " + Number.ToString(); }
        }
    }

    public class YellowCard : Card
    {
        public YellowCard(int value) : base(value) { modifier = 4; }

        public override string CardName
        {
            get { return "Yellow " + Number.ToString(); }
        }
    }
}