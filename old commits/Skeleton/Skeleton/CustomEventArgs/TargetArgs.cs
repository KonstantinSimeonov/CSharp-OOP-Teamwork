namespace Skeleton.CustomEventArgs
{
    using System;
    using Skeleton.Interfaces;

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
