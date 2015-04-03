namespace Logic.Player
{
    using Logic.Interfaces;

    public class HumanPlayer : Player, IHumanPlayer
    {
        public HumanPlayer(IDeck deck)
            : base(deck)
        { }
    }
}