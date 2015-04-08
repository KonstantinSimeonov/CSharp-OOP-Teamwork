namespace Logic.Interfaces
{
    using System.Collections.Generic;
    using Logic.Cards;

    public interface IDeck
    {
        int CardsRemaining { get; }

        IList<ICard> Cards { get; }
        ICard NextCard();
    }
}
