
namespace Logic.Interfaces
{
    // We may implement different card placement - some could be placed face up(attack mode or straight effect),
    // while other - face-down(hidden and in defense mode or a trap card)

    public interface IFaceUpCard : ICard // there will be cards that can be played face-up
    {
        void SetUp();
    }
}
