namespace Skeleton.Engine
{
    using Skeleton.Interfaces;
    using Skeleton.Board;

    public class Engine : IEngine
    {
        public void Run()
        {
            IBoard board = Board.GameField;
            System.Console.WriteLine("Implement me!");
        }
    }
}