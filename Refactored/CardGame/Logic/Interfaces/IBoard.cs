
namespace Logic.Interfaces
{
    using System.Collections.Generic;

    public interface IBoard
    {
        IList<IMonsterCard> PlayersMonsters { get; }
        IList<IMonsterCard> AIMonsters { get; }
        IList<IManaCostable> PlayerEffectCards { get; }
        IList<IManaCostable> AIEffectCards { get; }
        IHumanPlayer Player { get; }
        IArtificialIntelligence AI { get; }
        IList<ICard> PlayerGraveyard { get; }
        IList<ICard> AIGraveyard { get; }
    }
}
