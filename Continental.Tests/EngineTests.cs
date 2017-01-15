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
    }
}