namespace Logic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Engine.Delegates;
    using Engine.CustomEventArgs;

    public interface IPlayer
    {
        int LifePoints { get; }
        int ManaPoints { get; }
        IList<ICard> Hand { get; } // the player needs a list of card as hand
        IDeck Deck { get; }
        ICard Draw(); // the player can draw cards
        void ChangeLifePoints(int by);
        void RemoveCard(ICard card);
        void PlayCard(ICard card, bool faceUp); // the player can play cards
    }
}
