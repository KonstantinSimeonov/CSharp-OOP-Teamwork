﻿namespace Logic.Cards
{
    using Logic.Interfaces;
    using System.Collections.Generic;

    public class Deck : IDeck
    {
        private IList<ICard> cards;

        public Deck()
        {
            this.Cards = new List<ICard>();
        }

        public int CardsRemaining
        {
            get { return cards.Count; }
        }

        public IList<ICard> Cards
        {
            get { return cards; }
            private set { cards = value; }
        }

        public ICard NextCard()
        {
            if (this.CardsRemaining == 0)
            {
                // game over
            }

            var nextCard = cards[0];
            cards.RemoveAt(0);
            return nextCard;
        }
    }
}