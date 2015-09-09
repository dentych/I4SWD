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
        int Number { get; }

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

        public int Number { get; private set; }
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
            get { return "Red\t" + Number.ToString() + " (" + Value + ")"; }
        }
    }

    public class BlueCard : Card
    {
        public BlueCard(int value) : base(value) { modifier = 2; }

        public override string CardName
        {
            get { return "Blue\t" + Number.ToString() + " (" + Value + ")"; }
        }
    }

    public class GreenCard : Card
    {
        public GreenCard(int value): base(value) { modifier = 3; }

        public override string CardName
        {
            get { return "Green\t" + Number.ToString() + " (" + Value + ")"; }
        }
    }

    public class YellowCard : Card
    {
        public YellowCard(int value) : base(value) { modifier = 4; }

        public override string CardName
        {
            get { return "Yellow\t" + Number.ToString() + " (" + Value + ")"; }
        }
    }

    public class GoldCard : Card
    {
        public GoldCard(int value) : base(value) { modifier = 5; }

        public override string CardName
        {
            get { return "Gold\t" + Number.ToString() + " (" + Value + ")"; }
        }
    }
}