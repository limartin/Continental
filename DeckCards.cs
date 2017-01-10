using System;
using System.Collections;
using System.Collections.Generic;

namespace Continental
{
    public class DeckCards : ICardDeck
    {
        private int numberDecks;
        private bool includeJockers;
        protected List<Card> cards;
        private const int maxNumberJockersPerDeck = 2;
        private int index;

        /// <summary>
        /// Returns the number of cards
        /// </summary>
        public int Count
        {
            get
            {
                return this.cards.Count;
            }
        }

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Empty constructor, creates an empty deck
        /// </summary>
        public DeckCards()
        {
            this.cards = new List<Card>();
            this.index = 0;
        }

        /// <summary>
        /// Constructor to "autogenerate" an ordered set of cards
        /// </summary>
        /// <param name="numberDecks">Specify how manu decks of cards can be created</param>
        /// <param name="includeJockers">Flag to add jockers to the deck</param>
        public DeckCards(int numberDecks, bool includeJockers = false) : this()
        {
            if (numberDecks < 1)
            {
                throw new InvalidOperationException("Need to specify a value > 0");
            }
            this.numberDecks = numberDecks;
            this.includeJockers = includeJockers;
            
            CreateDeck();
        }

        /// <summary>
        /// Fill the Deck of cards
        /// </summary>
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

        /// <summary>
        /// Method to shuffle the current deck of cards
        /// </summary>
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

        /// <summary>
        /// Retrieve the topmost card of the deck
        /// </summary>
        /// <returns>Topmost card, null if no cards left</returns>
        public Card GetNext()
        {
            if (index == this.cards.Count)
            {
                return null;
            }
            return this.cards[this.index++];
        }

        /// <summary>
        /// Add a card to the deck
        /// </summary>
        /// <param name="aCard">Card to be added</param>
        public void AddCard(Card aCard)
        {
            this.cards.Add(aCard);
        }

        /// <summary>
        /// Enumerator required to fullfill the IEnumerable contract
        /// </summary>
        /// <returns>IEnumerator of the Intenal List</returns>
        public IEnumerator GetEnumerator()
        {
            return this.cards.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
    }
}
