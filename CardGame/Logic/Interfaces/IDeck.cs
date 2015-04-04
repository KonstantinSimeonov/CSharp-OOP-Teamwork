namespace Logic.Interfaces
{
    using System.Collections.Generic;
    using Logic.Cards;

    public interface IDeck
    {
        IList<ICard> Cards { get; }
        ICard NextCard();
    }
}
