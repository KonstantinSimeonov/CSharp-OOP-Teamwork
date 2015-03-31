namespace Skeleton.Player
{
    using Skeleton.Interfaces;

    public class HumanPlayer : Player, IHumanPlayer
    {
        public HumanPlayer(IDeck deck)
            : base(deck)
        { }
    }
}