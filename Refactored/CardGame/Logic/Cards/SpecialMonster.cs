namespace Logic.Cards
{
    using Logic.Interfaces;
    using System.Drawing;

    public class SpecialMonster : MonsterCard, ISpecialCard
    {
        public delegate void Effect();

        public Effect effect;

        public SpecialMonster(string name, string description, string path, int attack, int defense, Image image, Effect eff)
         :base(name, description, path, attack, defense, CardTypes.SpecialMonster, image)
        {
            this.effect = eff;
        }

        public void ApplyEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}