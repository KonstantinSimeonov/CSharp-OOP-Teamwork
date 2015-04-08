namespace Logic.Interfaces
{
    public interface IMenu
    {
        void Display(); // the menu will be displayable
        void ChooseOption(int optionNumber); // the user should be able to choose an option from the menu
    }
}
