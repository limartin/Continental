using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards1
{
    public class DeckCards : ICardDeck
    {
        private int numberDecks;
        private bool includeJockers;
        private List<Card> cards;
        private const int maxNumberJockersPerDeck = 2;
        private int index;

        public DeckCards()
        {
            this.cards = new List<Card>();
            this.index = 0;
        }
        public DeckCards(int numberDecks, bool includeJockers = false) : this()
        {
            this.numberDecks = numberDecks;
            this.includeJockers = includeJockers;
            CreateDeck();
        }

        private void CreateDeck()
        {
            for (int deck = 0; deck < this.numberDecks; deck++)
            {
                foreach (Card.CardSuit suit in Enum.GetValues(typeof(Card.CardSuit)))
                {
                    // skip the none suite (for jocker)
                    if ((suit == Card.CardSuit.None)) continue;
                    foreach (Card.CardValue value in Enum.GetValues(typeof(Card.CardValue)))
                    {
                        // skip the jocker, will add later
                        if (value == Card.CardValue.Jocker) continue;
                        Card aCard = new Card(value, suit);
                        cards.Add(aCard);
                    }
                }

                if (includeJockers)
                {
                    for (int counter = 0; counter < maxNumberJockersPerDeck; counter++)
                    {
                        Card jocker = new Card(Card.CardValue.Jocker, Card.CardSuit.None);
                        cards.Add(jocker);
                    }
                }
            }
        }

        public void Shuffle()
        {
            index = 0;
            int numberCards = this.cards.Count;
            Random random = new Random();

            while (numberCards > 1)
            {
                int location = (random.Next(0, numberCards) % numberCards);
                numberCards--;
                Card card = this.cards[location];
                this.cards[location] = this.cards[numberCards];
                this.cards[numberCards] = card;
            }
        }

        public Card GetNext()
        {
            if (index == this.cards.Count)
                return null;
            return this.cards[this.index++];
        }

        public void AddCard(Card aCard)
        {
            this.cards.Add(aCard);
        }

        public IEnumerator GetEnumerator()
        {
            return this.cards.GetEnumerator();
        }
    }
}
