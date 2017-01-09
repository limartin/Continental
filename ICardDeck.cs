using System.Collections;

namespace Continental
{
    /// <summary>
    /// Interface for deck of cards
    /// </summary>
    interface ICardDeck : IEnumerable
    {
        /// <summary>
        /// Need to implement Shuffle
        /// </summary>
        void Shuffle();
    }
}
