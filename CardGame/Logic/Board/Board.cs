namespace Logic.Board
{
    using Logic.Interfaces;
    using Logic.Cards;
    using System.Collections.Generic;
    using Game.CustomExeptions;

    public sealed class Board : IBoard
    {
        private const string PlayerMonsterCardsCountExceptionMessageFormat = "Player can not have more than {0} monster cards on field";
        private const string PlayerEffectCardsCountExceptionMessageFormat = "Player can not have more than {0} effect cards on field";
        private const string AIMonsterCardsCountExceptionMessageFormat = "AI can not have more than {0} monster cards on field";
        private const string AIEffectCardsCountExceptionMessageFormat = "AI can not have more than {0} effect cards on field";

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

        private static readonly IBoard board = new Board(); // assign at compile time

        public static IBoard GameField // this property returns the only instance of the class that is creatable
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

        public void CheckFieldCardsValidity()
        {
            if (this.PlayersMonsters.Count > Board.MAX_MONSTERS)
            {
                throw new BoardCradExeption(string.Format(Board.PlayerMonsterCardsCountExceptionMessageFormat, Board.MAX_MONSTERS));
            }

            if (this.PlayerEffectCards.Count > Board.MAX_EFFECT_CARDS)
            {
                throw new BoardCradExeption(string.Format(Board.PlayerEffectCardsCountExceptionMessageFormat, Board.MAX_EFFECT_CARDS));
            }

            if (this.AIMonsters.Count > Board.MAX_MONSTERS)
            {
                throw new BoardCradExeption(string.Format(Board.AIMonsterCardsCountExceptionMessageFormat, Board.MAX_MONSTERS));
            }
            if (this.AIEffectCards.Count > Board.MAX_EFFECT_CARDS)
            {
                throw new BoardCradExeption(string.Format(Board.AIEffectCardsCountExceptionMessageFormat, Board.MAX_EFFECT_CARDS));
            }
        }
    }
}