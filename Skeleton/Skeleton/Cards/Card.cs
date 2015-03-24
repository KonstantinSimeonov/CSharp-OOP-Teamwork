namespace Skeleton.Cards
{
    using System;
    using SampleInterfaces;

    public abstract class Card : ICard
    {
        public string Name
        {
            get { throw new System.NotImplementedException(); }
        }

        public string Description
        {
            get { throw new System.NotImplementedException(); }
        }

        public void Play()
        {
            throw new System.NotImplementedException();
        }
    }
}
