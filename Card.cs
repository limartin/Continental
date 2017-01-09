using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards1
{
    public class Card
    {
        public enum CardSuit
        {
            Heart = 1 ,
            Diamond = 2,
            Club = 3,
            Spade = 4,
            None = 0
        }

        public enum CardValue
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5, 
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = 15,
            Jocker = 20
        }

        private CardValue value;
        private CardSuit suit;

        public Card(CardValue value, CardSuit suit)
        {
            this.value = value;
            this.suit = suit;
        }

        public CardValue Value { get { return this.value; } }
        public CardSuit Suit { get { return this.suit; } }
    }
}
