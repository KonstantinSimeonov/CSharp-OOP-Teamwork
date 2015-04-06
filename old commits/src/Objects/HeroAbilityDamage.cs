using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCademyGame.Objects
{
    public class HeroAbilityDamage : HeroAbility
    {
        public override void Execute(Hero self, Hero enemy)
        {
            enemy.HitPoints -= 2;
        }
    }
}
