
namespace Logic.Interfaces
{
    using System.Collections.Generic;

    public interface IBoard
    {
        IList<IMonsterCard> PlayersMonsters { get; }
        IList<IMonsterCard> AIMonsters { get; }
        IList<IManaCostable> PlayerEffectCards { get; }
        IList<IManaCostable> AIEffectCards { get; }
        IDeck PlayerDeck { get; }
        IDeck AIDeck { get; }
        IList<ICard> PlayerGraveyard { get; }
        IList<ICard> AIGraveyard { get; }
    }
}
