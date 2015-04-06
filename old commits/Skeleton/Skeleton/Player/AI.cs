namespace Skeleton.Player
{
    using Skeleton.Interfaces;

    public class AI : Player, IArtificialIntelligence
    {
        public AI(IDeck deck)
            :base(deck)
        {
            
        }
    }
}