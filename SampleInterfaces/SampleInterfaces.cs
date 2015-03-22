namespace SampleInterfaces
{
    using System.Collections.Generic;

    public enum SampleType { FIRE, WATER, AIR, EARTH, NATURE }; // sample monster types

    public interface ICard
    {
        string Name { get; } // every card should have a name
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



    public interface IMonsterCard : IFaceDownCard, IFaceUpCard // monster cards will be placeable in both face-up and face-down mode
    {
        // every monster should have those

        int AttackPoints { get; }
        int DefensePoint { get; }
        SampleType type { get; }

        void Attack(IMonsterCard monster);
        void ChangePosition();
    }

    public interface ISpecialMonster : IMonsterCard // special monster will have an effect
    {
        void Effect();
    }

    public interface IMenu
    {
        void Display(); // the menu will be displayable
        void ChooseOption(int optionNumber); // the user should be able to choose an option from the menu
    }

    public interface IPlayer
    {
        IList<ICard> hand { get; } // the player needs a list of card as hand
        void Draw(); // the player can draw cards
        void PlayCard(ICard card); // the player can play cards
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