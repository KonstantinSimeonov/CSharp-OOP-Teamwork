namespace Logic.CustomEventArgs
{
    using System;
    using Logic.Interfaces;
    class PlayCardArgs : DrawCardArgs
    {
        public string Path { get; set; }

        public bool FaceUp { get; set; }

        public PlayCardArgs(ICard card, string path, bool faceUp)
            :base(card)
        {
            this.Path = path;
            this.FaceUp = faceUp;
        }
    }
}
