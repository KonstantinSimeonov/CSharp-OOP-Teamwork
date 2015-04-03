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

    public class Engine : IEngine
    {
        private static readonly Engine gameEngine = new Engine();

        public static Engine Instance
        {
            get { return gameEngine; }
        }

        private Engine()
        {

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
            player.Deck.Cards.Add(fack.CreateCard());
            Application.Run(form);
        }
    }
}