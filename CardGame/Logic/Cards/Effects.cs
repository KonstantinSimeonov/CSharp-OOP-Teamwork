namespace Logic.Cards
{
    using System;
    using Logic.Interfaces;

    public static class Effects
    {
        // TODO: fix those handler, add some effect, make them work l-o-l

        public delegate void EventHandler(ICard target, EventArgs e);
        public static event EventHandler Thrower = delegate { };

        private enum CardTypes { Monster, Effect };

        public static void NoEffect()
        {
            
        }

        public static void NoEffect(int a, int b)
        {
        
        }

        private static ICard RequestCard()
        {
            ICard target = null;
            Thrower(target, new EventArgs());
            return target;

        }

        public static void Game(int a, int b)
        {
            Console.WriteLine(a+b);
        }

        public static void ChangeMonsterPoints(int attack, int defense)
        {
            ChangeMonsterPoints_Params(RequestCard() as IMonsterCard, attack, defense);
        }

        public static void ChangeMonsterPoints_Params(IMonsterCard target, int attackBy, int defenseBy)
        {
            target.ChangeAttack(attackBy);
            target.ChangeDefense(defenseBy);
        }

        public static void DestroyCard_Params(IBoard board, ICard target, bool fromAI, bool effectCard)
        {
            if (fromAI)
            {
                if (effectCard)
                {
                    board.AIEffectCards.Remove(target as IManaCostable);
                }
                else
                {
                    board.AIMonsters.Remove(target as IMonsterCard);
                }
            }
            else
            {
                if (effectCard)
                {
                    board.PlayerEffectCards.Remove(target as IManaCostable);
                }
                else
                {
                    board.PlayersMonsters.Remove(target as IMonsterCard);
                }
            }
        }
    }
}
