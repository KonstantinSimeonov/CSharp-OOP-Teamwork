namespace Logic.Player
{
    using Logic.Interfaces;

    public class AI : Player, IArtificialIntelligence
    {
        public AI(IDeck deck)
            :base(deck)
        {
            
        }
    }
}