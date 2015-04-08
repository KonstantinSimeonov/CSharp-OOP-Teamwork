
namespace Logic.Interfaces
{
    using Logic.Delegates;
    public interface IFormPublisher
    {
        event EventRaiser GameOver;
        event EventRaiser DrawEvent;
        event EventRaiser RequestStateReport;
        event EventRaiser RequestCardsLeft;
        event EventRaiser PlayCardEvent;
        event EventRaiser Main1;
        event EventRaiser Battle;
        event EventRaiser Main2;
        event EventRaiser End;
    }
}
