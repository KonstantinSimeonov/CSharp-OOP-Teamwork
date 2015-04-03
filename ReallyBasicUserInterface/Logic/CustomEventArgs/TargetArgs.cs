namespace Logic.CustomEventArgs
{
    using System;
    using Logic.Interfaces;

    public class TargetArgs : EventArgs
    {
        public ICard Target { get; set; }

        public TargetArgs()
            :base()
        {
            this.Target = null;
        }
    }

}
