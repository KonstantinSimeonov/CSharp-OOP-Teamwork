namespace Skeleton
{
    using Skeleton.Cards;

    public class MainProgram
    {
        public static void Main()
        {
            var testy = new EquipSpellCard("Golemiq mech", "vliza dulboko", "nema pAteka", Effects.NoEffect, Effects.Test, 10, 20);
            testy.ApplyEffect();
            var eng = new Engine.Engine();
            eng.Run();
        }
    }
}