namespace Logic.CustomEventArgs
{
    using System;
    using Engine;
    class TurnArgs : EventArgs
    {
        public bool PlayerUIactive { get; set; }
        public bool PlayersTurn { get; set; }
        public Phases Phase { get; set; }

        public TurnArgs()
        {
            
        }
    }
}
