namespace Logic.Cards
{
    using Logic.Interfaces;

    public class MonsterCard : Card, IMonsterCard
    {

        public MonsterCard(string name, string description, string path, int attack, int defense, CardTypes type = CardTypes.Monster)
            :base(name, description, path, type)
        {
            this.DefensePoint = defense;
            this.AttackPoints = attack;
        }

        public int AttackPoints { get; protected set; }

        public int DefensePoint { get; protected set; }

        public bool Position { get; protected set; }

        public void Attack(IMonsterCard monster)
        {
            if (this.AttackPoints > monster.AttackPoints)
            {
                // EVENT HERE
            }
        }

        public void ChangePosition()
        {
            Position = !Position;
        }

        public void SetUp()
        {
            throw new System.NotImplementedException();
        }

        public override void Play()
        {
            throw new System.NotImplementedException();
        }

        public void ChangeAttack(int byPoints)
        {
            this.AttackPoints += byPoints;
        }

        public void ChangeDefense(int byPoints)
        {
            this.DefensePoint += byPoints;
        }

        public override System.Collections.Generic.IList<ICard> Parse(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}