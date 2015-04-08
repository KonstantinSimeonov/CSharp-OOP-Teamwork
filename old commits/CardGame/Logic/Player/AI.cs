namespace Logic.Player
{
    using System;
    using System.Linq;
    using Logic.Interfaces;
    using Logic.CustomEventArgs;

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
            for (int i = 0; i < 5; i++)
            {
                this.Draw(sender, new DrawCardArgs(null));
            }

            var args = e as PlayCardArgs;

            if (args == null)
                throw new InvalidCastException("eba si makata");

            var monsterToPlay = this.Hand.Where(x => x as IMonsterCard != null).OrderByDescending(x => (x as IMonsterCard).AttackPoints).First();
            args.PlayedCard = monsterToPlay;

            this.PlayCard(monsterToPlay, true);
        }
    }
}