using System.Collections;
using System.Collections.Generic;

namespace Continental
{
    /// <summary>
    /// Interface for deck of cards
    /// </summary>
    public interface ICardDeck : IEnumerable, ICollection, IEnumerable<Card>
    {
        /// <summary>
        /// Need to implement Shuffle
        /// </summary>
        void Shuffle();

        /// <summary>
        /// Need to implement Sort
        /// </summary>
        void Sort();
    }
}
