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
    }
}