namespace Skeleton.Cards
{
    using Skeleton.Interfaces;
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
            get { return new List<ICard>(cards); }
            private set { cards = value; }
        }

        public ICard NextCard()
        {
            if (this.CardsRemaining == 0)
            {
                // GAME OVER EVENT
            }
            var nextCard = cards[0];
            cards.RemoveAt(0);
            return nextCard;
        }
    }
}