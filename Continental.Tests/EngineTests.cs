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
    public class EngineTests
    {
        [TestMethod()]
        public void EngineTest()
        {
            {
                // null list
                List<string> nullList = null;
                try
                {
                    Engine playEngine = new Engine(null);
                    Assert.Fail();
                }
                catch (InvalidProgramException)
                {
                    Assert.IsTrue(true);
                }
            }
            {
                // empty list
                List<string> empty = new List<string>();
                try
                {
                    Engine playEngine = new Engine(empty);
                    Assert.Fail();
                }
                catch (InvalidProgramException)
                {
                    Assert.IsTrue(true);
                }
            }
            {
                // valid list
                List<string> validList = new List<string>() { "player1", "player2" };
                try
                {
                    Engine playEngine = new Engine(validList);
                    Assert.IsTrue(true);
                }
                catch (InvalidProgramException)
                {
                    Assert.Fail();
                }
                catch (Exception)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void InitializeTest()
        {
            List<string> validList = new List<string>() { "player1", "player2" };
            try
            {
                Engine playEngine = new Engine(validList);
                playEngine.Initialize(Engine.Rounds.TwoThrees);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetPlayerHandTest()
        {
            List<string> validList = new List<string>() { "player1", "player2" };
            try
            {
                Engine playEngine = new Engine(validList);
                playEngine.Initialize(Engine.Rounds.TwoThrees);
                var player1 = playEngine.GetPlayerHand(0);
                var player2 = playEngine.GetPlayerHand(1);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ShowTopDiscardCardTest()
        {
            List<string> validList = new List<string>() { "player1", "player2" };
            try
            {
                Engine playEngine = new Engine(validList);
                playEngine.Initialize(Engine.Rounds.TwoThrees);
                var card = playEngine.ShowTopDiscardCard();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetTopDiscardCardTest()
        {
            List<string> validList = new List<string>() { "player1", "player2" };
            try
            {
                Engine playEngine = new Engine(validList);
                playEngine.Initialize(Engine.Rounds.TwoThrees);
                var card = playEngine.GetTopDiscardCard();
                var nullcard = playEngine.GetTopDiscardCard();
                Assert.IsNull(nullcard, "card should be null");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void AddCardToDiscardPileTestValid()
        {
            List<string> validList = new List<string>() { "player1", "player2" };
            try
            {
                Engine playEngine = new Engine(validList);
                playEngine.Initialize(Engine.Rounds.TwoThrees);
                var card = playEngine.GetTopDiscardCard();
                var testcard = new Card(Card.CardValue.Ace, Card.CardSuit.Club);
                playEngine.AddCardToDiscardPile(testcard);
                var readcard = playEngine.ShowTopDiscardCard();
                Assert.AreEqual(testcard, readcard, "Card should be the same");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void AddCardToDiscardPileTestInvalid()
        {
            List<string> validList = new List<string>() { "player1", "player2" };
            try
            {
                Engine playEngine = new Engine(validList);
                playEngine.Initialize(Engine.Rounds.TwoThrees);
                playEngine.AddCardToDiscardPile(null);
            }
            catch (InvalidProgramException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}