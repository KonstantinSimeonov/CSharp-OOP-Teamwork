namespace Logic.Engine
{
    using Logic.Interfaces;
    using Logic.Board;

    public class Engine : IEngine
    {
        public void Run()
        {
            IBoard board = Board.GameField;
            System.Console.WriteLine("Implement me!");
        }
    }
}