namespace Logic.CustomEventArgs
{
    using System;
    using Logic.Interfaces;

    class DrawCardArgs : EventArgs
    {
        public ICard PlayedCard { get; set; }

        public int CardsRemaining { get; set; }

        public DrawCardArgs(ICard card)
        {
            this.PlayedCard = card;
        }
    }
}
