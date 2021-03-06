﻿namespace Logic.Cards
{
    using Logic.Interfaces;
    using Logic.Delegates;

    public class TrapCard : EffectCard, IFaceDownCard, ISpecialCard
    {
        public TrapCard(string name, string description, string path, Effect eff, ParametricEffect paramEff)
            :base(name, description, path,CardTypes.Trap, eff, paramEff)
        {
        
        }

        public override void ApplyEffect()
        {
            throw new System.NotImplementedException();
        }

        public override void Play()
        {
            throw new System.NotImplementedException();
        }

        public override System.Collections.Generic.IList<ICard> Parse(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}