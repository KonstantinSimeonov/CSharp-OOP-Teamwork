namespace Logic.Cards
{
    using Logic.Interfaces;
    using Engine.Delegates;
    using System.Drawing;

    public class SpellCard : EffectCard, IFaceUpCard
    {
        public SpellCard(string name, string description, string path, Image image, Effect eff, ParametricEffect paramEff, CardTypes type = CardTypes.Spell)
            :base(name, description, path, type, image, eff, paramEff)
        { 
        
        }

        public void SetUp()
        {
            this.ApplyEffect();
        }

        public override void ApplyEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}