namespace Logic.CustomEventArgs
{
    using System;
    class RemainingCardArgs : EventArgs
    {
        public int Remaining { get; set; }

        public RemainingCardArgs()
        { }
    }
}
