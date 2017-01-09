using System;

namespace Continental
{
    class Program
    {
        /// <summary>
        /// Sample program for test (for now)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Create a deck of cards (52)
            DeckCards myDeck = new DeckCards(1);

            // create a discard deck :)
            DeckCards discardDeck = new DeckCards();

            // shuffle the initial deck
            myDeck.Shuffle();
            Card nextCard = null;
            int counter = 1;
            do
            {
                // get the topmost card and add to the discard deck
                nextCard = myDeck.GetNext();
                if (nextCard != null)
                {
                    discardDeck.AddCard(nextCard);
                    // display
                    Console.WriteLine("{0}, Card: Value: {1}, Suite: {2}", counter++, nextCard.Value, nextCard.Suit);
                }
            } while (nextCard != null);
            Console.WriteLine("done");

            // shuffle the discard deck
            discardDeck.Shuffle();
            do
            {
                nextCard = discardDeck.GetNext();
                if (nextCard != null)
                {
                    // display
                    Console.WriteLine("{0}, Card: Value: {1}, Suite: {2}", counter++, nextCard.Value, nextCard.Suit);
                }
            } while (nextCard != null);
            Console.WriteLine("done");

            // test the Interface and enumerator
            ICardDeck foo = discardDeck;
            Console.WriteLine("done");

            foreach (Card card in foo)
            {
                Console.WriteLine(" Card: Value: {0}, Suite: {1}", card.Value, card.Suit);
            }
        }
    }
}
