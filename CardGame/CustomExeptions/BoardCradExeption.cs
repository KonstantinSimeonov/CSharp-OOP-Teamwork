using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CustomExeptions
{
    public class BoardCradExeption : Exception
    {
        public BoardCradExeption(string message)
            :base(message)
        {

        }
    }
}
