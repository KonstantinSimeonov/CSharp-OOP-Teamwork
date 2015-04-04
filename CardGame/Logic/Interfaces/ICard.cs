namespace Logic.Interfaces
{
   public interface ICard
    {
        string Name { get; } // every card should have a name
        Logic.Cards.CardTypes Type { get; }
        string Path { get; }
        string Description { get; }
        void Play();
    }
}
