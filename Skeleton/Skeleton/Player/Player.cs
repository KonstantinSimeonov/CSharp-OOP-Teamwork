namespace Skeleton.Player
{
    using SampleInterfaces;
    using Skeleton.Cards;
    using System.Collections.Generic;

    public abstract class Player : IPlayer
    {
        private const int LIFE_POINTS = 4000;
        private const int MANA_POINTS = 100;

        private IDeck deck;
        private IList<ICard> hand;

        public Player()
        {
            this.LifePoints = Player.LIFE_POINTS;
            this.ManaPoints = Player.MANA_POINTS;
            this.Hand = new List<ICard>(6);
            this.Deck = new Deck();
        }

        public int LifePoints { get; private set; }

        public int ManaPoints { get; private set; }

        public IDeck Deck
        {
            get { return deck; }
            private set { deck = value; }
        }

        public IList<ICard> Hand
        {
            get { return new List<ICard>(hand); }
            private set { hand = value; }
        }

        public void Draw()
        {
            hand.Add(deck.NextCard());
        }

        public void PlayCard(ICard card)
        {
            var store = card;
            this.Hand.Remove(card);
            // EVENT HERE
        }

    }
}
