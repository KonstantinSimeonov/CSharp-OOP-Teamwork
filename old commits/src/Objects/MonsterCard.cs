using CardCademyGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCademyGame.Objects
{
    public class MonsterCard : Card, ILiving, IAttacking
    {
        public MonsterCard(Coordinates coords, int manaCost, string name, string description, int damage, int hitPoints)
            : base(coords, manaCost, name, description)
        {
            this.Damage = damage;
            this.HitPoints = hitPoints;
        }

        public int Damage { get; set; }

        public int HitPoints { get; set; }

        public bool IsDead
        {
            get
            {
                return this.HitPoints <= 0;
            }
        }

        public override void React(ILiving target)
        {
            target.HitPoints -= this.Damage;
        }
    }
}
