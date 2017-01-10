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
    public class PlayerDeckTests
    {
        [TestMethod()]
        public void PointsTestEmptyDeck()
        {
            PlayerDeck play = new PlayerDeck();
            Assert.AreEqual(play.Points(), 0, "Emtpy deck should be 0");
        }
        [TestMethod()]
        public void PointsTestSingleCard()
        {
            PlayerDeck play = new PlayerDeck();
            Card card = new Card(Card.CardValue.Two, Card.CardSuit.Heart);
            play.AddCard(card);
            Assert.AreEqual(play.Points(), 2, "Deck should be 2");
        }

        [TestMethod()]
        public void PointsTestMultipleCard()
        {
            PlayerDeck play = new PlayerDeck();
            Card card1 = new Card(Card.CardValue.Two, Card.CardSuit.Heart);
            Card card2 = new Card(Card.CardValue.Three, Card.CardSuit.Diamond);
            Card card3 = new Card(Card.CardValue.Four, Card.CardSuit.Club);
            Card card4 = new Card(Card.CardValue.Five, Card.CardSuit.Spade);
            play.AddCard(card1);
            play.AddCard(card2);
            play.AddCard(card3);
            play.AddCard(card4);
            Assert.AreEqual(play.Points(), 14, "Deck should be 14");
        }

        [TestMethod()]
        public void PointsTestMultipleCardFigures()
        {
            PlayerDeck play = new PlayerDeck();
            Card card1 = new Card(Card.CardValue.Jack, Card.CardSuit.Heart);
            Card card2 = new Card(Card.CardValue.Queen, Card.CardSuit.Diamond);
            Card card3 = new Card(Card.CardValue.King, Card.CardSuit.Club);
            Card card4 = new Card(Card.CardValue.Ace, Card.CardSuit.Spade);
            play.AddCard(card1);
            play.AddCard(card2);
            play.AddCard(card3);
            play.AddCard(card4);
            Assert.AreEqual(play.Points(), 45, "Deck should be 45");
        }

        [TestMethod()]
        public void JockerPoint()
        {
            PlayerDeck play = new PlayerDeck();
            Card card1 = new Card(Card.CardValue.Jocker, Card.CardSuit.None);
            play.AddCard(card1);
            Assert.AreEqual(play.Points(), 20, "Deck should be 20");
        }
    }
}