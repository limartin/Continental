using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental
{
    public class Engine
    {
        public enum Rounds
        {
            // dos tercias - 6
            TwoThrees,
            // una corrida y una tercia - 7
            OneRunOneThree,
            // dos corridas - 8
            TwoRuns,
            // 3 tercias - 9
            ThreeThree,
            // 2 tercias y una corrida - 10
            TwoThreeOneRun,
            // 2 corridas y una tercia - 11
            OneThreeTwoRun,
            // 3 corridas - 12
            ThreeRuns,
            // 3 tercias y una corrida - 13
            ThreeThreeOneRun,
            // 2 tercias y dos corridas - 14
            TwoThreeTwoRuns,
            // 1 tercia y 3 corridas - 15
            OneThreeThreeRuns,
            // 4 corridas - 16
            FourRuns
        }

        // number of decks per turn
        private int[] numberOfDecks = { 2, 2, 2, 2, 2, 2, 3, 3, 3, 3 };

        // number of cards to shuffle per round
        private int[] cardPerRoundPerPlayer = { 7, 7, 9, 9, 11, 11, 13, 13, 15, 15, 17 };

        private DeckCards playCards;
        private List<PlayerDeck> playersCards;

        public Engine(int numberOfPlayers)
        {
            this.playersCards = new List<PlayerDeck>();
        }
    }
}
