namespace Engine.CustomExceptions
{
    using System;

    public class InvalidParseException : Exception
    {
        private const string ERROR_MESSAGE = "Could not parse line from the source file - line:\n{0}";

        public InvalidParseException(string line)
            : base(string.Format(InvalidParseException.ERROR_MESSAGE, line))
        { }
    }
}
