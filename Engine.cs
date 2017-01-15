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
            TwoThrees = 0,
            // una corrida y una tercia - 7
            OneRunOneThree = 1,
            // dos corridas - 8
            TwoRuns = 2,
            // 3 tercias - 9
            ThreeThree = 3,
            // 2 tercias y una corrida - 10
            TwoThreeOneRun = 4,
            // 2 corridas y una tercia - 11
            OneThreeTwoRun = 5,
            // 3 corridas - 12
            ThreeRuns = 6,
            // 3 tercias y una corrida - 13
            ThreeThreeOneRun = 7,
            // 2 tercias y dos corridas - 14
            TwoThreeTwoRuns  = 8,
            // 1 tercia y 3 corridas - 15
            OneThreeThreeRuns = 9,
            // 4 corridas - 16
            FourRuns = 10
        }

        // number of decks per turn
        private int[] numberOfDecks = { 2, 2, 2, 2, 2, 2, 3, 3, 3, 3 };

        // number of cards to shuffle per round
        private int[] cardPerRoundPerPlayer = { 7, 7, 9, 9, 11, 11, 13, 13, 15, 15, 17 };

        private DeckCards playCards;
        private List<string> playerList;
        private List<PlayerDeck> playersCards;
        private List<BoardCards> boardCards;
        private Rounds currentRound;
        private Stack<Card> discardPile;

        public Engine(List<string> playerList)
        {
            if (playerList == null)
            {
                throw new InvalidProgramException("Null list of players");
            }
            if (playerList.Count < 2)
            {
                throw new InvalidProgramException("At least two players");
            }

            this.playerList = playerList;
            this.playersCards = new List<PlayerDeck>();
            foreach(var player in playerList)
            {
                this.playersCards.Add(new PlayerDeck(player));
            }

            this.boardCards = new List<BoardCards>();
            this.discardPile = new Stack<Card>();
        }

        /// <summary>
        /// Prepare the round
        /// will
        /// 1. Create a deck of playcards based on the number of decks per round
        /// 2. shuffle the cards
        /// 3. deal each player the cards per round
        /// 4. finally add the top most to the discard pile
        /// </summary>
        /// <param name="round"></param>
        public void Initialize(Rounds round)
        {
            // set the current round
            this.currentRound = round;

            // create a deck of cards based on the round
            // by casting the current round to integer gives us the
            // place value so we can calculate how many decks of cards to have
            this.playCards = new DeckCards(
                this.numberOfDecks[(int)this.currentRound]);

            // shuffle the deck
            this.playCards.Shuffle();

            // deal X cards to each player
            // where X is the place value on cards per round
            for (var index = 0;
                index < this.cardPerRoundPerPlayer[(int)this.currentRound];
                index++)
            {
                for (var playerIndex = 0;
                    playerIndex < this.playerList.Count;
                    playerIndex++)
                {
                    // get the next card of the deck and assing to each player
                    // TODO: think of a way to change the start player
                    // on a 2nd tought, shouldn't matter much
                    this.playersCards[playerIndex].AddCard(
                        this.playCards.GetNext());
                }
            }

            // add the next card to the discard 
            this.discardPile.Push(this.playCards.GetNext());
        }
    }
}
