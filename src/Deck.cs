using CardCademyGame.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCademyGame
{
    public class Deck
    {
        private List<Card> cards;

        public Deck(List<Card> cardsToUse)
        {
            this.cards = cardsToUse;
        }

        public Card DrawCard()
        {
            var card = this.cards[RandomGenerator.Instance.Next(0, this.cards.Count)];
            this.cards.Remove(card);
            return card;
        }
    }
}
