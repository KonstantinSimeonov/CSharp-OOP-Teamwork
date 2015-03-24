namespace SampleInterfaces
{
    using System.Collections.Generic;

    public enum SampleType 
    { 
        Trainer,
        Student
    } // sample monster types

    public interface ICard
    {
        string Name { get; } // every card should have a name
        string Description { get; }

        void Play(); // every card should be somehow be put on the field
    }

    // We may implement different card placement - some could be placed face up(attack mode or straight effect),
    // while other - face-down(hidden and in defense mode or a trap card)

    public interface IFaceDownCard : ICard // some cards will be only face-down settable(like trap cards)
    {
        void SetDown(); // card that can be placed face-down should have such a method
        void Flip(); // the card should support an operation to flip it face-up
    }

    public interface IFaceUpCard : ICard // there will be cards that can be played face-up
    {
        void SetUp();
    }

    public interface IEquipCard
    {
        IMonsterCard Target { get; }
    }

    public interface IMonsterCard : IFaceDownCard, IFaceUpCard // monster cards will be placeable in both face-up and face-down mode
    {
        // every monster should have those

        int AttackPoints { get; }
        int DefensePoint { get; }
        SampleType Type { get; }

        void Attack(IMonsterCard monster);
        void ChangePosition();
    }

    public interface ISpecialCard : IMonsterCard // special monster will have an effect
    {
        void ApplyEffect();
    }

    public interface IDeck
    {
        IList<ICard> Hand { get; }
        ICard NextCard();
    }

    public interface IMenu
    {
        void Display(); // the menu will be displayable
        void ChooseOption(int optionNumber); // the user should be able to choose an option from the menu
    }

    public interface IPlayer
    {
        int LifePoints { get; }
        IList<ICard> Hand { get; } // the player needs a list of card as hand
        void Draw(); // the player can draw cards
        void PlayCard(ICard card); // the player can play cards
    }

    public interface IEngine
    {
        void Run();
    }

    public interface IArtificialIntelligence
    {
        // TODO: Discuss the mandatory methods that the AI should implement independently
    }

    public interface IHumanPlayer
    {
        // TODO: Discuss the mandatory methods the Human player should implement independently
    }
}