using CardCademyGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCademyGame.Objects
{
    public abstract class HeroAbility : IManaCostable
    {
        public int ManaCost { get; set; }

        public abstract void Execute(Hero self, Hero enemy);
    }
}
