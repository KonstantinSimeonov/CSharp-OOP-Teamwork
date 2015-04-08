namespace Logic.Interfaces
{
    public interface IManaCostable : IFaceDownCard, ISpecialCard
    {
        int ManaCost { get; }
    }
}
