using CardCademyGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCademyGame.Interfaces
{
    public interface IGameScreen
    {
        void Draw(Coordinates coords, GameScreenColor color, char symbol);
    }
}
