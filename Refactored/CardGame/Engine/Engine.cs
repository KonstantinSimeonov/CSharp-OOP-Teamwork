namespace Engine
{
    using Game;
    using Logic.Interfaces;
    using Logic.Board;
    using Logic.Player;
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class GameEngine : IEngine
    {

        private static readonly GameEngine gameEngine = new GameEngine();

        public static GameEngine Instance
        {
            get { return gameEngine; }
        }

        private GameEngine()
        {  }

        [STAThread]
        public void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new CardGame();
            Board board = Board.Instance;
            board.Subscribe(form);
            Application.Run(form);
        }

    }
}