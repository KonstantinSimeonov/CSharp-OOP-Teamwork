namespace Logic.Player
{
    using System;
    using Logic.Interfaces;

    public class AI : Player, IArtificialIntelligence
    {
        public AI(IDeck deck)
            :base(deck)
        {
            
        }

        public override void Subscribe(IFormPublisher publisher)
        {
            publisher.End += this.PlayTurn;
        }

        private void PlayTurn(object sender, EventArgs e)
        {
            // TODO: implement draw, monster summon, spellcard set, battle, end of turn


        }
    }
}