namespace Logic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Logic.Delegates;

   public interface IPlayer
    {
        int LifePoints { get; }
        int ManaPoints { get; }
        IList<ICard> Hand { get; } // the player needs a list of card as hand
        IDeck Deck { get; }
        void Draw(object sender, EventArgs e); // the player can draw cards
        void PlayCard(ICard card, bool faceUp); // the player can play cards
        event EventRaiser NotifyBoard;
    }
}
