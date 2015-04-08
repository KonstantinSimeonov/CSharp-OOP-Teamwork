namespace Logic.Interfaces
{
     public interface IEquipCard : IManaCostable
    {
        IMonsterCard Target { get; }
    }
}
