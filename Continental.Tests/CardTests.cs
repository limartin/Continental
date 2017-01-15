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
    public class CardTests
    {
        [TestMethod()]
        public void ValidCardTest()
        {
            try
            {
                Card card = new Card(Card.CardValue.Two, Card.CardSuit.Club);
                Assert.IsTrue(true);
            }
            catch (InvalidOperationException)
            {
                Assert.Fail();
            }
        }
        [TestMethod()]
        public void ValidJockerTest()
        {
            try
            {
                Card card = new Card(Card.CardValue.Jocker, Card.CardSuit.None);
                Assert.IsTrue(true);
            }
            catch (InvalidOperationException)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void InvalidJockerTest()
        {
            try
            {
                Card card = new Card(Card.CardValue.Jocker, Card.CardSuit.Club);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod()]
        public void InvalidCardTest()
        {
            try
            {
                Card card = new Card(Card.CardValue.Two, Card.CardSuit.None);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Card c1 = new Card(Card.CardValue.Ace, Card.CardSuit.Diamond);
            Card c2 = new Card(Card.CardValue.Ace, Card.CardSuit.Diamond);
            Assert.IsTrue(c1.Equals(c2), "Card should be equal"); ;
        }

        [TestMethod()]
        public void EqualsNegativeTest()
        {
            Card c1 = new Card(Card.CardValue.Ace, Card.CardSuit.Diamond);
            Card c2 = new Card(Card.CardValue.Ace, Card.CardSuit.Club);
            Assert.IsFalse(c1.Equals(c2), "Card should not be equal"); ;
        }

        [TestMethod()]
        public void EqualsNullTest()
        {
            Card c1 = new Card(Card.CardValue.Ace, Card.CardSuit.Diamond);
            Card c2 = null;
            Assert.IsFalse(c1.Equals(c2), "should return false"); ;
        }

        [TestMethod()]
        public void CompareToTestGreaterThan()
        {
            Card c1 = new Card(Card.CardValue.Ace, Card.CardSuit.Diamond);
            Card c2 = new Card(Card.CardValue.Two, Card.CardSuit.Club);
            Assert.AreEqual(c1.CompareTo(c2),1, "Card should not be equal, 1"); ;
        }
        [TestMethod()]
        public void CompareToTestEqual()
        {
            Card c1 = new Card(Card.CardValue.Two, Card.CardSuit.Diamond);
            Card c2 = new Card(Card.CardValue.Two, Card.CardSuit.Club);
            Assert.AreEqual(c1.CompareTo(c2), 0, "Card should be equal, 0"); ;
        }
        [TestMethod()]
        public void CompareToTestLessThan()
        {
            Card c1 = new Card(Card.CardValue.Two, Card.CardSuit.Diamond);
            Card c2 = new Card(Card.CardValue.Four, Card.CardSuit.Club);
            Assert.AreEqual(c1.CompareTo(c2), -1, "Card should not be equal, -1"); ;
        }
        [TestMethod()]
        public void CompareToTestNull()
        {
            Card c1 = new Card(Card.CardValue.Ace, Card.CardSuit.Diamond);
            Card c2 = null;
            Assert.AreEqual(c1.CompareTo(c2), 1, "Card should not be equal, 1"); ;
        }
    }
}