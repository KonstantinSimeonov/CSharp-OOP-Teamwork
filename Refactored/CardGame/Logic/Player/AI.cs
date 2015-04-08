namespace Logic.Player
{
    using System;
    using System.Linq;
    using Logic.Interfaces;
    using Engine.CustomEventArgs;

    public class AI : Player, IArtificialIntelligence
    {
        public AI(IDeck deck)
            :base(deck)
        {
            
        }

    }
}