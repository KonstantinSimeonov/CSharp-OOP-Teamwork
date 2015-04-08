namespace Logic.Cards
{
    using Logic.Interfaces;
    using Engine.Delegates;
    using System.Collections.Generic;
    using System.Drawing;

    public abstract class EffectCard : Card, IManaCostable
    {

        protected Effect effect;
        protected ParametricEffect paramEffect;

        public EffectCard(string name, string description, string path, CardTypes type, Image image, Effect eff, ParametricEffect paramEff)
            :base(name, description, path, type, image)
        {
            this.effect = eff;
            this.paramEffect = paramEff;
        }

        public abstract void ApplyEffect();

        public int ManaCost { get; private set; }

    }
}