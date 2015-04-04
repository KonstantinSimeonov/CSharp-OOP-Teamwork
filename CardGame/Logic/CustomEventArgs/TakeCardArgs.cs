namespace Logic.CustomEventArgs
{
    using System;
    using Logic.Interfaces;

    class TakeCardArgs : EventArgs
    {
        public ICard PlayedCard { get; set; }

        public TakeCardArgs(ICard card)
        {
            this.PlayedCard = card;
        }
    }
}
