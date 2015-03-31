namespace Skeleton.Cards
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using SampleInterfaces;

    public abstract class Card : ICard, IFaceDownCard, IParsableCard
    {
        private string imagePath;

        public Card(string name, string description, string path)
        {
            this.Name = name;
            this.Description = description;
            this.Path = path;
        }

        public bool FaceUp { get; protected set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public abstract void Play();

        public void SetDown()
        {
            FaceUp = false;
        }

        public void Flip()
        {
            FaceUp = true;
            // implement effect
        }

        public string Path
        {
            get { return imagePath; }
            private set { imagePath = value; }
        }

        public abstract IList<ICard> Parse(string path);

        public override string ToString()
        {
            return string.Format("{0}\n{1}\n{2}", this.Name, this.GetType(), this.Description);
        }
    }
}
