using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental
{
    public interface IEngine
    {
        /// <summary>
        /// Initialize the game engine.
        /// </summary>
        /// <param name="round">Pass object to identify round</param>
        void Initialize(Object round);
        /// <summary>
        /// Returns the player hand
        /// </summary>
        /// <param name="playerIndex">Player Index</param>
        /// <returns>Player Deck</returns>
        PlayerDeck GetPlayerHand(int playerIndex);
        /// <summary>
        /// Shows the topmost discard card
        /// </summary>
        /// <returns></returns>
        Card ShowTopDiscardCard();
        /// <summary>
        /// Removes the topmost discard card
        /// </summary>
        /// <returns></returns>
        Card GetTopDiscardCard();
        /// <summary>
        /// Adds the selected card to the discard pile
        /// </summary>
        /// <param name="card">card to be added</param>
        void AddCardToDiscardPile(Card card);

    }
}
