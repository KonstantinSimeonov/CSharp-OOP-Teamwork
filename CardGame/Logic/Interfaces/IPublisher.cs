
namespace Logic.Interfaces
{
    using Logic.Delegates;
    public interface IPublisher
    {
        event EventRaiser Raise;
    }
}
