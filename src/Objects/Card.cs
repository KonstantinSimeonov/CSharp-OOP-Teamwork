using CardCademyGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCademyGame.Objects
{
    public abstract class Card : GameObject, IManaCostable
    {
        public Card(Coordinates coords, int manaCost, string name, string description)
            : base(coords)
        {
            this.ManaCost = manaCost;
            this.Name = name;
            this.Description = description;
        }

        public int ManaCost { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public abstract void React(ILiving target);
    }
}
