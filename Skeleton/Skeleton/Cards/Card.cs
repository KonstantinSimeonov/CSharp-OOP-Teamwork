namespace Skeleton.Cards
{
    using System;
    using SampleInterfaces;

    public abstract class Card : ICard, IFaceDownCard, IParsable
    {

        public bool FaceUp { get; private set; }

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

        private static string Path
        {
            get { throw new NotImplementedException(); }
        }

        private static void Parse(string path)
        {
            throw new NotImplementedException();
        }

        string IParsable.Path
        {
            get { throw new NotImplementedException(); }
        }

        void IParsable.Parse(string path)
        {
            throw new NotImplementedException();
        }
    }
}
