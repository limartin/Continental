using Microsoft.VisualStudio.TestTools.UnitTesting;
using Continental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch (InvalidOperationException e)
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
            var NonEmptyDeck = new DeckCards(1,true);
            Assert.AreEqual(NonEmptyDeck.Count, 54, "Deck count should be 54");
        }

        /// <summary>
        /// Create multiple decks
        /// </summary>
        [TestMethod()]
        public void DeckCardsMultipleDecks()
        {
            for (int index = 1; index < 10; index++)
            {
                var testDeck = new DeckCards(index);
                Assert.AreEqual(testDeck.Count, 52*index, "Deck count should be {0}",52*index);
            }
        }
    }
}