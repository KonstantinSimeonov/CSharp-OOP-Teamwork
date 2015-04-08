namespace Engine.CustomEventArgs
{
    using System;
    using Logic.Interfaces;

    public class BattleArgs : EventArgs
    {
        public IMonsterCard Attacker { get; set; }
        public IMonsterCard Defensder { get; set; }

        public string IdAttacker { get; private set; }
        public string IdDefender { get; private set; }

        public BattleArgs(string IdAttacker, string IdDefender)
            :base()
        {
            this.IdAttacker = IdAttacker;
            this.IdDefender = IdDefender;
        }
    }

}
