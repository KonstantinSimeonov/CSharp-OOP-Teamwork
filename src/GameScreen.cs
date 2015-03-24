using CardCademyGame.Enums;
using CardCademyGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCademyGame
{
    public class GameScreen : IGameScreen
    {
        public void Draw(Coordinates coords, GameScreenColor color, char symbol)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = (ConsoleColor)((int)color);

            Console.SetCursorPosition(coords.X, coords.Y);
            Console.Write(symbol);

            Console.ForegroundColor = oldColor;
        }
    }
}
