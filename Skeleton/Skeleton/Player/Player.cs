namespace Skeleton.Player
{
    using System;
    using System.Collections.Generic;
    using Skeleton.Interfaces;
    using Skeleton.Cards;
    using Skeleton.CustomEventArgs;
    

    public abstract class Player : IPlayer
    {
        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler RaisePlay = delegate { };

        private const int LIFE_POINTS = 4000;
        private const int MANA_POINTS = 100;

        private IDeck deck;
        private IList<ICard> hand;

        public Player(IDeck deck)
        {
            this.LifePoints = Player.LIFE_POINTS;
            this.ManaPoints = Player.MANA_POINTS;
            this.Hand = new List<ICard>(6);
            this.Deck = deck;
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
            var asEffectCard = card as IManaCostable;

            if(asEffectCard == null)
            {
                this.Hand.Remove(card);
                this.RaisePlay(this, new PlayCardArgs(card));

                return;
            }

            if (this.ManaPoints >= asEffectCard.ManaCost)
            {
                this.ManaPoints -= asEffectCard.ManaCost;
                this.Hand.Remove(card);
                this.RaisePlay(this, new PlayCardArgs(card));
            }
        }

    }
}
