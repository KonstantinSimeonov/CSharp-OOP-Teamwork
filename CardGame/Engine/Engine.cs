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

    public class Engine : IEngine, ISubscriber
    {
        private bool UIactive, playersTurn;
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
            this.UIactive = this.playersTurn = true;
            this.phase = Phases.Draw;
        }

        [STAThread]
        public void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var fack = Factory.Instance;
            var form = new CardGame();
            var GameDeck = fack.AssembleDeck();
            IBoard board = Board.GameField;
            var player = new HumanPlayer(GameDeck);
            player.Subscribe(form);
            this.Subscribe(form);
            //player.Deck.Cards.Add(fack.CreateCard());
            Application.Run(form);
        }

        public void Subscribe(IPublisher publisher)
        {
            publisher.Raise += this.ReportStateToArgs;
        }

        private void ReportStateToArgs(object sender, EventArgs e)
        {
            var args = e as TurnArgs;

            if (args == null)
                return;

            args.Phase = this.phase;
            args.PlayersTurn = this.playersTurn;
            args.PlayerUIactive = this.UIactive;
        }
    }
}