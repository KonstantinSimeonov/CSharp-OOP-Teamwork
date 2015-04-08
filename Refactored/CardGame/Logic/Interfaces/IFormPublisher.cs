
namespace Logic.Interfaces
{
    using Engine.Delegates;
    public interface IFormPublisher
    {
        event EventRaiser GameOver;
        event EventRaiser DrawEvent;
        event EventRaiser PlayCardEvent;
        event EventRaiser Main1;
        event EventRaiser Battle;
        event EventRaiser Main2;
        event EventRaiser End;
    }
}
