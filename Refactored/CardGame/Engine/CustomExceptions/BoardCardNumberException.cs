namespace Engine.CustomExceptions
{
    using System;
    public class BoardCardNumberException : Exception
    {
        private const string ERROR_MESSAGE = "This section of the board({0}) cannot contain more than 5 cards!";

        public BoardCardNumberException(string section)
            : base(string.Format(BoardCardNumberException.ERROR_MESSAGE, section))
        {
        
        }
    }
}
