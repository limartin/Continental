using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental
{
    public class PlayerDeck : DeckCards
    {
        private string player;

        public PlayerDeck(string player)
        {
            if (string.IsNullOrEmpty(player))
            {
                throw new InvalidProgramException("Player name shouln't be empty");
            }
            this.player = player;
        }

        public string Player
        {
            get
            {
                return this.player;
            }
        }

        public int Points()
        {
            int value = 0;
            foreach (Card card in base.cards)
            {
                if ((card.Value >= Card.CardValue.Two) && (card.Value <= Card.CardValue.Nine))
                {
                    value += Convert.ToInt32(card.Value);
                }
                if ((card.Value >= Card.CardValue.Jack) && (card.Value <= Card.CardValue.King))
                {
                    value += 10;
                }
                if (card.Value == Card.CardValue.Ace)
                {
                    value += 15;
                }
                if (card.Value == Card.CardValue.Jocker)
                {
                    value += 20;
                }
            }
            return value;
        }
    }
}
