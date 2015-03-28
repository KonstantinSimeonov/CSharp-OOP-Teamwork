namespace Skeleton.Cards
{
    using SampleInterfaces;

    public abstract class EffectCard : Card, IManaCostable
    {
        public abstract void ApplyEffect();

        public int ManaCost
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}