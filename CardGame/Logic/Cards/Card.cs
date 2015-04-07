namespace Logic.Cards
{
    using System;
    using System.IO;
    using System.Drawing;
    using System.Collections.Generic;
    using Logic.Interfaces;

    public abstract class Card : ICard, IFaceDownCard
    {
        private string imagePath;

        public Card(string name, string description, string path, CardTypes type)
        {
            this.Name = name;
            this.Description = description;
            this.Path = path;
            this.Type = type;
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


        public CardTypes Type { get; private set; }
    }
}
