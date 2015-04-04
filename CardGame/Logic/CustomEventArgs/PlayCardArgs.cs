namespace Logic.CustomEventArgs
{
    using System;
    using Logic.Interfaces;
    class PlayCardArgs : TakeCardArgs
    {
        public string Path { get; set; }

        public PlayCardArgs(ICard card, string path)
            :base(card)
        {
            this.Path = path;
        }
    }
}
