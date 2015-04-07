namespace Engine
{
    using Game;
    using Logic.Interfaces;
    using Logic.Board;
    using Logic.Factory;
    using Logic.Player;
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Logic.CustomEventArgs;

    public class Engine : IEngine, IFormSubscriber
    {
        private bool playersTurn;
        private Phases phase;

        private static readonly Engine gameEngine = new Engine();

        /// <summary>
        /// Returns the only instance of the engine class.
        /// </summary>
        public static Engine Instance
        {
            get { return gameEngine; }
        }

        private Engine()
        {
            this.playersTurn = true;
            this.phase = Phases.Draw;
        }

        [STAThread]
        public void Run()
        {
            // TODO: refactoring

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var fack = Factory.Instance;
            var form = new CardGame();
            var PlayerDeck = fack.AssembleDeck();
            Board board = Board.GameField;
            var player = new HumanPlayer(PlayerDeck);
            var AIDeck = fack.AssembleDeck();
            var AI = new AI(AIDeck);
            player.Subscribe(form);
            AI.Subscribe(form);
            board.SubscribeToPlayer(player);
            board.SubscribeToPlayer(AI);
            this.Subscribe(form);
            Application.Run(form);
        }

        public void Subscribe(IFormPublisher publisher)
        {
            publisher.RequestStateReport += this.ReportStateToArgs;
            publisher.DrawEvent += this.UpdateWithDraw;
            publisher.Battle += this.UpdateWithBattle;
            publisher.Main2 += this.UpdateWithMain2;
            publisher.End += this.UpdateWithEnd;
        }

        private void ReportStateToArgs(object sender, EventArgs e)
        {
            var args = e as TurnArgs;

            if (args == null)
                return;

            args.Phase = this.phase;
            args.PlayersTurn = this.playersTurn;
        }

        private void UpdateWithDraw(object sender, EventArgs e)
        {
            this.phase = Phases.Main1;
        }
        private void UpdateWithBattle(object sender, EventArgs e)
        {
            this.phase = Phases.Battle;
        }
        private void UpdateWithMain2(object sender, EventArgs e)
        {
            this.phase = Phases.Main2;
        }
        private void UpdateWithEnd(object sender, EventArgs e)
        {
            this.playersTurn = !this.playersTurn;
        }
    }
}