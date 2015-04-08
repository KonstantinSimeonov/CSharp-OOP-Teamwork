namespace Logic.Cards
{
    using Logic.Interfaces;
    using Engine.Delegates;
    using System.Drawing;

    public class TrapCard : EffectCard, IFaceDownCard, ISpecialCard
    {
        public TrapCard(string name, string description, string path, Image image, Effect eff, ParametricEffect paramEff)
            :base(name, description, path, CardTypes.Trap, image, eff, paramEff)
        {
        
        }

        public override void ApplyEffect()
        {
            throw new System.NotImplementedException();
        }

    }
}