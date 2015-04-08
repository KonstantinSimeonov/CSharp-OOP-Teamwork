namespace Logic.Interfaces
{
    // We may implement different card placement - some could be placed face up(attack mode or straight effect),
    // while other - face-down(hidden and in defense mode or a trap card)

    public interface IFaceDownCard : ICard // some cards will be only face-down settable(like trap cards)
    {
        bool FaceUp { get; }
        void SetDown(); // card that can be placed face-down should have such a method
        void Flip(); // the card should support an operation to flip it face-up
    }
}
