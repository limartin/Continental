using System;

namespace Continental
{
    public class Card : IComparable<Card>, IEquatable<Card>
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
            if ((value == CardValue.Jocker)&&(suit!= CardSuit.None))
            {
                throw new InvalidOperationException("Invalid Jocker");
            }
            if ((suit == CardSuit.None) && (value != CardValue.Jocker))
            {
                throw new InvalidOperationException("Invalid Card");
            }
            this.value = value;
            this.suit = suit;
        }

        public CardValue Value { get { return this.value; } }
        public CardSuit Suit { get { return this.suit; } }

        /// <summary>
        /// Override of the equality opereator
        /// </summary>
        /// <param name="a">Card A</param>
        /// <param name="b">Card B</param>
        /// <returns>true if are the same</returns>
        public static bool operator == (Card a, Card b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.Value == b.Value && a.Suit == b.Suit;
        }

        /// <summary>
        /// Override of the inequality operaetor
        /// </summary>
        /// <param name="a">Card A</param>
        /// <param name="b">Card B</param>
        /// <returns></returns>
        public static bool operator != (Card a, Card b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Override of the Equal operator
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Card objAsCard = obj as Card;
            if (objAsCard == null) return false;
            else return Equals(objAsCard);
        }

        /// <summary>
        /// override of GetHashCode
        /// </summary>
        /// <returns>int as hashcode from base</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// CompareTo to order cards per value
        /// </summary>
        /// <param name="other">Other card to compare</param>
        /// <returns>Value comparison</returns>
        public int CompareTo(Card other)
        {
            if (other == null)
                return 1;

            else
                return this.Value.CompareTo(other.Value);

        }

        /// <summary>
        /// Comparator for cards
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Card other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return (this.Value.Equals(other.Value)  && this.Suit.Equals(other.Suit));
            }
        }
    }
}
