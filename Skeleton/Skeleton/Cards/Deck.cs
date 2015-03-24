namespace Skeleton.Cards
{
    using SampleInterfaces;

    public class Deck : IDeck
    {
        public System.Collections.Generic.IList<ICard> Hand
        {
            get { throw new System.NotImplementedException(); }
        }

        public ICard NextCard()
        {
            throw new System.NotImplementedException();
        }
    }
}