using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardCademyGame.Enums;
using CardCademyGame.Interfaces;

namespace CardCademyGame.Objects
{
    public class SpellCard : Card
    {
        public SpellCard(Coordinates coords, int manaCost, string name, string description, SpellType spellType, int ammount)
            : base(coords, manaCost, name, description)
        {
            this.SpellType = spellType;
            this.Ammount = ammount;
        }

        public SpellType SpellType { get; set; }

        public int Ammount { get; set; }

        public override void React(ILiving target)
        {
            switch (this.SpellType)
            {
                case SpellType.Offensive: target.HitPoints -= this.Ammount;
                    break;
                case SpellType.Heal: target.HitPoints += this.Ammount;
                    break;
                default:
                    break;
            }
        }
    }
}
