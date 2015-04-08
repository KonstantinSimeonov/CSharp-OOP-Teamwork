namespace Engine.CustomEventArgs
{
    using System;

    public class GameOverArgs : EventArgs
    {
        public string GameOverMessage { get; private set; }

        public GameOverArgs(string message = "bilo kvot bilo")
            : base()
        {
            this.GameOverMessage = message;
        }
    }
}
