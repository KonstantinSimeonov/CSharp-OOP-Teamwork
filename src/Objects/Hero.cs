using CardCademyGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCademyGame.Objects
{
    public class Hero : GameObject, ILiving, IAttacking
    {
        private List<Card> cards;
        private int mana;

        public Hero(Coordinates coords, HeroAbility heroAbility, string name, int damage, int hitPoints)
            : base(coords)
        {
            this.cards = new List<Card>();
            this.mana = 0;

            this.HeroAbility = heroAbility;
            this.Name = name;
            this.Damage = damage;
            this.HitPoints = hitPoints;
        }

        public HeroAbility HeroAbility { get; set; }

        public string Name { get; set; }

        public int Damage { get; set; }

        public int HitPoints { get; set; }

        public bool IsDead
        {
            get
            {
                return this.HitPoints <= 0;
            }
        }

        public void AddCard(Card card)
        {
            this.cards.Add(card);
        }

        public IEnumerable<Card> GetCards()
        {
            return this.cards.ToList();
        }

        public void Attack(ILiving target)
        {
            target.HitPoints -= this.Damage;
        }

        public bool TryPlayCard(Card card)
        {
            if (card.ManaCost <= this.mana)
            {
                this.mana -= card.ManaCost;
                this.cards.Remove(card);
                return true;
            }

            return false;
        }

        public void IncreazeMana()
        {
            this.mana++;
            if (this.mana > 10)
            {
                this.mana = 10;
            }
        }
    }
}
