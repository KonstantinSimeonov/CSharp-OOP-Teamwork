namespace Logic.Interfaces
{
    using System.Drawing;

    public interface ICard
    {
        Image CardImage { get; }
        string Name { get; } // every card should have a name
        Logic.Cards.CardTypes Type { get; }
        string Path { get; }
        string Description { get; }
    }
}
