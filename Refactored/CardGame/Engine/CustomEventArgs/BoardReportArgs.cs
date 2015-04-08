using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Logic.Interfaces;


namespace Engine.CustomEventArgs
{
    class BoardReportArgs : EventArgs
    {
        public IHumanPlayer Player { get; set; }
        public IArtificialIntelligence AI { get; set; }
        public IList<IMonsterCard> PlayerMonsters { get; set; }
        public IList<IManaCostable> PlayerEffects { get; set; }
        public IList<IMonsterCard> AIMonsters { get; set; }
        public IList<IManaCostable> AIEffects { get; set; }
        public int PlayerCardsRemaining { get; set; }
        public int AICardsRemainig { get; set; }
        public Phases Phase { get; set; }
        public bool PlayersTurn { get; set; }
        public bool PlayerIsTarget { get; set; }
        public string PathId { get; set; }
        public bool FaceUp { get; set; }
        public BattleArgs Battle { get; set; }

        public BoardReportArgs(bool playersTurn, bool playerIsTarget, bool faceUp, string pathId = null, BattleArgs bArgs = null)
        {
            this.PlayersTurn = playersTurn;
            this.PlayerIsTarget = playerIsTarget;
            this.PathId = pathId;
            this.FaceUp = faceUp;
            this.Battle = bArgs;
        }

        public void SetInfo(IHumanPlayer player,
                            IArtificialIntelligence ai,
                            IList<IMonsterCard> playerMonsters,
                            IList<IManaCostable> playerEffects,
                            IList<IMonsterCard> aiMonsters,
                            IList<IManaCostable> aiEffects,
                            int playerRemaining,
                            int aiRemaining,
                            Phases phase,
                            bool playersTurn,
                            bool playerIsTarget)
        {
            this.Player = player;
            this.AI = ai;
            this.PlayerMonsters = playerMonsters;
            this.PlayerEffects = playerEffects;
            this.AIMonsters = aiMonsters;
            this.AIEffects = aiEffects;
            this.PlayerCardsRemaining = playerRemaining;
            this.AICardsRemainig = aiRemaining;
            this.Phase = phase;
            this.PlayersTurn = playersTurn;
            this.PlayerIsTarget = playerIsTarget;
        }
    }
}
