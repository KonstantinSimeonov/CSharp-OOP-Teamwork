namespace Skeleton.Board
{
    using SampleInterfaces;
    using System.Collections.Generic;

    public class Board : IBoard
    {
        private IList<IMonsterCard> playersMonsters;
        private IList<IMonsterCard> aiMonsters;
        private IList<IManaCostable> playerEffectCards;
        private IList<IManaCostable> aiEffectCards;
        private IDeck playerDeck;
        private IDeck aiDeck;
        private IList<ICard> playerGraveyard;
        private IList<ICard> aiGraveyard;


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
    }
}