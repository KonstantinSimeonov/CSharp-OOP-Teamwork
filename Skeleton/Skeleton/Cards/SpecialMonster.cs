namespace Skeleton.Cards
{
    using Skeleton.Interfaces;

    public class SpecialMonster : MonsterCard, ISpecialCard
    {
        public delegate void Effect();

        public Effect effect;

        public SpecialMonster(string name, string description, string path, int attack, int defense, Effect eff)
         :base(name, description, path, attack, defense)
        {
            this.effect = eff;
        }

        public void ApplyEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}