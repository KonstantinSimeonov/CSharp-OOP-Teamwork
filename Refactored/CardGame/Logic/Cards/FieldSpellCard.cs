namespace Logic.Cards
{
    using System.Collections.Generic;
    using Logic.Interfaces;
    using Engine.Delegates;
    using System.Drawing;

    public class FieldSpellCard : SpellCard
    {
        public int Duration { get; private set; }

        public FieldSpellCard(string name, string description, string path, Image image, Effect eff,ParametricEffect paramEff, int duration)
            : base(name, description, path, image, eff, paramEff, CardTypes.Field)
        {
            this.Duration = duration;
        }

        public override void ApplyEffect()
        {
            throw new System.NotImplementedException();
        }

    }
}