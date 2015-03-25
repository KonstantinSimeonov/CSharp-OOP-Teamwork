namespace Skeleton.Board
{
    using SampleInterfaces;

    public class Board : IBoard
    {

        public System.Collections.Generic.IList<IMonsterCard> PlayersMonsters
        {
            get { throw new System.NotImplementedException(); }
        }

        public System.Collections.Generic.IList<IMonsterCard> AIMonsters
        {
            get { throw new System.NotImplementedException(); }
        }

        public System.Collections.Generic.IList<Cards.EffectCard> PlayerEffectCards
        {
            get { throw new System.NotImplementedException(); }
        }

        public System.Collections.Generic.IList<Cards.EffectCard> AIEffectCards
        {
            get { throw new System.NotImplementedException(); }
        }

        public IDeck PlayerDeck
        {
            get { throw new System.NotImplementedException(); }
        }

        public IDeck AIDeck
        {
            get { throw new System.NotImplementedException(); }
        }

        public System.Collections.Generic.IList<ICard> PlayerGraveyard
        {
            get { throw new System.NotImplementedException(); }
        }

        public System.Collections.Generic.IList<ICard> AIGraveyard
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}