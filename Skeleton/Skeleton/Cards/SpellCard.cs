namespace Skeleton.Cards
{
    using SampleInterfaces;

    public abstract class SpellCard : IFaceUpCard, IFaceDownCard, ISpecialCard
    {
        public string Name
        {
            get { throw new System.NotImplementedException(); }
        }

        public string Description
        {
            get { throw new System.NotImplementedException(); }
        }

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

        public void Play()
        {
            throw new System.NotImplementedException();
        }

        public void SetUp()
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

        public virtual void ApplyEffect()
        {
            throw new System.NotImplementedException();
        }

        public void Applyffect()
        {
            throw new System.NotImplementedException();
        }

        public void Attack(IMonsterCard monster)
        {
            throw new System.NotImplementedException();
        }

        public void ChangePosition()
        {
            throw new System.NotImplementedException();
        }
    }
}