namespace Logic.Cards
{
    using Logic.Interfaces;

    public abstract class EffectCard : Card, IManaCostable
    {
        // hold effect functions

        public delegate void Effect();
        public delegate void ParametricEffect(int attack, int defense);

        // effect variables

        protected Effect effect;
        protected ParametricEffect paramEffect;

        public EffectCard(string name, string description, string path, Effect eff, ParametricEffect paramEff)
            :base(name, description, path)
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

        public override System.Collections.Generic.IList<ICard> Parse(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}