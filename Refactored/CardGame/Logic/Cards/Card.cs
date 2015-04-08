namespace Logic.Cards
{
    using System.Drawing;
    using System.Collections.Generic;
    using Logic.Interfaces;

    public abstract class Card : ICard, IFaceDownCard
    {
        private string imagePath;
        

        public Card(string name, string description, string path, CardTypes type, Image image = null)
        {
            this.Name = name;
            this.Description = description;
            this.Path = path;
            this.CardImage = image;
            this.CardImage.Tag = this.Path;
            this.Type = type;
            this.FaceUp = true;
        }

        public Image CardImage { get; private set; }

        public bool FaceUp { get; protected set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

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

        public CardTypes Type { get; private set; }
    }
}
