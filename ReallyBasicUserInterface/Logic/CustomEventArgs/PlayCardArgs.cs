namespace Logic.CustomEventArgs
{
    using System;
    using Logic.Interfaces;

    class PlayCardArgs : EventArgs
    {
        public ICard PlayedCard { get; private set; }

        public PlayCardArgs(ICard card)
        {
            this.PlayedCard = card;
        }
    }
}
