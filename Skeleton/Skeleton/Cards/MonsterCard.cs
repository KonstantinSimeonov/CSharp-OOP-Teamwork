namespace Skeleton.Cards
{
    using SampleInterfaces;

    public class MonsterCard : Card, IMonsterCard
    {
        public int AttackPoints
        {
            get { throw new System.NotImplementedException(); }
        }

        public int DefensePoint
        {
            get { throw new System.NotImplementedException(); }
        }

        public SampleType Type
        {
            get { throw new System.NotImplementedException(); }
        }

        public void Attack(IMonsterCard monster)
        {
            throw new System.NotImplementedException();
        }

        public void ChangePosition()
        {
            throw new System.NotImplementedException();
        }

        public void SetDown()
        {
            throw new System.NotImplementedException();
        }

        public void Flip()
        {
            throw new System.NotImplementedException();
        }

        public void SetUp()
        {
            throw new System.NotImplementedException();
        }
    }
}