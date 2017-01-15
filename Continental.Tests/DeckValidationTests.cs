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
    public class DeckValidationTests
    {
        [TestMethod]
        public void IsThirdParameter()
        {
            try
            {
                DeckValidation.IsThird(null);
            }
            catch(InvalidProgramException)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod()]
        public void IsThirdTestValid()
        {
            {
                DeckCards validThird = new DeckCards();
                validThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Heart));
                validThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Diamond));
                validThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Club));
                Assert.IsTrue(DeckValidation.IsThird(validThird));
            }
            {
                DeckCards validThird = new DeckCards();
                validThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Heart));
                validThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Diamond));
                validThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Club));
                validThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Spade));
                Assert.IsTrue(DeckValidation.IsThird(validThird));
            }

        }

        [TestMethod()]
        public void IsThirdTestInvalid()
        {
            {
                DeckCards invalidThird = new DeckCards();
                invalidThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Heart));
                invalidThird.AddCard(new Card(Card.CardValue.Two, Card.CardSuit.Diamond));
                invalidThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Club));
                Assert.IsFalse(DeckValidation.IsThird(invalidThird));
            }
            {
                DeckCards invalidThird = new DeckCards();
                invalidThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Heart));
                invalidThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Club));
                Assert.IsFalse(DeckValidation.IsThird(invalidThird));
            }
            {
                DeckCards invalidThird = new DeckCards();
                invalidThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Heart));
                invalidThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Club));
                invalidThird.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Spade));
                invalidThird.AddCard(new Card(Card.CardValue.Two, Card.CardSuit.Club));
                Assert.IsFalse(DeckValidation.IsThird(invalidThird));
            }
        }

        [TestMethod]
        public void IsRunParameter()
        {
            try
            {
                DeckValidation.IsRun(null);
            }
            catch (InvalidProgramException)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod()]
        public void IsRunTestValid()
        {
            {
                // 2 - 4
                DeckCards validRun = new DeckCards();
                validRun.AddCard(new Card(Card.CardValue.Two, Card.CardSuit.Heart));
                validRun.AddCard(new Card(Card.CardValue.Three, Card.CardSuit.Heart));
                validRun.AddCard(new Card(Card.CardValue.Five, Card.CardSuit.Heart));
                validRun.AddCard(new Card(Card.CardValue.Four, Card.CardSuit.Heart));
                Assert.IsTrue(DeckValidation.IsRun(validRun));
            }
            {
                // unsorted desk 2-4
                DeckCards validRun = new DeckCards();
                validRun.AddCard(new Card(Card.CardValue.Five, Card.CardSuit.Heart));
                validRun.AddCard(new Card(Card.CardValue.Two, Card.CardSuit.Heart));
                validRun.AddCard(new Card(Card.CardValue.Four, Card.CardSuit.Heart));
                validRun.AddCard(new Card(Card.CardValue.Three, Card.CardSuit.Heart));
                Assert.IsTrue(DeckValidation.IsRun(validRun));
            }
            {
                // 4 - 7
                DeckCards validRun = new DeckCards();
                validRun.AddCard(new Card(Card.CardValue.Four, Card.CardSuit.Diamond));
                validRun.AddCard(new Card(Card.CardValue.Five, Card.CardSuit.Diamond));
                validRun.AddCard(new Card(Card.CardValue.Six, Card.CardSuit.Diamond));
                validRun.AddCard(new Card(Card.CardValue.Seven, Card.CardSuit.Diamond));
                Assert.IsTrue(DeckValidation.IsRun(validRun));
            }
            {
                // Ace as a high card
                DeckCards validRun = new DeckCards();
                validRun.AddCard(new Card(Card.CardValue.Jack, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.Queen, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.King, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Spade));
                Assert.IsTrue(DeckValidation.IsRun(validRun));
            }
            {
                // 10 - K
                DeckCards validRun = new DeckCards();
                validRun.AddCard(new Card(Card.CardValue.Ten, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.Jack, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.Queen, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.King, Card.CardSuit.Spade));
                Assert.IsTrue(DeckValidation.IsRun(validRun));
            }

            {
                // more than 4 cards
                DeckCards validRun = new DeckCards();
                validRun.AddCard(new Card(Card.CardValue.Eight, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.Nine, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.Ten, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.Jack, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.Queen, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.King, Card.CardSuit.Spade));
                Assert.IsTrue(DeckValidation.IsRun(validRun));
            }
        }

        [TestMethod()]
        public void IsRunAceLowCard()
        {
            {
                // Ace as a low card
                DeckCards validRun = new DeckCards();
                validRun.AddCard(new Card(Card.CardValue.Ace, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.Two, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.Three, Card.CardSuit.Spade));
                validRun.AddCard(new Card(Card.CardValue.Four, Card.CardSuit.Spade));
                Assert.IsTrue(DeckValidation.IsRun(validRun));
            }
        }

        [TestMethod()]
        public void IsRunTestInvalid()
        {
            {
                // consecutive, different suit
                DeckCards invalidRun = new DeckCards();
                invalidRun.AddCard(new Card(Card.CardValue.Two, Card.CardSuit.Heart));
                invalidRun.AddCard(new Card(Card.CardValue.Three, Card.CardSuit.Club));
                invalidRun.AddCard(new Card(Card.CardValue.Five, Card.CardSuit.Heart));
                invalidRun.AddCard(new Card(Card.CardValue.Four, Card.CardSuit.Heart));
                Assert.IsFalse(DeckValidation.IsRun(invalidRun));
            }
            {
                // not consecutive
                DeckCards invalidRun = new DeckCards();
                invalidRun.AddCard(new Card(Card.CardValue.Two, Card.CardSuit.Heart));
                invalidRun.AddCard(new Card(Card.CardValue.Four, Card.CardSuit.Heart));
                invalidRun.AddCard(new Card(Card.CardValue.Jack, Card.CardSuit.Heart));
                invalidRun.AddCard(new Card(Card.CardValue.Eight, Card.CardSuit.Heart));
                Assert.IsFalse(DeckValidation.IsRun(invalidRun));
            }
            {
                // short run
            }
        }
    }
}