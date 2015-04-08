namespace Logic.Cards
{
    using Logic.Interfaces;
    using Engine.Delegates;
    using System.Collections.Generic;
    using System.Drawing;

    public class EquipSpellCard : SpellCard, IEquipCard
    {
        public int AttackEffect { get; private set; }
        public int DefenseEffect { get; private set; }

        public EquipSpellCard(string name, string description, string path, Image image, Effect eff, ParametricEffect paramEff, int attack, int defense)
            :base(name, description, path, image, eff, paramEff, CardTypes.Equip)
        {
            this.AttackEffect = attack;
            this.DefenseEffect = defense;
        }


        public override void ApplyEffect()
        {
            effect();
            paramEffect(AttackEffect, DefenseEffect);
        }

        public IMonsterCard Target { get; private set; }
    }
}