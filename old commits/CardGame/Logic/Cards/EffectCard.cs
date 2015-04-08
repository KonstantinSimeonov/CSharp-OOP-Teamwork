﻿namespace Logic.Cards
{
    using Logic.Interfaces;
    using Logic.Delegates;
    using System.Collections.Generic;

    public abstract class EffectCard : Card, IManaCostable
    {
        // hold effect functions

        

        // effect variables

        protected Effect effect;
        protected ParametricEffect paramEffect;

        public EffectCard(string name, string description, string path, CardTypes type, Effect eff, ParametricEffect paramEff)
            :base(name, description, path, type)
        {
            this.effect = eff;
            this.paramEffect = paramEff;
        }

        public abstract void ApplyEffect();

        public int ManaCost { get; private set; }

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