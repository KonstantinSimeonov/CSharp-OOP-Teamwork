namespace Skeleton.Cards
{
    using Skeleton.Interfaces;

    public abstract class SpellCard : EffectCard, IFaceUpCard
    {
        public SpellCard(string name, string description, string path, Effect eff, ParametricEffect paramEff)
            :base(name, description, path, eff, paramEff)
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
    }
}