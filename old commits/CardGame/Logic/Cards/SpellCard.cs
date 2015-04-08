namespace Logic.Cards
{
    using Logic.Interfaces;
    using Logic.Delegates;

    public class SpellCard : EffectCard, IFaceUpCard
    {
        public SpellCard(string name, string description, string path, Effect eff, ParametricEffect paramEff, CardTypes type = CardTypes.Spell)
            :base(name, description, path, type, eff, paramEff)
        { 
        
        }

        public void SetUp()
        {
            throw new System.NotImplementedException();
        }

        public override void Play()
        {
            throw new System.NotImplementedException();
        }

        public override void ApplyEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}