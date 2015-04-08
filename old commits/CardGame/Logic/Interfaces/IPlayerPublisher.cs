namespace Logic.Interfaces
{
    using Logic.Delegates;

    public interface IPlayerPublisher
    {
        event EventRaiser NotifyBoard;
    }
}