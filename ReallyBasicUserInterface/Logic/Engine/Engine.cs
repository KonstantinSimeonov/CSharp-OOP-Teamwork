namespace Logic.Engine
{
    
    using test;
    using Logic.Interfaces;
    using Logic.Board;
    using Logic.Factory;
    using Logic.Player;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            var form = new CardGame();
            IBoard board = Board.GameField;
            var player = new HumanPlayer(board.PlayerDeck);
            player.Subscribe(form);
            form.Subscribe(player);
            var fack = Factory.Instance;
            player.Deck.Cards.Add(fack.CreateCard());
            Application.Run(form);
        }
    }
}