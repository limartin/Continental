using Continental;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections;

namespace Continental.Tests
{
    [TestClass()]
    public class DeckCardsTests
    {
        /// <summary>
        /// Ensure we can create an empty deck of cards
        /// </summary>
        [TestMethod()]
        public void DeckCardsEmptyTest()
        {
            var EmptyDeck = new DeckCards();
            Assert.AreEqual(EmptyDeck.Count, 0, "Deck count should be zero");
        }

        /// <summary>
        /// Test the Invalid Deck
        /// </summary>
        [TestMethod()]
        public void DeckCardsSingleDeckInvalid()
        {
            try
            {
                var NonEmptyDeck = new DeckCards(0);
                Assert.Fail("Exception not thown");
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }
        }


        /// <summary>
        /// Count the number of cards, shoud be 52
        /// </summary>
        [TestMethod()]
        public void DeckCardsSingleDeckNoJockers()
        {
            var NonEmptyDeck = new DeckCards(1);
            Assert.AreEqual(NonEmptyDeck.Count, 52, "Deck count should be 52");
        }

        /// <summary>
        /// Count the number of cards including jocker, should be 54
        /// </summary>
        [TestMethod()]
        public void DeckCardsSingleDeckWithJockers()
        {
            var NonEmptyDeck = new DeckCards(1, true);
            Assert.AreEqual(NonEmptyDeck.Count, 54, "Deck count should be 54");
        }

        /// <summary>
        /// Create multiple decks with no jocker
        /// </summary>
        [TestMethod()]
        public void DeckCardsMultipleDecksNoJocker()
        {
            for (int index = 1; index < 10; index++)
            {
                var testDeck = new DeckCards(index);
                Assert.AreEqual(testDeck.Count, 52 * index, "Deck count should be {0}", 52 * index);
            }
        }

        /// <summary>
        /// Create multiple decks with jocker
        /// </summary>
        [TestMethod()]
        public void DeckCardsMultipleDecksJocker()
        {
            for (int index = 1; index < 10; index++)
            {
                var testDeck = new DeckCards(index, true);
                Assert.AreEqual(testDeck.Count, 54 * index, "Deck count should be {0}", 54 * index);
            }
        }

        [TestMethod()]
        public void ValidateEqualDecks()
        {
            var deck1 = new DeckCards(1);
            var deck2 = new DeckCards(1);
            for (int index = 0; index < 52; index++)
            {
                var card1 = deck1.GetNext();
                var card2 = deck2.GetNext();
                Assert.IsTrue(card1 == card2, "decks are not equal");
            }
        }
        [TestMethod()]
        public void ValidateNonEqualDecks()
        {
            var deck1 = new DeckCards(1);
            var deck2 = new DeckCards(1);

            deck2.Shuffle();

            for (int index = 0; index < 52; index++)
            {
                var card1 = deck1.GetNext();
                var card2 = deck2.GetNext();

                if (card1 != card2)
                {
                    Assert.IsTrue(true);
                    return;
                }
            }
            Assert.IsTrue(false, "Decks are the same");
        }


        [TestMethod()]
        public void SortTest()
        {
            var deck = new DeckCards();
            var c1 = new Card(Card.CardValue.Ten, Card.CardSuit.Heart);
            var c2 = new Card(Card.CardValue.Five, Card.CardSuit.Heart);

            deck.AddCard(c1);
            deck.AddCard(c2);
            deck.Sort();

            // ensure that the values are sorted
            Assert.AreEqual(deck.GetNext(), c2);
            Assert.AreEqual(deck.GetNext(), c1);
        }
    }
}