namespace Logic.Player
{
    using System;
    using System.Collections.Generic;
    using Logic.Interfaces;
    using Logic.Cards;
    using Logic.CustomEventArgs;
    using Logic.Delegates;
    

    public abstract class Player : IPlayer, IPublisher
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

        public void Subscribe(IPublisher publisher)
        {
            publisher.Raise += this.Draw;
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

        public void Draw(object sender, EventArgs e)
        {
            var args = e as PlayCardArgs;
            if (args == null)
                throw new InvalidCastException("eba si makata");


            var drawn = deck.NextCard();
            args.PlayedCard = drawn;
            hand.Add(drawn);
            //Raise(this, new PlayCardArgs(drawn));
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


        public event EventRaiser Raise;
    }
}
