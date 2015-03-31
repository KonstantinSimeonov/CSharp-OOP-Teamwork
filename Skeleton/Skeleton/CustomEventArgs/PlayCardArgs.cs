namespace Skeleton.CustomEventArgs
{
    using System;
    using Skeleton.Interfaces;

    class PlayCardArgs : EventArgs
    {
        public ICard PlayedCard { get; private set; }

        public PlayCardArgs(ICard card)
        {
            this.PlayedCard = card;
        }
    }
}
