namespace Skeleton.Player
{
    using SampleInterfaces;

    public abstract class Player : IPlayer
    {
        public int LifePoints
        {
            get { throw new System.NotImplementedException(); }
        }

        public System.Collections.Generic.IList<ICard> Hand
        {
            get { throw new System.NotImplementedException(); }
        }

        public void Draw()
        {
            throw new System.NotImplementedException();
        }

        public void PlayCard(ICard card)
        {
            throw new System.NotImplementedException();
        }
    }
}
