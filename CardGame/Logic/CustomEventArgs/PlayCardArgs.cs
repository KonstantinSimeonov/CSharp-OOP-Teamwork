namespace Logic.CustomEventArgs
{
    using System;
    using Logic.Interfaces;
    using System.Collections.Generic;
    class PlayCardArgs : DrawCardArgs
    {
        public string Path { get; set; }

        public bool FaceUp { get; set; }

        public bool PlayersTurn { get; set; }

        public PlayCardArgs(ICard card, string path, bool faceUp, bool turn)
            :base(card)
        {
            this.Path = path;
            this.FaceUp = faceUp;
            this.PlayersTurn = turn;
        }
    }
}
