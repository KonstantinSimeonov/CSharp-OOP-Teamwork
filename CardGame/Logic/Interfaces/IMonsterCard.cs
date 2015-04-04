namespace Logic.Interfaces
{

    // We may implement different card placement - some could be placed face up(attack mode or straight effect),
    // while other - face-down(hidden and in defense mode or a trap card)

    public interface IMonsterCard : IFaceDownCard, IFaceUpCard // monster cards will be placeable in both face-up and face-down mode
    {
        // every monster should have those

        int AttackPoints { get; }
        int DefensePoint { get; }
        SampleType Type { get; }
        bool Position { get; }

        void Attack(IMonsterCard monster);
        void ChangePosition();
        void ChangeAttack(int byPoints);
        void ChangeDefense(int byPoints);
    }
}
