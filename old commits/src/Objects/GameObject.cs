using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCademyGame.Objects
{
    public abstract class GameObject
    {
        public GameObject(Coordinates coords)
        {
            this.Coordinates = coords;
        }

        public Coordinates Coordinates { get; set; }
    }
}
