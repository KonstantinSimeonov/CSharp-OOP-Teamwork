namespace Skeleton.Cards
{
    using SampleInterfaces;

    public abstract class EffectCard : Card, IFaceDownCard, ISpecialCard
    {
        public abstract void ApplyEffect();
    }
}