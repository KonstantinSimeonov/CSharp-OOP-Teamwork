
namespace Logic.Interfaces
{
  public interface IFactory
    {
        ICard CreateCard();
        IPlayer CreatePlayer(IDeck deck, bool isAI);
        IDeck AssembleDeck();
    }
}
