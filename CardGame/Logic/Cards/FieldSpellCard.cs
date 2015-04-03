﻿namespace Logic.Cards
{
    using System.Collections.Generic;
    using Logic.Interfaces;

    public class FieldSpellCard : SpellCard
    {
        public int Duration { get; private set; }

        public FieldSpellCard(string name, string description, string path, Effect eff,ParametricEffect paramEff, int duration)
            : base(name, description, path, eff, paramEff)
        {
            this.Duration = duration;
        }

        public override void ApplyEffect()
        {
            throw new System.NotImplementedException();
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