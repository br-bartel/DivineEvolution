using DevOps_game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class HelpTest
    {
        [TestMethod]
        public void TestHelp()
        {
            string expected = "Select an item to interact with by typing the text contained by one set of square brackets";
            string actual = HelpMessage.Help();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStuff()
        {
            Dictionary<string, List<string>> arguments = new Dictionary<string, List<string>>
            {
                {"word", new List<string>() { "" } }
            };
            Game.input = "next";
            string currentInput = "";
            Game.currentState = new State();
            Game.currentState.playerName = "jfk";
            Game.currentState.cycle = 1;
            List<string> actual = Game.checker(arguments, out currentInput);
            List<string> expected = new List<string>() { "" };

            Assert.AreEqual(Game.input, "next");
            Assert.AreEqual(expected.Count, actual.Count);
        }
        [TestMethod]
        public void MapTest() // have to comment out console write to test only logic
        {
            Game.currentState = new State();
            Game.currentState.playerName = "jfk";
            Game.currentState.cycle = 1;
            Game.currentState.location = "Town Square";

            Map.DisplayMap(0);

            string expected = "TOWN SQUARE";

            Assert.AreEqual(expected, Map.TownText);
        }
    }
}
