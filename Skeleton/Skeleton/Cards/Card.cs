namespace Skeleton.Cards
{
    using System;
    using SampleInterfaces;

    public abstract class Card : ICard, IFaceDownCard
    {

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public abstract void Play();

        public void SetDown()
        {
            throw new NotImplementedException();
        }

        public void Flip()
        {
            throw new NotImplementedException();
        }
    }
}
