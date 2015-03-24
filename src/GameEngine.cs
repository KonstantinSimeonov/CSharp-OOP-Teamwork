namespace CardCademyGame
{
    using CardCademyGame.Interfaces;
    using CardCademyGame.Objects;
    using System.Collections.Generic;

    public class GameEngine
    {
        public static void Main()
        {
            var deck = InitializeDeck();

            var hero1 = new Hero(new Coordinates(0, 10), new HeroAbilityDamage(), "Ivan", 10, 30);
            var hero2 = new Hero(new Coordinates(30, 30), new HeroAbilityHeal(), "Gosho", 10, 30);

            var gameScreen = new WinFormsGameScreen();

            Run(deck, hero1, hero2, gameScreen);
        }

        private static Deck InitializeDeck()
        {
            // TODO: Generate cards
            return new Deck(new List<Card>() 
            { 
                new MonsterCard(new Coordinates(0,0), 2, "The only card", "Some text", 2, 3),
                new MonsterCard(new Coordinates(0,0), 2, "The only card 2", "Some text", 3, 3),
                new MonsterCard(new Coordinates(0,0), 3, "The only card 3", "Some text", 4, 3),
                new MonsterCard(new Coordinates(0,0), 5, "The only card 4", "Some text", 5, 3),
            });
        }

        private static void Run(Deck deck, Hero hero1, Hero hero2, IGameScreen gameScreen)
        {
            while (true)
            {
                TakeTurn(hero1, hero2, deck, gameScreen);
                
                TakeTurn(hero2, hero1, deck, gameScreen);
            }
        }

        private static void TakeTurn(Hero hero, Hero enemy, Deck deck, IGameScreen gameScreen)
        {
            hero.IncreazeMana();
            var drawnCard = deck.DrawCard();

            hero.AddCard(drawnCard);
            
            var cards = hero.GetCards();

            // TODO: Show cards

            // TODO: Read input
            // TODO Play cards
            // TODO 
            

            throw new System.NotImplementedException();
        }
    }
}
