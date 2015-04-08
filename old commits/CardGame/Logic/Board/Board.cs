namespace Logic.Board
{
    using Logic.Interfaces;
    using Logic.Cards;
    using Logic.CustomEventArgs;
    using System;
    using System.Collections.Generic;

    public sealed class Board : IBoard, IPlayerSubscriber, IFormSubscriber
    {
        private const int MAX_MONSTERS = 5;
        private const int MAX_EFFECT_CARDS = 5;

        private IList<IMonsterCard> playersMonsters;
        private IList<IMonsterCard> aiMonsters;
        private IList<IManaCostable> playerEffectCards;
        private IList<IManaCostable> aiEffectCards;
        //private IDeck playerDeck;
        //private IDeck aiDeck;
        private IList<ICard> playerGraveyard;
        private IList<ICard> aiGraveyard;

        // Singleton

        private static readonly Board board = new Board(); // assign at compile time

        public static Board GameField // this property returns the only instance of the class that is creatable
        {
            get { return board; }
        }

        private Board() // constructors is private because of singleton
        {
            PlayersMonsters = new List<IMonsterCard>(MAX_MONSTERS);
            PlayerEffectCards = new List<IManaCostable>(MAX_EFFECT_CARDS);
            PlayerGraveyard = new List<ICard>();

            aiMonsters = new List<IMonsterCard>(MAX_MONSTERS);
            aiEffectCards = new List<IManaCostable>(MAX_EFFECT_CARDS);
            aiGraveyard = new List<ICard>();

            PlayerDeck = new Deck();
            AIDeck = new Deck();
            
        }

        public IList<IMonsterCard> PlayersMonsters
        {
            get { return new List<IMonsterCard>(playersMonsters); }
            private set { playersMonsters = value; }
        }

        public IList<IMonsterCard> AIMonsters
        {
            get { return new List<IMonsterCard>(aiMonsters); }
            private set { aiMonsters = value; }
        }

        public IList<IManaCostable> PlayerEffectCards
        {
            get { return new List<IManaCostable>(playerEffectCards); }
            private set { playerEffectCards = value; }
        }

        public IList<IManaCostable> AIEffectCards
        {
            get { return new List<IManaCostable>(aiEffectCards); }
            private set { aiEffectCards = value; }
        }

        public IDeck PlayerDeck
        {
            get;
            private set;
        }

        public IDeck AIDeck
        {
            get;
            private set;
        }

        public IList<ICard> PlayerGraveyard
        {
            get { return new List<ICard>(playerGraveyard); }
            private set { playerGraveyard = value; }
        }

        public IList<ICard> AIGraveyard
        {
            get { return new List<ICard>(aiGraveyard); }
            private set { aiGraveyard = value; }
        }

        private void AddCard(object sender, EventArgs e)
        {
            var args = e as PlayCardArgs;

            if (args.PlayersTurn)
            {
                if (args.PlayedCard as IManaCostable != null)
                {
                    this.playerEffectCards.Add(args.PlayedCard as IManaCostable);
                    return;

                }

                this.playersMonsters.Add(args.PlayedCard as IMonsterCard);
            }
            else
            {
                if (args.PlayedCard as IManaCostable != null)
                {
                    this.aiEffectCards.Add(args.PlayedCard as IManaCostable);
                    return;

                }

                this.aiMonsters.Add(args.PlayedCard as IMonsterCard);
            }
        }

        public void Subscribe(IFormPublisher publisher)
        {
            publisher.PlayCardEvent += this.AddCard;
        }

        public void SubscribeToPlayer(IPlayerPublisher publisher)
        {
            publisher.NotifyBoard += this.AddCard;
        }
    }
}