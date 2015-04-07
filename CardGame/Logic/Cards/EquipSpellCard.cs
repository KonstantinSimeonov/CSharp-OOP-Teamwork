namespace Logic.Cards
{
    using Logic.Interfaces;
    using Logic.Delegates;
    using System.Collections.Generic;

    public class EquipSpellCard : SpellCard, IEquipCard
    {
        public int AttackEffect { get; private set; }
        public int DefenseEffect { get; private set; }

        public EquipSpellCard(string name, string description, string path, Effect eff, ParametricEffect paramEff, int attack, int defense)
            :base(name, description, path, eff, paramEff, CardTypes.Equip)
        {
            this.AttackEffect = attack;
            this.DefenseEffect = defense;
        }


        public override void ApplyEffect()
        {
            effect();
            paramEffect(AttackEffect, DefenseEffect);
        }

        public IMonsterCard Target
        {
            get { throw new System.NotImplementedException(); }
        }

        public override void Play()
        {
            throw new System.NotImplementedException();
        }

        public override IList<ICard> Parse(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}