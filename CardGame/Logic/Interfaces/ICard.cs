namespace Logic.Interfaces
{
   public interface ICard
    {
        string Name { get; } // every card should have a name
        string Description { get; }
        void Play();
    }
}
