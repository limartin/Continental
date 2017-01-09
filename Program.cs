using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards1
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckCards myDeck = new DeckCards(1);
            DeckCards discardDeck = new DeckCards();
            myDeck.Shuffle();
            Card nextCard = null;
            int counter = 1;
            do
            {
                nextCard = myDeck.GetNext();
                if (nextCard != null)
                {
                    discardDeck.AddCard(nextCard);
                    Console.WriteLine("{0}, Card: Value: {1}, Suite: {2}", counter++, nextCard.Value, nextCard.Suit);
                }
            } while (nextCard != null);
            Console.WriteLine("done");

            discardDeck.Shuffle();
            do
            {
                nextCard = discardDeck.GetNext();
                if (nextCard != null)
                {
                    Console.WriteLine("{0}, Card: Value: {1}, Suite: {2}", counter++, nextCard.Value, nextCard.Suit);
                }
            } while (nextCard != null);
            Console.WriteLine("done");

            ICardDeck foo = discardDeck;
            Console.WriteLine("done");

            foreach (Card card in foo)
            {
                Console.WriteLine(" Card: Value: {0}, Suite: {1}", card.Value, card.Suit);
            }

        }
    }
}
