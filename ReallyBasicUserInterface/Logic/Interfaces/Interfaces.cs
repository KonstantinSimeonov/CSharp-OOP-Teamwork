namespace Logic.Interfaces
{
    using System.Collections.Generic;
    using Logic.Delegates;
    using Logic.Cards;

    public enum SampleType 
    { 
        Trainer,
        Student
    } // sample monster types

    public interface IParsableCard
    {
        string Path { get; }
        IList<ICard> Parse(string path);
    }

    public interface ICard
    {
        string Name { get; } // every card should have a name
        string Description { get; }
        void Play();
    }

    // We may implement different card placement - some could be placed face up(attack mode or straight effect),
    // while other - face-down(hidden and in defense mode or a trap card)

    public interface IFaceDownCard : ICard // some cards will be only face-down settable(like trap cards)
    {
        bool FaceUp { get; }
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
        bool Position { get; }

        void Attack(IMonsterCard monster);
        void ChangePosition();
        void ChangeAttack(int byPoints);
        void ChangeDefense(int byPoints);
    }

    public interface ISpecialCard // special cards will have an effect
    {
        void ApplyEffect();
    }

    public interface IManaCostable : IFaceDownCard, ISpecialCard
    {
        int ManaCost { get; }
    }

    public interface IDeck
    {
        IList<ICard> Cards { get; }
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
        int ManaPoints { get; }
        IList<ICard> Hand { get; } // the player needs a list of card as hand
        IDeck Deck { get; }
        void Draw(object sender, System.EventArgs e); // the player can draw cards
        void PlayCard(ICard card); // the player can play cards
    }

    public interface IBoard
    {
        IList<IMonsterCard> PlayersMonsters { get; }
        IList<IMonsterCard> AIMonsters { get; }
        IList<IManaCostable> PlayerEffectCards { get; }
        IList<IManaCostable> AIEffectCards { get; }
        IDeck PlayerDeck { get; }
        IDeck AIDeck { get; }
        IList<ICard> PlayerGraveyard { get; }
        IList<ICard> AIGraveyard { get; }
        
    }

    public interface IPublisher
    {
        event EventRaiser Raise;
    }

    public interface IEngine // one of the last things to implement
    {
        void Run();
    }

    public interface IFactory
    {
        ICard CreateCard();
        IPlayer CreatePlayer(IDeck deck, bool isAI);
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