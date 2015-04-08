namespace Engine
{
    using Game;
    using Logic.Interfaces;
    using Logic.Board;
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
        {  }

        [STAThread]
        public void Run()
        {
            // TODO: refactoring

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new CardGame();
            Board board = Board.Instance;
            board.Subscribe(form);
            Application.Run(form);
        }

    }
}