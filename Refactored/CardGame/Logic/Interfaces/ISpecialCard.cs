namespace Logic.Interfaces
{
   public interface ISpecialCard : ICard // special cards will have an effect
    {
        void ApplyEffect();
    }
}
