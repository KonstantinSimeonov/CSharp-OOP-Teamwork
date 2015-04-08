namespace Logic.Player
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Logic.Interfaces;
    using Logic.Cards;
    using Engine.CustomEventArgs;
    using Engine.Delegates;
    

    public abstract class Player : IPlayer
    {
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

        public ICard Draw()
        {
            var card = deck.NextCard();
            hand.Add(card);
            return card;
        }

        public void RemoveCard(ICard card)
        {
            this.hand.Remove(card);
        }

        public void ChangeLifePoints(int by)
        {
            this.LifePoints += by;
        }

        public void PlayCard(ICard card, bool faceUp)
        {
            var asEffectCard = card as IManaCostable;

            (card as IFaceDownCard).SetDown();

            if(asEffectCard == null)
            {
                this.Hand.Remove(card);

                return;
            }

            if (this.ManaPoints >= asEffectCard.ManaCost)
            {
                this.ManaPoints -= asEffectCard.ManaCost;
                this.Hand.Remove(card);
            }
        }

    }
}