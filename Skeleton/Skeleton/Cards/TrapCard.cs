namespace Skeleton.Cards
{
    using SampleInterfaces;

    public class TrapCard : Card, IFaceDownCard, ISpecialCard
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

        public void ApplyEffect()
        {
            throw new System.NotImplementedException();
        }

        public override void Play()
        {
            throw new System.NotImplementedException();
        }
    }
}