﻿namespace Skeleton.Cards
{
    using SampleInterfaces;

    public class EquipSpellCard : SpellCard, IEquipCard
    {
        public IMonsterCard Target
        {
            get { throw new System.NotImplementedException(); }
        }

        public override void ApplyEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}