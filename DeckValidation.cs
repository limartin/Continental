using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental
{
    public static class DeckValidation
    {
        /// <summary>
        /// Static method to validate if the subdeck passed is
        /// a third (3 of the same value)
        /// </summary>
        /// <param name="subdeck"></param>
        /// <returns>true if is a third, false if not</returns>
        public static bool IsThird(ICardDeck subdeck)
        {
            if (subdeck == null)
            {
                throw new InvalidProgramException("Null subdeck");
            }

            // minimum number of cards is 3
            if (subdeck.Count < 3)
            {
                return false;
            }

            var first = subdeck.First();
            // iterate over all the cards and if all of them contain the same
            // value then return true, else false
            return  subdeck.All(x => x.Value == first.Value) ? true : false;
        }
        public static bool IsRun(ICardDeck subdeck)
        {
            if (subdeck == null)
            {
                throw new InvalidProgramException("Null subdeck");
            }

            int deckSize = subdeck.Count;
            // minimum number of cards is 4
            if (deckSize < 4)
            {
                return false;
            }

            // ensure all the cards are from the same suit
            var first = subdeck.First();
            // iterate over all the cards and if all of them contain the same
            // suit, if different return false
            if (!subdeck.All(x => x.Suit == first.Suit))
            {
                return false;
            }

            // need to sort per value
            subdeck.Sort();

            // treat as deck of cards so we can access de indexer
            var asDeckCard = subdeck as DeckCards;

            // crate a link list so we can verify the values
            // need to find a better way, that we don't generate
            // the l.l every time we evaluate a run
            LinkedList<Card.CardValue> linkedListValues = new LinkedList<Card.CardValue>();
            foreach (Card.CardValue value in Enum.GetValues(typeof(Card.CardValue)))
            {
                if (value != Card.CardValue.Jocker)
                {
                    linkedListValues.AddLast(value);
                }                
            }

            // if Ace is a low card, then we need to change the logic, 
            // after sorting we need to verify that the last 2 cards
            // if a[n-1] = Ace and a[n-2] != King, then we can assume Ace == 1
            if ( (asDeckCard[deckSize - 1].Value == Card.CardValue.Ace ) && 
                 (asDeckCard[deckSize - 2].Value != Card.CardValue.King) ) 
            {
                // ace == 1

                // skip the compare of the last card, since we assume is the ACE 
                // which should be taken as lowest value
                deckSize--;
            }
            else
            {
                // ace == 14
            }

            first = asDeckCard.First();
            // ensure the values are consecutive
            // get the next index
            var indexInList = linkedListValues.Find(first.Value).Next;

            for (var index = 1; index < deckSize ; index++)
            {
                if (asDeckCard[index].Value != indexInList.Value)
                {
                    return false;
                }
                indexInList = indexInList.Next;
            }
            return true;
        }
    }
}
