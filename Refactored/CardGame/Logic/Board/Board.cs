namespace Logic.Board
{
    using Logic.Interfaces;
    using Logic.Cards;
    using Engine.CustomEventArgs;
    using Logic.Player;
    using Engine.Factory;
    using System;
    using System.Collections.Generic;
    using Engine;
    using Engine.CustomExceptions;
    using System.Linq;

    public class Board : IBoard, IFormSubscriber
    {
        private const int MAX_MONSTERS = 5;
        private const int MAX_EFFECT_CARDS = 5;

        private IList<IMonsterCard> playersMonsters;
        private IList<IMonsterCard> aiMonsters;
        private IList<IManaCostable> playerEffectCards;
        private IList<IManaCostable> aiEffectCards;
        private IList<ICard> playerGraveyard;
        private IList<ICard> aiGraveyard;

        private Phases phase;
        private bool playersTurn;

        // Singleton

        private static readonly Board board = new Board(Factory.Instance.AssembleDeck(), Factory.Instance.AssembleDeck()); // assign at compile time

        public static Board Instance // this property returns the only instance of the class that is creatable
        {
            get { return board; }
        }

        private Board(IDeck playersDeck, IDeck AIDeck) // constructors is private because of singleton
        {
            this.PlayersMonsters = new List<IMonsterCard>(MAX_MONSTERS);
            this.PlayerEffectCards = new List<IManaCostable>(MAX_EFFECT_CARDS);
            this.PlayerGraveyard = new List<ICard>();

            this.aiMonsters = new List<IMonsterCard>(MAX_MONSTERS);
            this.aiEffectCards = new List<IManaCostable>(MAX_EFFECT_CARDS);
            this.aiGraveyard = new List<ICard>();

            this.Player = new HumanPlayer(playersDeck);
            this.AI = new AI(AIDeck);

            for (int i = 0; i < 4; i++)
            {
                this.Player.Draw();
                this.AI.Draw();
            }
            this.AI.Draw();
            this.playersTurn = true;
            this.phase = Phases.Draw;
        }

        public IHumanPlayer Player { get; private set; }
        public IArtificialIntelligence AI { get; private set; }

        public IList<IMonsterCard> PlayersMonsters
        {
            get { return new List<IMonsterCard>(playersMonsters); }
            private set { playersMonsters = value; }
        }

        public IList<IMonsterCard> AIMonsters
        {
            get { return new List<IMonsterCard>(aiMonsters); }
            private set { aiMonsters = value; }
        }

        public IList<IManaCostable> PlayerEffectCards
        {
            get { return new List<IManaCostable>(playerEffectCards); }
            private set { playerEffectCards = value; }
        }

        public IList<IManaCostable> AIEffectCards
        {
            get { return new List<IManaCostable>(aiEffectCards); }
            private set { aiEffectCards = value; }
        }

        public IList<ICard> PlayerGraveyard
        {
            get { return new List<ICard>(playerGraveyard); }
            private set { playerGraveyard = value; }
        }

        public IList<ICard> AIGraveyard
        {
            get { return new List<ICard>(aiGraveyard); }
            private set { aiGraveyard = value; }
        }

        private void AddCard(object sender, EventArgs e)
        {
            var args = e as BoardReportArgs;
            bool t = args.PlayerIsTarget;
            var target = args.PlayerIsTarget ? this.Player as IPlayer : this.AI as IPlayer;
            var card = target.Hand.Single(x => x.Path == args.PathId);

            if (!args.FaceUp || card as TrapCard != null)
            {
                (card as IFaceDownCard).SetDown();
            }

            if (args.PlayerIsTarget)
            {
                if (card as IManaCostable != null)
                    this.playerEffectCards.Add(card as IManaCostable);
                else
                    this.playersMonsters.Add(card as IMonsterCard);
            }
            else
            {
                if (card as IManaCostable != null)
                    this.aiEffectCards.Add(card as IManaCostable);
                else
                    this.aiMonsters.Add(card as IMonsterCard);
            }

            target.RemoveCard(card);
            this.ValidateBoard();
            args.SetInfo(this.Player, this.AI, this.PlayersMonsters, this.PlayerEffectCards, this.AIMonsters, this.AIEffectCards, this.Player.Deck.CardsRemaining, this.AI.Deck.CardsRemaining, this.phase, this.playersTurn, t);
        }



        private void DrawCard(object sender, EventArgs e)
        {
            var args = e as BoardReportArgs;
            bool t = args.PlayerIsTarget;
            IPlayer targetPlayer = null;

            if (args.PlayerIsTarget)
                targetPlayer = this.Player;
            else
                targetPlayer = this.AI;

            ICard drawn = targetPlayer.Draw();


            args.SetInfo(this.Player, this.AI, this.PlayersMonsters, this.PlayerEffectCards, this.AIMonsters, this.AIEffectCards, this.Player.Deck.CardsRemaining, this.AI.Deck.CardsRemaining, this.phase, this.playersTurn, t);

        }

        private void HandleBattle(object sender, EventArgs e)
        {
            var args = e as BoardReportArgs;
            bool t = args.PlayersTurn;

            var attackingMonster = this.playersMonsters.Single(x => x.Path == args.Battle.IdAttacker) as IMonsterCard;
            var defendingMonster = this.aiMonsters.Single(x => x.Path == args.Battle.IdDefender) as IMonsterCard;

            int relevantPoints = defendingMonster.Position ? defendingMonster.DefensePoint : defendingMonster.AttackPoints;

            if (relevantPoints < attackingMonster.AttackPoints)
            {
                if (!defendingMonster.Position)
                    this.AI.ChangeLifePoints(relevantPoints - attackingMonster.AttackPoints);
                this.aiMonsters.Remove(defendingMonster);
            }
            else if (relevantPoints == attackingMonster.AttackPoints)
            {
                if (!defendingMonster.Position)
                {
                    this.aiMonsters.Remove(defendingMonster);
                    this.playersMonsters.Remove(attackingMonster);
                }

            }
            else
            {
                this.Player.ChangeLifePoints(attackingMonster.AttackPoints - relevantPoints);
                if (!defendingMonster.Position)
                    this.playersMonsters.Remove(attackingMonster);
            }

            this.ValidateBoard();

            args.SetInfo(this.Player, this.AI, this.PlayersMonsters, this.PlayerEffectCards, this.AIMonsters, this.AIEffectCards, this.Player.Deck.CardsRemaining, this.AI.Deck.CardsRemaining, this.phase, this.playersTurn, t);

        }

        private void PlayAiTurn(object sender, EventArgs e)
        {
            var args = e as BoardReportArgs;

            this.AI.Draw();
            this.AI.Draw();
            this.AI.Draw();
            args.PathId = this.AI.Hand.Where(x => (x as IMonsterCard != null)).OrderByDescending(x => (x as IMonsterCard).AttackPoints).First().Path;
            this.AddCard(sender, args);
            args.PathId = this.AI.Hand.Where(x => (x as IMonsterCard != null)).OrderByDescending(x => (x as IMonsterCard).AttackPoints).First().Path;
            this.AddCard(sender, args);
            args.PathId = this.AI.Hand.Where(x => (x as IManaCostable != null)).First().Path;
            this.AddCard(sender, args);
            args.PathId = this.AI.Hand.Where(x => (x as IManaCostable != null)).First().Path;
            this.AddCard(sender, args);

            this.ValidateBoard();
        }

        private void ValidateBoard()
        {
            if (this.playerEffectCards.Count > Board.MAX_EFFECT_CARDS)
                throw new BoardCardNumberException("Player Effect Cards");
            if (this.aiEffectCards.Count > Board.MAX_EFFECT_CARDS)
                throw new BoardCardNumberException("AI Effect Cards");
            if (this.playersMonsters.Count > Board.MAX_MONSTERS)
                throw new BoardCardNumberException("Player Monster Cards");
            if (this.aiMonsters.Count > Board.MAX_MONSTERS)
                throw new BoardCardNumberException("AI Monster Cards");
        }

        public void Subscribe(IFormPublisher publisher)
        {
            publisher.DrawEvent += this.DrawCard;
            publisher.PlayCardEvent += this.AddCard;
            publisher.Battle += this.HandleBattle;
            publisher.End += this.PlayAiTurn;
        }

    }
}